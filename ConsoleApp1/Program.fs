// Learn more about F# at http://fsharp.org

open System


type Rank = Two | Three | Four | Five | Six | Seven | Eight 
            | Nine | Ten | Jack | Queen | King | Ace

type Suit = Clubs | Diamonds | Spades | Hearts  

type Card = Rank * Suit 

type Deck = Card list

let ranks = [ Two ; Three ; Four ; Five ; Six ; Seven ; Eight; 
              Nine ; Ten ; Jack ; Queen ; King ; Ace ]

let suits = [ Clubs; Diamonds;  Spades; Hearts ]

let createDeck () =
    let mutable cardList = []

    for rank in ranks do 
        for suit in suits do 
            cardList <-  cardList @ [ rank, suit ]

    cardList

let createDeck' () =
    [ for r in ranks do
      for s in suits do
        yield r, s ]

let makeRandomString () = Guid.NewGuid().ToString()

let sortDeck (deck: Deck) = 
    List.sortBy (fun _ -> makeRandomString()) deck

let printDeck deck =
    deck |> List.iteri (fun i (r, s) -> printfn "%d - %A %A " (i + 1) r s)

[<EntryPoint>]
let main argv =
    createDeck'() |> sortDeck |> printDeck
    Console.ReadLine()|> ignore
    0 // return an integer exit code
