// Learn more about F# at http://fsharp.org

open System


type Rank = Two | Three | Four | Five | Six | Seven | Eight 
            | Nine | Ten | Jack | Queen | King | Ace

type Suit = Clubs | Diamonds | Spades | Hearts  

type Card = Rank * Suit 

type Deck = Card list


let createDeck () =
    let ranks = [ Two ; Three ; Four ; Five ; Six ; Seven ; Eight; 
                  Nine ; Ten ; Jack ; Queen ; King ; Ace ]
    let suits = [ Clubs; Diamonds;  Spades; Hearts ]
    
    let mutable cardList = []

    for rank in ranks do 
        for suit in suits do 
            cardList <-  cardList @ [ Card(rank, suit) ]

    cardList

let sortDeck (deck: Deck) = 
    List.sortBy (fun _ -> Guid.NewGuid().ToString()) deck


[<EntryPoint>]
let main argv =
    let mutable count = 0 
    let deck = createDeck() |> sortDeck
    for card in deck do 
        count <- count + 1
        let rank, suit = card
        printfn "%d - %A %A " count rank suit

    Console.ReadLine()|> ignore
    0 // return an integer exit code
