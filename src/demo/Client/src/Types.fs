module Types

[<RequireQualifiedAccess>]
type Route =
    | Root
    | Invalid

type AppState =
    { CurrentRoute: Route
      Cars: string list
      ErrorMessage: string option }
    static member Empty =
        { CurrentRoute = Route.Root
          Cars = []
          ErrorMessage = None }

type Msg =
    | CarsRequest
    | CarsResponse of Result<string list, string>
    | ComponentError of exn