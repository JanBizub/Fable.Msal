module State

open Elmish
open Microsoft.FSharp.Core
open Types
open TimesheetAppRouter
open Fable.Msal

let init result =
    let state, cmd =
        urlUpdate result AppState.Empty

    state, Cmd.batch []

let update (pci: PublicClientApplication) msg (state: AppState) =
    match msg with
    | CarsRequest -> { state with Cars = [] }, Cmd.OfAsync.either HttpRequests.getCars pci CarsResponse ComponentError

    | CarsResponse result ->
        match result with
        | Ok cars -> { state with Cars = cars }, Cmd.none
        | Error e -> state, e |> exn |> ComponentError |> Cmd.ofMsg

    | ComponentError exn -> { state with ErrorMessage = $"Error: {exn.Message}" |> Some }, Cmd.none