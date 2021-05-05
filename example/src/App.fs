namespace App

module Root = 
    open Elmish
    open Elmish.React
    open Fable.Core
    open Fable.React
    open Fable.React.Dragula
    open Fable.React.Props

    type Msg =
    | NoMsg

    type Model = {
        LastDragged : string option
    }

    let draggables() =
        let left = 
            div [ Id "left-container"; ClassName "container left" ] [
                p [ ClassName "content" ] [ str "This is some content" ] 
                div [ClassName "content"] [
                    p [] [ str "And some content with an input box" ]
                    input [ ]
                ]
                p [ ClassName "content" ] [ str "And yet even more" ] 
            ]

        let right =
            div [Id "right-container"; ClassName "container right" ] [
                p [ ClassName "content" ] [ str "This is is also content" ]
                p [ ClassName "content" ] [ str "And some more content" ]
                h3 [ ClassName "content" ] [ str "And more content, but different" ]
            ]

        Fable.React.Dragula.dragula [| left; right |] None
        div [] [
            left
            right
        ]

    let root _ _ =
        

        div [] [
            h2 [] [ str "Drag and drop example project"]
            div [ ClassName "wrapper" ] [
                draggables()
            ]
        ]

    let update msg model =
        match msg with
        | NoMsg -> model, Cmd.none

    let init() = { LastDragged = None }, Cmd.none

    Program.mkProgram init update root
    |> Program.withReactBatched "root"
    |> Program.run