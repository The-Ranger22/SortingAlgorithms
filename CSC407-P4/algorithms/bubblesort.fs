module CSC407_P4.algorithms.bubblesort
/// swap : int[] arr, int index1, int index2
///         arr - an integer array
///         index1 - the first of two indexes whose element will be swapped with the second
///         index2 - the second of two indexes whose element will be swapped with the first
///
/// Description :
/// Given an array and two indices, the swap function will swap the elements at the given arrays around so that the
/// element residing at index1 will be located at index2 and vice versa.
let swap (arr: int[], index1: int, index2: int) =
    let temp = arr.[index1]
    arr.[index1] <- arr.[index2]
    arr.[index2] <- temp
    0
    
/// bubblesort : int[] arr
///     arr - an integer array
/// Description :
/// Sorts a given array by checking sequentially if the previous element in the array is bigger than the current element.
/// If the previous element is bigger, it is swapped with the current element and a flag is raised marking that the array
/// is unsorted.
/// 
let bubblesort (arr : int[]) =
    let mutable sorted : bool = false
    while(not sorted) do
        sorted <- true //
        for i = 1 to arr.Length - 1 do
            if arr.[i - 1] > arr.[i] then //is the previous element greater than the current element? 
                sorted <- false //since the previous element was greater than the current element, the array is not sorted
                swap (arr, (i - 1), i) |> ignore //swap the elements in the array, and ignore the return value. 
    arr //returns the sorted array
