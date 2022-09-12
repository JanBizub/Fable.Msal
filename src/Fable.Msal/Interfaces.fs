module internal Fable.Msal.Interfaces

open Fable.Core
open System.Collections.Generic

type IBaseAuthRequest =
    abstract authority: string
    abstract correlationId: string
    abstract scopes: string array
    abstract authenticationScheme: AuthenticationScheme option
    abstract claims: string option
    abstract shrClaims: string option
    abstract shrNonce: string option
    abstract resourceRequestMethod: string option
    abstract resourceRequestUri: string option
    abstract sshJwk: string option
    abstract sshKid: string option
    abstract azureCloudOptions: AzureCloudOptions option
    abstract requestedClaimsHash: string option


type ICommonAuthorizationUrlRequest =
    inherit IBaseAuthRequest

    abstract redirectUri: string
    abstract responseMode: ResponseMode
    abstract account: AccountInfo option
    abstract codeChallenge: string option
    abstract codeChallengeMethod: string option
    abstract domainHint: string option with get, set
    abstract extraQueryParameters: Dictionary<string, string>
    abstract tokenQueryParameters: Dictionary<string, string>
    abstract extraScopesToConsent: string array
    abstract loginHint: string option
    abstract nonce: string option
    abstract prompt: string option
    abstract sid: string option
    abstract state: string option
    abstract nativeBroker: bool option


type ICommonSilentFlowRequest =
    inherit IBaseAuthRequest

    abstract account: AccountInfo
    abstract forceRefresh: bool
    abstract tokenQueryParameters: Dictionary<string, string> option


type ISilentRequest =
    inherit ICommonSilentFlowRequest

    abstract redirectUri: string option
    abstract extraQueryParameters: Dictionary<string, string> option
    abstract authority: string option
    abstract account: AccountInfo option
    abstract correlationId: string option
    abstract forceRefresh: bool option


type IRedirectRequest =
    abstract scopes: string array
    abstract redirectStartPage: string option
    abstract onRedirectNavigate: (string -> U2<bool, unit>) option