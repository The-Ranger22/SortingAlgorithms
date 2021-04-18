module CSC407_P4.algorithms.heapsort

open CSC407_P4.algorithms
open bubblesort /// I use the swap function from bubblesort


(*Implementation of heapsort. Heapsort works by converting the list into a max-heap, where the largest element is stored at the root. 
The root (0th element) is then swapped with the last item of the array, and then the new root is moved to its correct spot to make the array (excluding the last element) into a heap again. 
This is repeated until the elements have been sorted.*)


let rec heapify (arr: int[]) (n: int) (i: int) =
    let mutable largest: int = i
    let left = 2 * i + 1
    let right = 2 * i + 2
    if (left < n && arr.[left] > arr.[largest]) then   ///sifting occurs when the element at index 'largest' is less than either of it's children.
        largest <- left
    if (right < n && arr.[right] > arr.[largest]) then
        largest <- right
    if (largest <> i) then  ///if largest equals i, then the array is a heap, and no more swapping or heapifying is needed. 
        swap (arr, i, largest) |> ignore  ///else swap arr[i] with the largest of its two children
        heapify arr n largest /// reheapify after the swap. 
      
 
    
 
let heapsort (arr: int[]) =
    let n:int = arr.Length - 1
    for i = n/2 - 1 downto 0 do   ///turn the array into max heap
        heapify arr n i 
    for i = n downto 0 do  ///repeated swap the root and the 'last' element in the array and then reheapify.  
        swap (arr, i, 0) |> ignore ///Really, the first iteration is swaps with the last, second with second to last, etc because the last elements are in the correct spot after each iteration
        heapify arr i  0 
    arr
    
