namespace Core

open CSC407_P4.algorithms

module Program =
    [<EntryPoint>]
    let main argv = 
        let arr = [|21; 22; 53; 28; 96; 1; 18; 37; 77; 40; 65|] // the array to be sorted
        printfn "bubble-sort    : %A" (bubblesort.bubblesort arr.[0..]) //pass in a copy of the array to be sorted
        printfn "insertion-sort : %A" (insertionsort.insertionsort arr.[0..]) //pass in a copy of the array to be sorted
        printfn "selection-sort : %A" (selectionsort.selectionsort arr.[0..]) //pass in a copy of the array to be sorted
        printfn "merge-sort     : %A" (mergesort.mergesort arr.[0..]) //pass in a copy of the array to be sorted
        printfn "heap-sort      : %A" (heapsort.heapsort arr.[0..]) //pass in a copy of the array to be sorted
        printfn "quick-sort      : %A" (quicksort.quicksort (arr.[0..], 0, arr.Length - 1)) //pass in a copy of the array to be sorted
        0 // return an integer exit code
/// F# Arrays:
///    declaration : let arr = [||], use ';' to separate elements
///    accessing array elements : arr.[index]
///    assigning a new value at an index : arr.[index] <- value
///    array slicing : arr.[l..u], where l is the lower bound of the array and u is the upper bound of the array. Produces a copy of the array.
///
/// 