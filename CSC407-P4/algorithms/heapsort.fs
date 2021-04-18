module CSC407_P4.algorithms.heapsort

open CSC407_P4.algorithms
open bubblesort

(*let swap (arr: int[]) (index1: int) (index2: int) =
    let temp = arr.[index1]
    arr.[index1] <- arr.[index2]
    arr.[index2] <- temp
    0*)

let rec heapify (arr: int[]) (n: int) (i: int) : int[]=
    let mutable largest: int = i
    let left = 2 * i + 1
    let right = 2 * i + 2
    if (left < n && arr.[left] > arr.[largest]) then
        largest <- left
    elif (right < n && arr.[right] > arr.[largest]) then
        largest <- right
    if (largest <> i) then
        swap (arr, i, largest) |> ignore
        heapify arr n largest
        else arr
    arr
    
    
    
    
    
let heapsort (arr: int[]) =
    let n:int = arr.Length
    for i = n/2 - 1 to 0 do
        heapify arr n i |> ignore
    for i = n to 0 do
        swap (arr, i, 0) |> ignore
        heapify arr i  0 |> ignore
    arr
    
