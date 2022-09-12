namespace Fable.Msal

type RedirectRequest = { prompt: string; scopes: string list }

[<RequireQualifiedAccess>]
module RedirectRequest =
    let empty () = { prompt = "login"; scopes = [] }

[<AutoOpen>]
module RedirectRequestCE =
    type RedirectRequestBuilder() =
        member _.Yield(_) = RedirectRequest.empty ()

        /// prompt - Indicates the type of user interaction that is required.
        /// login: will force the user to enter their credentials on that request, negating single-sign on
        /// none:  will ensure that the user isn't presented with any interactive prompt. if request can't be completed via single-sign on, the endpoint will return an interaction_required error
        /// consent: will the trigger the OAuth consent dialog after the user signs in, asking the user to grant permissions to the app
        /// select_account: will interrupt single sign-=on providing account selection experience listing all the accounts in session or any remembered accounts or an option to choose to use a different account
        /// create: will direct the user to the account creation experience instead of the log in experience
        [<CustomOperation("prompt")>]
        member _.Prompt(state: RedirectRequest, prompt) = { state with prompt = prompt }

        /// scopes: Array of scopes the application is requesting access to.
        [<CustomOperation("scopes")>]
        member _.Scopes(state: RedirectRequest, scopes) = { state with scopes = scopes }

    let msalRedirectRequest =
        RedirectRequestBuilder()