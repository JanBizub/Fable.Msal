[<RequireQualifiedAccess>]
module CarsHandler

open Microsoft.AspNetCore.Http
open Giraffe
open Microsoft.Identity.Web.Resource

let get () =
    fun (next: HttpFunc) (ctx: HttpContext) ->
        task {
            ctx.VerifyUserHasAnyAcceptedScope("access_as_user")

            let cars =
                [ "Honda Accord"
                  "Honda Legend"
                  "Honda Civic"
                  "BMW 7" ]

            return! json cars next ctx
        }
