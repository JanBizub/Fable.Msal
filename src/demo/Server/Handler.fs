[<RequireQualifiedAccess>]
module Handler

open System
open Microsoft.AspNetCore.Http
open Giraffe
open Microsoft.Extensions.Logging

let errorHandler (ex: Exception) (logger: ILogger) =
    logger.LogError(ex, "An unhandled exception has occurred while executing the request.")

    clearResponse
    >=> setStatusCode 500
    >=> text ex.Message


let authenticate: HttpFunc -> HttpContext -> HttpFuncResult =
    requiresAuthentication (challenge "Bearer")