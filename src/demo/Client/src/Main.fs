module Main

open TimesheetAppRouter
open Elmish
open Elmish.Debug
open Elmish.React
open Elmish.Navigation
open Elmish.UrlParser
open Fable.Msal
open Elmish.HMR // Elmish.HMR must be last open statement in order to HMR works correctly.

let pciConfig =
    msalConfiguration {
        auth (
            msalBrowserAuthOptions {
                clientId "<clientId>"
                authority "https://login.microsoftonline.com/<authority>"
            }
        )
    }

let pci =
    pciConfig |> PublicClientApplication

let authenticatedProgram pci =
    Program.mkProgram State.init (State.update pci) View.Render

let createProgram program =
    program
    |> Program.toNavigable (parseHash pageParser) urlUpdate
#if DEBUG
    |> Program.withDebugger
#endif
    |> Program.withReactSynchronous "elmish-app"
    |> Program.run

promise {
    let! authResult = pci.handleRedirectPromise ()

    let silentRequest =
        msalSilentRequest {
            account (pci.getAllAccounts().[0])
            scopes [ "openid"; "profile" ]
        }

    match authResult with
    | Some authResult ->
        let! authRes = silentRequest |> pci.acquireTokenSilent

        pci |> authenticatedProgram |> createProgram

    | None ->
        let! authRes = silentRequest |> pci.acquireTokenSilent

        pci |> authenticatedProgram |> createProgram

}
|> Promise.catch (fun e ->
    Browser.Dom.console.log e.Message

    let redirectRequest =
        msalRedirectRequest {
            scopes [ "openid"
                     "profile"
                     "api://32ebd7e2-5c5d-4e32-85d2-a5c2ed87ae66/access_as_user" ]

            prompt "login"
        }

    pci.loginRedirect redirectRequest |> Promise.start)
|> Promise.start