namespace Fable.Msal

open System
open System.Collections.Generic

type SilentRequest =
    { account: AccountInfo option
      scopes: string list
      authority: string option
      correlationId: Guid option
      forceRefresh: bool option
      extraQueryParameters: Dictionary<string, string> option }

[<RequireQualifiedAccess>]
module SilentRequest =
    let empty () =
        { account = None
          scopes = []
          authority = None
          correlationId = None
          forceRefresh = None
          extraQueryParameters = None }

[<AutoOpen>]
module SilentRequestCE =
    type SilentRequestBuilder() =
        member _.Yield(_) = SilentRequest.empty ()

        /// Account entity to lookup the credentials.
        [<CustomOperation("account")>]
        member _.Account(state: SilentRequest, v) = { state with account = Some v }

        /// Array of scopes the application is requesting access to.
        [<CustomOperation("scopes")>]
        member _.Scopes(state: SilentRequest, v) = { state with scopes = v }

        /// Url of the authority which the application acquires tokens from.
        [<CustomOperation("authority")>]
        member _.Authority(state: SilentRequest, v) = { state with authority = Some v }

        /// Unique GUID set per request to trace a request end-to-end for telemetry purposes.
        [<CustomOperation("correlationId")>]
        member _.CorrelationId(state: SilentRequest, v) = { state with correlationId = Some v }

        /// Forces silent requests to make network calls if true.
        [<CustomOperation("forceRefresh")>]
        member _.ForceRefresh(state: SilentRequest, v) = { state with forceRefresh = Some v }

    let msalSilentRequest =
        SilentRequestBuilder()