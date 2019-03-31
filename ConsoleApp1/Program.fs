// Learn more about F# at http://fsharp.org

open System


type Rank = Two | Three | Four | Five | Six | Seven | Eight 
            | Nine | Ten | Jack | Queen | King | Ace

type Suit = Clubs | Diamonds | Spades | Hearts  

type Card = Card of Rank * Suit 

type Deck = Deck of Card list


let createDeck () =
    let ranks = [ Two ; Three ; Four ; Five ; Six ; Seven ; Eight; 
                  Nine ; Ten ; Jack ; Queen ; King ; Ace ]
    let suits = [ Clubs; Diamonds;  Spades; Hearts ]
    
    let mutable cardList = []

    for rank in ranks do 
        for suit in suits do 
            cardList <-  cardList @ [ Card(rank, suit) ]

    Deck(cardList)

let sortDeck (deck: Deck) = 
    let (Deck(cardList)) =  deck
    Deck(List.sortBy (fun _ -> Guid.NewGuid().ToString()) cardList)


[<EntryPoint>]
let main argv =
    let mutable count = 0 
    let (Deck(cardList)) = createDeck() |> sortDeck
    for card in cardList do 
        count <- count + 1
        let (Card(rank, suit)) = card
        printfn "%d - %A %A " count rank suit

    Console.ReadLine()|> ignore
    0 // return an integer exit code
