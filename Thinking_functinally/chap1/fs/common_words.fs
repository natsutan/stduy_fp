open System

let words = ["To" ;  "be" ; "or " ; "not" ; "to" ; "be"]

let myToLower (s : string) :string = 
    s.ToLower()

let countRuns (words : string list) : (string * int) list =
    let mutable result = []
    let mutable cnt = 1
    let mutable next = ""

    for ww in  List.windowed 2 words do
        printfn "%A" ww
        let w = ww.Item(0)
        next <- ww.Item(1)
        if w = next then
            cnt <- cnt + 1
        else
           result <- List.append result [(w, cnt)]
           cnt <- 1
    
    List.append result [(next, cnt)]
    
let commonWords (words : string list) (n : int) =
    List.map myToLower words
    |> List.sort
    |> countRuns 
    |> List.take n


let result = commonWords words 2
printfn "%A"  result
