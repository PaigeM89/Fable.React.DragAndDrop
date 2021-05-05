module App

open Feliz
open Fable.React
open Fable.React.Props
open BeautifulDnd

[<ReactComponent>]
let BuildDraggable index content =
  let _id = sprintf "draggable-id-%i" index
  Draggable.draggable _id index [] content

[<ReactComponent>]
let TestDroppable() =
  Droppable.droppable "test-droppable" [] (fun (provided, snapshot) ->
    div [ Ref provided.innerRef ] [
      BuildDraggable 0 [p [] [ str "This is the first item"]]
      BuildDraggable 1 [p [] [ str "This is the second item"]]
      BuildDraggable 2 [p [] [ str "This is the third item"]]
      BuildDraggable 3 [p [] [ str "This is the fourth item"]]
    ])

[<ReactComponent>]
let RootComponent() =
  printfn "rendering root component"

  let left =
    div [ Id "left-container"; ClassName "container left" ] [
      TestDroppable()
    ]

  let right =
    div [Id "right-container"; ClassName "container right" ] [
      p [ ClassName "content" ] [ str "This is is also content" ]
      p [ ClassName "content" ] [ str "And some more content" ]
      h3 [ ClassName "content" ] [ str "And more content, but different" ]
    ]

  
  DragDropContext.dragDropContext [] [
    h3 [] [str "Test React Component"]
    div [ Id "wrapper"; ClassName "wrapper" ] [
      left
      //right
    ]
  ]
  

open Browser.Dom
printfn "starting react render"
ReactDOM.render(RootComponent(), document.getElementById "root")
