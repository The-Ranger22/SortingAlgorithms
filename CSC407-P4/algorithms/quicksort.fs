module CSC407_P4.algorithms.quicksort

open CSC407_P4.algorithms

open bubblesort ///this class will sue the bubblesort sort method


///The helper method for quicksort which will return an int. This function returns where the array needs to be split or
/// divided 
let partition(arr:int[], low: int, high:  int) =
    let mutable pivot:int = arr.[high]  //the algorithms pivot point, arbitraily set to be the value of the last element of the split
    let mutable i:int = low //set to be the first index in the array
    for j = low to high - 1 do  //go through the left or right half of the array
        if(arr.[j] <= pivot) then   //if the element is less then the pivot value (on left side of pivot)
            swap(arr, i, j)     //move the j value down and the i value up
            i <- i + 1  //increment i
    swap(arr, i, high)  //move the i value up and the high value down
    i   //return the new pivot point index
  
let rec quicksort (arr : int[], low: int, high : int) =
    if(low >= high) then    //if the array has been sorted
        arr //return the sorted array
     else
        let mutable pivotpoint : int = partition(arr, low, high)    //find the starting pivot point
        quicksort(arr, low, pivotpoint - 1 )    //sort the left part of the array
        quicksort(arr, pivotpoint + 1, high)    //sort the right part of the array

            