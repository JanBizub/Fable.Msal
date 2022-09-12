[<RequireQualifiedAccess>]
module HttpRequests

open Fable.SimpleHttp
open Fable.SimpleJson
open Fable.Msal
open Fable.Core
open System
open Browser.Dom

let getRequest token (request: HttpRequest) =
    request
    |> Http.method GET
    |> Http.header (Headers.contentType "application/json")
    |> Http.header (Headers.authorization $"Bearer {token}")
    |> Http.send


let getCars (pci: PublicClientApplication) =
    let silentRequest =
        msalSilentRequest {
            account (pci.getAllAccounts().[0])
            scopes [ "openid"; "profile" ]
            correlationId Guid.Empty
        }

    async {
        let! authResponse =
            silentRequest
            |> pci.acquireTokenSilent
            |> Async.AwaitPromise

        console.warn "BEGIN REQUEST"
        console.log "ID Token -----------"
        console.log authResponse.idToken
        console.log "Access Token -------"
        console.log authResponse.accessToken
        console.warn "END REQUEST"

        let! response =
            Http.request "https://localhost:5001/api/cars"
            |> getRequest authResponse.accessToken

        match response.statusCode with
        | 200 ->
            return
                response.responseText
                |> Json.parseAs<string list>
                |> Ok
        | _ -> return response.responseText |> Error
    }