module BeautifulDnd

open System
open Fable.React
open Fable.React.Props
open Browser.Types
open Fable.Core
open Fable.Core.JsInterop
open Feliz

open Fable.Core.JsInterop

type IDraggableAttribute = interface end

[<Emit "Object.assign({}, $0, $1)">]
let objectAssign (x: obj) (y: obj) : obj = jsNative

type draggable =
    static member inline draggableId (id : string) = unbox<IDraggableAttribute>("draggableId", id)
    static member inline children (children: ReactElement list) =
        unbox<IDraggableAttribute> ("children", React.keyedFragment("children", children))
    static member inline index (i : int) = unbox<IDraggableAttribute>("index", i)

[<Erase>]
type Draggable() =
    static member inline draggable _id index (properties: IDraggableAttribute list) children =
        let id = draggable.draggableId _id
        let index = draggable.index index
        let inputProperties = createObj !!(id :: (index ::properties))
        ofImport "Draggable" "react-beautiful-dnd" inputProperties children

type DroppableStateSnapshot = {
    isDraggingOver : bool
}

type DroppableProvided = {
    innerRef : Browser.Types.Element -> unit
}

// type IDroppableProvidedAttribute = interface end
// type droppableProvided() =
//     static member inline innerRef (fn : ReactElement option -> unit)= unbox<IDroppableProvidedAttribute>("innerRef", fn)

// type DroppableProvided() =
//     static member inline droppableProvided () =
//         ofImport "DroppableProvided" "react-beautiful-dnd" [] []

type IDroppableAttribute = interface end
type droppable =
    static member inline droppableId (id : string) = unbox<IDroppableAttribute>("droppableId", id)
    static member inline childrenFn (f : (DroppableProvided * DroppableStateSnapshot) -> ReactElement) =
        unbox<IDroppableAttribute>("children", f)


[<Erase>]
type Droppable() =
    static member inline droppable (id : string) props (childrenFn: (DroppableProvided * DroppableStateSnapshot) -> ReactElement) =
        let _id = droppable.droppableId id
        let f = droppable.childrenFn childrenFn
        let props = keyValueList CaseRules.LowerFirst (_id :: (f :: props))
        ofImport "Droppable" "react-beautiful-dnd"  props []

type DragDropContext() =
    static member inline dragDropContext props children =
        ofImport "DragDropContext" "react-beautiful-dnd" props children

