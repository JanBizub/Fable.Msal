namespace Fable.Msal

open Fable.Core
open Fable.Core.JS

/// The PublicClientApplication class is the object exposed by the library to perform authentication and authorization functions in Single Page Applications
/// to obtain JWT tokens as described in the OAuth 2.0 Authorization Code Flow with PKCE specification.
[<Import("PublicClientApplication", from = "@azure/msal-browser")>]
type PublicClientApplication(conf: MsalConfiguration) =
    abstract initialize: unit -> Promise<unit>
    abstract loginRedirect: ?request: RedirectRequest -> Promise<unit>
    abstract acquireTokenSilent: request: SilentRequest -> Promise<AuthenticationResult>
    abstract acquireTokenSilentAsync: request: SilentRequest * account: AccountInfo -> Promise<AuthenticationResult>
    abstract handleRedirectPromise: ?hash: string -> Promise<AuthenticationResult option>
    abstract acquireTokenRedirect: request: RedirectRequest -> Promise<unit>
    abstract getAllAccounts: unit -> AccountInfo array
    abstract getAccountByUsername: userName: string -> AccountInfo option
    abstract getAccountByHomeId: homeAccountId: string -> AccountInfo option
    abstract getAccountByLocalId: localAccountId: string -> AccountInfo option
    abstract setActiveAccount: account: AccountInfo option -> unit
    abstract getActiveAccount: unit -> AccountInfo option
    abstract preflightInteractiveRequest: setInteractionInProgress: bool -> unit

    /// Initializer function to perform async startup tasks such as connecting to WAM extension
    default _.initialize() : Promise<unit> = jsNative

    /// <summary>
    /// Use when initiating the login process by redirecting the user's browser to the authorization endpoint. This function redirects the page, so
    /// any code that follows this function will not execute.
    ///
    /// IMPORTANT: It is NOT recommended to have code that is dependent on the resolution of the Promise. This function will navigate away from the current
    /// browser window. It currently returns a Promise in order to reflect the asynchronous nature of the code running in this function.
    /// </summary>
    /// <param name="request" />
    default _.loginRedirect(?request: RedirectRequest) : Promise<unit> = jsNative

    /// <summary>Silently acquire an access token for a given set of scopes. Will use cached token if available, otherwise will attempt to acquire a new token from the network via refresh token.</summary>
    /// <param name="" />
    /// <param name="" />
    /// <returns>- a promise that is fulfilled when this function has completed, or rejected if an error was raised. Returns the <see cref="AuthResponse" /></returns>
    default _.acquireTokenSilent(silentRequest: SilentRequest) : JS.Promise<AuthenticationResult> = jsNative

    /// <summary>Silently acquire an access token for a given set of scopes. Will use cached token if available, otherwise will attempt to acquire a new token from the network via refresh token.</summary>
    /// <param name="" />
    /// <param name="" />
    /// <returns>- a promise that is fulfilled when this function has completed, or rejected if an error was raised. Returns the <see cref="AuthResponse" /></returns>
    default _.acquireTokenSilentAsync(request: SilentRequest, account: AccountInfo) : Promise<AuthenticationResult> =
        jsNative

    /// <summary>
    /// Event handler function which allows users to fire events after the PublicClientApplication object
    /// has loaded during redirect flows. This should be invoked on all page loads involved in redirect
    /// auth flows.
    /// </summary>
    /// <param name="hash">Hash to process. Defaults to the current value of window.location.hash. Only needs to be provided explicitly if the response to be handled is not contained in the current value.</param>
    /// <returns>Token response or null. If the return value is null, then no auth redirect was detected.</returns>
    default _.handleRedirectPromise(?hash: string) : Promise<AuthenticationResult option> = jsNative

    /// <summary>
    /// Use when you want to obtain an access_token for your API by redirecting the user's browser window to the authorization endpoint. This function redirects
    /// the page, so any code that follows this function will not execute.
    ///
    /// IMPORTANT: It is NOT recommended to have code that is dependent on the resolution of the Promise. This function will navigate away from the current
    /// browser window. It currently returns a Promise in order to reflect the asynchronous nature of the code running in this function.
    /// </summary>
    /// <param name="request" />
    default _.acquireTokenRedirect(request: RedirectRequest) : Promise<unit> = jsNative

    /// <summary>
    /// Returns all accounts that MSAL currently has data for.
    /// (the account object is created at the time of successful login)
    /// or empty array when no accounts are found
    /// </summary>
    /// <returns>Array of account objects in cache</returns>
    default _.getAllAccounts() : AccountInfo array = jsNative

    /// <summary>
    /// Returns the signed in account matching username.
    /// (the account object is created at the time of successful login)
    /// or null when no matching account is found.
    /// This API is provided for convenience but getAccountById should be used for best reliability
    /// </summary>
    /// <param name="userName" />
    /// <returns>The account object stored in MSAL</returns>
    default _.getAccountByUsername(userName: string) : AccountInfo option = jsNative

    /// <summary>
    /// Returns the signed in account matching homeAccountId.
    /// (the account object is created at the time of successful login)
    /// or null when no matching account is found
    /// </summary>
    /// <param name="homeAccountId" />
    /// <returns>The account object stored in MSAL</returns>
    default _.getAccountByHomeId(homeAccountId: string) : AccountInfo option = jsNative

    /// <summary>
    /// Returns the signed in account matching localAccountId.
    /// (the account object is created at the time of successful login)
    /// or null when no matching account is found
    /// </summary>
    /// <param name="localAccountId" />
    /// <returns>The account object stored in MSAL</returns>
    default _.getAccountByLocalId(localAccountId: string) : AccountInfo option = jsNative

    /// <summary>Sets the account to use as the active account. If no account is passed to the acquireToken APIs, then MSAL will use this active account.</summary>
    /// <param name="account" />
    default _.setActiveAccount(account: AccountInfo option) : unit = jsNative

    /// Gets the currently active account
    default _.getActiveAccount() : AccountInfo option = jsNative

    /// <summary>Preflight check for interactive requests</summary>
    /// <param name="setInteractionInProgress">Whether to set interaction in progress temp cache flag</param>
    default _.preflightInteractiveRequest(setInteractionInProgress: bool) : unit = jsNative