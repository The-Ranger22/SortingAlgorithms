module CSC407_P4.algorithms.selectionsort

open CSC407_P4.algorithms
open bubblesort /// uses bubblesort's swap function


(*Implementation of selection sort. Selection sort works by taking the smallest element in the array and putting at the beginning, where that element now composes the sorted part of the array. 
Then the next smallest element is found in the unsorted part, and is again placed at the beginning of the the unsorted part. This process repeats.
*)
let selectionsort (arr : int[]) =
    for i = 0 to arr.Length - 1 do  /// outer loop iterates through the entire array
        let mutable min:int = arr.[i]
        let mutable minIndex:int = i
        for j = i + 1 to arr.Length - 1 do ///iterates through the 'unsorted' part of the array
            if (arr.[j] < min) then   ///if the current element of the unsorted part is less than min 
                min <- arr.[j]   ///min becomes the element at index j
                minIndex <- j   
        swap (arr, i, minIndex) |> ignore ///swap the ith and jth element so the jth element is now in the sorted part of the array. 
    arr
