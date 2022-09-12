namespace Fable.Msal

[<CompiledName("Configuration")>]
type MsalConfiguration =
    { auth: BrowserAuthOptions
      cache: string option }

[<AutoOpen>]
module MsalConfigurationCE =
    type ConfigurationBuilder() =
        // todo: client id should never be empty
        member _.Yield(_) =
            { auth = BrowserAuthOptions.empty ()
              cache = None }

        [<CustomOperation("auth")>]
        member _.Auth(state: MsalConfiguration, auth) = { state with auth = auth }

    let msalConfiguration =
        ConfigurationBuilder()