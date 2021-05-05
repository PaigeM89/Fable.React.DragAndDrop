namespace Fable.React

open Fable.Core
open Fable.Core.JsInterop
open Browser.Types
open Fable.React
open Feliz

module Dragula =
    

    type Options = {
        /// Elements are copied instead of moved. Default: false
        copy : bool
        /// Elements in copy-source containers can be reordered. Default: false.
        /// Has no effect if `copy` is false
        copySortSource : bool
        /// Dropping the element outside a container will put it back in the original spot. Default: false.
        revertOnSpill : bool
        /// Dropping the element outside a container will remove it from the original container. Default: false
        removeOnSpill : bool
    } with
        static member Default() = {
            copy = false
            copySortSource = false
            revertOnSpill = false
            removeOnSpill = false
        }

    [<ImportDefault("dragula")>]
    let dragula(elements : ReactElement array) (options : Options option) : unit = jsNative

    // [<ImportDefault("Dragula")>]
    // let Dragula(elements : ReactElement array) (options : Options option) : ReactElement = jsNative

    let Dragula : obj = import "Dragula" "react-dragula"
    type DragulaComponent =
        static member elements (elements: ReactElement array) = prop.custom ("elements", elements)
        static member options (options : Options option) = prop.custom ("options", option)

    importSideEffects "./dragula.css"
