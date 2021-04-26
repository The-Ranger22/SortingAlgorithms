module CSC407_P4.algorithms.insertionsort

///implementation of insertion sort algorithm. Insertion sort works by running through an array of size n from 1 to n
/// It compares one element at a time to its predeccesor to determine if the element should stay or move down
let insertionsort (arr : int[]) =
    for i = 1 to arr.Length-1 do  /// loop iterates through the entire array starting at index 1
        let mutable temp:int = arr.[i]  //temp is holding the current value
        let mutable location:int = i - 1    //location is holding the location of the current predecessor
        while((location >= 0) && (arr.[location] > temp)) do  //while you are in the array and the value of the predecessor is greater than the current
            arr.[location + 1] <- arr.[location] //need to move the predecessor in front of the current value
            location <- location - 1    //move the location index down one to store the current value
        
        arr.[location+1] <- temp    //store the current value in the correct spot, if no changes were made, current stays in orignal spot
    arr