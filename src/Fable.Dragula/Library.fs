namespace Fable

module Dragula =
    open Fable.Core
    open Fable.Core.JsInterop
    open Browser.Types

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
    let dragula(elements : HTMLElement array) (options : Options option) : unit = jsNative

    importSideEffects "./public/dragula.css"

// module TestUse =
//     open Browser.Dom

//     let left = document.getElementById("left-events")
//     let right = document.getElementById("right-events")


//     Dragula.dragula [| left; right |] (Some { Dragula.Options.Default() with copy = true; copySortSource = false })
