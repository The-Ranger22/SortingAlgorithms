module CSC407_P4.algorithms.mergesort

open System.Diagnostics

[<Literal>]
let PICK_L = 1
[<Literal>]
let PICK_R = 2

/// compareLeftRight : returns int
/// [Parameters] ->
///       left : an integer array containing the 'left' half of a bigger array
///      right : an integer array containing the 'right' half of a bigger array
///      leftI : the index of the left element that we want to compare
///     rightI : the index of the right element that we want to compare
/// [Description] ->
///     Determines if the element located in the left array at the left index provided is greater than the element located
///     in the right array at the right index provided. Returns PICK_L (1) if the left element is less than the right element.
///     Returns PICK_R (2) if the right element is less than the left element. Returns 0 if something funky happens.
let compareLeftRight (left: int [], right: int [], leftI: int, rightI: int) =
    if not (leftI >= left.Length || rightI >= right.Length) then  //if neither index is outside of bounds for their respective arrays, compare the elements at those indices 
        if left.[leftI] < right.[rightI] then //if the element at the left index is smaller, return PICK_L
            PICK_L
        else //else return PICK_R
            PICK_R
    else if leftI >= left.Length && rightI < right.Length then //if the left index is out of bounds but the right index isn't, return PICK_R to signal that the right element should be selected.
        PICK_R
    else if leftI < left.Length && rightI >= right.Length then //if the right index is out of bounds but the left index isn't, return PICK_L to signal that the left element should be selected.
        PICK_L
    else
        0
        
            
/// slottogether : returns an array of ints
/// [Parameters] ->
///      left : An ordered array of ints
///     right : An ordered array of ints
/// [Description] ->
///     Interleaves the elements of two arrays, left and right, into a new array in ascending order.
let slottogether (left: int [], right: int []) =
    let arr: int [] = Array.zeroCreate (left.Length + right.Length)
    let mutable leftI = 0
    let mutable rightI = 0
    for i = 0 to arr.Length - 1 do
        match compareLeftRight(left, right, leftI, rightI) with
        | PICK_L -> arr.[i] <- left.[leftI]; leftI <- leftI + 1
        | PICK_R -> arr.[i] <- right.[rightI]; rightI <- rightI + 1
        | _ -> arr.[i] <- -1
    arr
    


/// merge : returns an array of ints
/// [Parameters] ->
///     arr : an array of ints
/// [Description] ->
///     Sorts an array of integers by recursively subdividing the front half, called left, part of the array before doing
///     the same for the back half, called right. After that, the resulting arrays, left and right, are interleaved
///     together and the resulting array is returned.
let rec merge (arr: int []) =
    if arr.Length > 1 then
        let left = merge arr.[0..(arr.Length / 2 - 1)]
        let right = merge arr.[(arr.Length / 2)..]
        slottogether(left, right)
    else
        arr
/// mergesort : returns an array of ints
/// [Parameters] ->
///     arr : an  array of ints
/// [Description] ->
///     Helper function for the recursive merge function
let mergesort (arr: int []) =
    merge arr
///
/// How merge sort works :
///                                  [1][4][6][2][7][5][3][9]
///                                    /                  \
///                             [1][4][6][2]         [7][5][3][9]
///                               /      \             /      \
///                           [1][4]   [6][2]      [7][5]   [3][9]
///                           /   \    /   \       /   \    /   \
///                         [1]  [4] [6]  [2]    [7]  [5] [3]  [9]
///                          \   /    \   /       \   /    \   /
///                         [1][4]   [2][6]      [5][7]   [3][9]
///                            \       /            \       /
///                          [1][2][4][6]         [3][5][7][9]
///                                \                   /
///                              [1][2][3][4][5][6][7][9]
///
/// split the array in half until only a single element remains
/// reintegrate the array pieces, ordering them from smallest to largest
