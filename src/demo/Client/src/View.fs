[<RequireQualifiedAccess>]
module View
open Fable.Core.JsInterop
open Feliz
open Types
    
[<ReactComponent>]
let Render (state: AppState) dispatch =
  importAll "./style.scss"

  Html.div [
    Html.p [ prop.text (match state.ErrorMessage with None -> "" | Some e -> e) ]
    Html.p [ prop.text "AAD Demo" ]
    Html.p [ prop.text (match state.Cars with [] -> "" | _ -> state.Cars |> List.reduce (+)) ]
    Html.button [ prop.text "Fetch Cars"; prop.onClick (fun _ -> CarsRequest |> dispatch) ]
  ]
