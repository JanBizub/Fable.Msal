namespace Fable.Msal

open System

type AccountInfo =
    { homeAccountId: string
      environment: string
      tenantId: string
      username: string }

type AuthenticationResult =
    { uniqueId: string
      tenantId: string
      scopes: string array
      account: AccountInfo
      idToken: string
      idTokenClaims: obj
      accessToken: string
      fromCache: bool
      expiresOn: DateTime
      extExpiresOn: DateTime
      state: string
      familyId: string }

type CacheOptions =
    { cacheLocation: string option
      storeAuthStateInCookie: bool option
      secureCookies: bool option }

[<RequireQualifiedAccess>]
type AuthenticationScheme =
    | [<CompiledName("Bearer")>] BEARER
    | [<CompiledName("pop")>] POP
    | [<CompiledName("ssh-cert")>] SSH

[<RequireQualifiedAccess>]
type AzureCloudInstance =
    | [<CompiledName("0")>] None
    | [<CompiledName("https://login.microsoftonline.com")>] AzurePublic
    | [<CompiledName("https://login.windows-ppe.net")>] AzurePpe
    | [<CompiledName("https://login.chinacloudapi.cn")>] AzureChina
    | [<CompiledName("https://login.microsoftonline.de")>] AzureGermany
    | [<CompiledName("https://login.microsoftonline.us")>] AzureUsGovernment

type ResponseMode =
    | [<CompiledName("query")>] QUERY
    | [<CompiledName("fragment")>] FRAGMENT
    | [<CompiledName("form_post")>] FORM_POST

type AzureCloudOptions =
    { azureCloudInstance: AzureCloudInstance
      tenant: string option }
 
 [<RequireQualifiedAccess>]   
type Prompt =
    | [<CompiledName("login")>] Login
    | [<CompiledName("select_account")>] SelectAccount
    | [<CompiledName("consent")>] Consent


