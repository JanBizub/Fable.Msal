module TimesheetAppRouter

open Elmish
open Elmish.UrlParser
open Types

let pageParser: Parser<Route -> Route, Route> =
    oneOf [ map Route.Root top ]

let urlUpdate (route: Option<Route>) (state: AppState) =
    match route with
    | None -> { state with CurrentRoute = Route.Invalid }, Cmd.none

    | Some route ->
        match route with
        | Route.Root -> { state with CurrentRoute = route }, Cmd.none
        | Route.Invalid -> { state with CurrentRoute = route }, Cmd.none