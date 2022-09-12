namespace Fable.Msal

type BrowserAuthOptions =
    { clientId: string
      authority: string option
      redirectUri: string option }

[<RequireQualifiedAccess>]
module BrowserAuthOptions =
    // todo: client id should never be empty
    let empty () =
        { clientId = ""
          authority = "https://login.microsoft.com/common" |> Some
          redirectUri = None }

[<AutoOpen>]
module BrowserAuthOptionsCE =
    type BrowserAuthOptionsBuilder() =
        // todo: client id should never be empty
        member _.Yield(_) = BrowserAuthOptions.empty ()

        /// Client ID of your app registered with our Application registration portal : https://portal.azure.com/#blade/Microsoft_AAD_IAM/ActiveDirectoryMenuBlade/RegisteredAppsPreview in Microsoft Identity Platform
        [<CustomOperation("clientId")>]
        member _.ClientId(state: BrowserAuthOptions, clientId) = { state with clientId = clientId }

        /// You can configure a specific authority, defaults to " " or "https://login.microsoftonline.com/common"
        [<CustomOperation("authority")>]
        member _.Authority(state: BrowserAuthOptions, authority) =
            { state with authority = Some authority }

        /// The redirect URI where authentication responses can be received by your application. It must exactly match one of the redirect URIs registered in the Azure portal.
        [<CustomOperation("redirectUri")>]
        member _.RedirectUri(state: BrowserAuthOptions, redirectUri) =
            { state with redirectUri = Some redirectUri }

    let msalBrowserAuthOptions =
        BrowserAuthOptionsBuilder()