using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{
    public class Talon : Deck
    {
        public override void Initialize() 
        {
            
            
            // once the lsit is instantiated, then the magic can begin....
           // cards = new BunchOfCards();  // instantiate new List object that only accepts Card objects
            // once the slots are there, begin to fill the deck with card objects, referenced from the Card class using a for loop.

            joker = false;

            // start a for loop, for suits
            for (Suit suitVal = Suit.Clubs; suitVal <= Suit.Hearts; suitVal++)     // iterate through the suits...
            
            {
                for (Rank rankVal = Rank.Six; rankVal <= Rank.Ace; rankVal++)   // at the same time, iterate through the ranks...
                {
                    // suit value is multiplied by 9 because each suit is iterated 9 times (ace, six, seven, eight, nine, ten, jack ,queen, king)
                    // rank value is subtracted by one because rank was started at one and iterated 13 times...
                    // so for example, spades [0] * 9 = 0 + 1 (Ace) - 1 = 0 (card object created at position 0 is Ace of Spades)
                    //cards[suitVal * 9 + rankVal - 1] = new Card((Suit)suitVal, (Rank)rankVal);

                    // add new cards to the deck based on suit value and rank value and turn it into an enumeration
                    this.Add(new Card(suitVal, rankVal));
                    //Console.WriteLine(cards.ToString());
                    
                }
            }
        }

    }

    
}
//        // fields: talon, trumpPosition

//        // properties: cards remaining, empty, trumpReached, this

//        // methods: Talon(), Clone(), DrawCard(), LoadTalon(), Shuffle()

//        // what do I want this class to do?  I want it to start at the enumerator of rank 5 and run through each enumerator and fill a talon with card objects


//        public List<Card> talonCards;

//        public Talon()
//        {
//            talonCards = new List<Card>();
//            // run through the whole talon list, START AT ENUMERATOR 5 TO 13, fill talon

//            //for (int listIndex = 0; listIndex < talonCards.Count; listIndex++) 
//            //{
//            for (int suitVal = 0; suitVal <= 3; suitVal++)
//            {
//                for (Rank rankVal = Rank.Six; rankVal <= Rank.Ace; rankVal++)
//                {
//                    talonCards.Add(new Card((Suit)suitVal, (Rank)rankVal));
//                    //Console.WriteLine((Rank)rankVal); // debug
//                    //Console.WriteLine((Suit)suitVal); // debug
//                    //Console.WriteLine(cards);


//                    // debug proves that cards are generated in order per suit using the Talon class
//                }
//            }
//            //}




//        }

//        // GET CARD - use this for displaying cards to the console window
//        // this method returns a card at a specified index.  If it cant find a card, it will throw an exception...
//        public Card TalonGetCard(int cardNum)
//        {

//            int MIN_CARD_INDEX = 0;
//            int MAX_CARD_INDEX = 35;

//            if (cardNum >= MIN_CARD_INDEX && cardNum <= MAX_CARD_INDEX)
//                return talonCards[cardNum];
//            else
//                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between " + MIN_CARD_INDEX + " and " + MAX_CARD_INDEX));
//        }

//        public void TalonShuffle()
//        {
//            int NUMBEROFTIMESTOSHUFFLE = 1;

//            List<Card> newDeck = new List<Card>();

//            Random generateRandomIndex = new Random();
//            Random generateRandomCardsToPull = new Random();


//            for (int repeatShuffle = 0; repeatShuffle < NUMBEROFTIMESTOSHUFFLE; repeatShuffle++)
//            {
//                while (talonCards.Count != 0)
//                {
//                    // generate mew index number and genernate a random number of cards tp pull out of the old deck 
//                    int blahindex = generateRandomIndex.Next(cards.Count);  // new random index, changd cards.Count to hardcoded 35 -- DEBUG
//                    int cardsToPull = generateRandomCardsToPull.Next(1, 5);  // new random cards to pull, changed to 0 to 1 but wanna add functionality for pulling 3 or 4 cards at a time for efficiency

//                    cardsToPull = cardsToPull + blahindex <= cards.Count ? cardsToPull : cards.Count - blahindex;



//                    // if the cards to pull out of the old deck is greater than the total number iof cards in the old deck.  Throw an exception.
//                    // maybe just add the last cards to the top of the new deck 
//                    if (cardsToPull > cards.Count)
//                    {
//                        throw new ArgumentOutOfRangeException("Can't pull " + cardsToPull + " cards from a deck that only has " + cards.Count + " cards in it");

//                    }
//                    else // otherwise
//                    {
//                        // add new card objects to the new deck list. I dont want to add a new card to the new deck, I want to add an old card from the old deck into the new
//                        // deck. 
//                        //int pull = 1;
//                        //while (blahindex < cards.Count && pull <= cardsToPull)
//                        //{
//                        for (int i = 1; i < cardsToPull; i++)
//                        {
//                            //n throwing exception becuase a card at that random position already exists.  So if cards.outn != cards.IndexOf(cardsIndex) then do the thing
//                            cards.Remove(cards[blahindex]);
//                            Console.WriteLine(cards.Count);
//                            newDeck.Add(cards[blahindex]);
//                            Console.WriteLine(newDeck.Count);
//                            // remove cards pulled from the old deck 

//                        }


//                        //pull++;

//                        //}

//                    }
//                }
//                // copy the new card list into the old list 
//                //cards.AddRange(newDeck);


//                for (int cardsFromNewDeck = 1; cardsFromNewDeck <= newDeck.Count; cardsFromNewDeck++)  // changed cards.Count to hard coded 35 -- DEBUG
//                {
//                    //cards[cardsFromNewDeck].faceUp = true;
//                    newDeck.RemoveAt(cardsFromNewDeck);
//                    // add the cards from the new Deck back to the cards list (old deck) starting from position 0 to the end of the new deck list
//                    cards.Add(newDeck[cardsFromNewDeck]);

//                }


//                // clear the new list for repeated shuffle
//                //newDeck.Clear();
//            }
//        }
//    }
//}
