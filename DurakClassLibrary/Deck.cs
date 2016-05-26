using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DurakClassLibrary
{
    public class Deck : BunchOfCards // A deck is a bunch of cards
    {


        #region "FIELDS AND PROPERTIES"

        /// <summary>
        /// protected field for gaining access to the specific card object Joker
        /// </summary>
        protected bool joker;

        /// <summary>
        /// set/get acesss to the Joker card. Include in deck.
        /// </summary>
        public bool checkJokers
        {
            get
            {
                return joker;
            }
        }

        private Suit getTrumpSuit;

        
            
            //    set
        //    {
        //        // if the deck contains the jokers return true, otherwise, return false
        //        bool jokerIsInDeck = false;
        //        int cardPosition = 0;


        //        // for every card object in the list, check the rank in each card to see if the joker exists 
        //        for (int i = 0; i < cards.Count; i++)
        //        {
        //            if (cards[cardPosition].getRank == Rank.Joker)
        //            {
        //                jokerIsInDeck = true;
        //            }
        //            else
        //            {
        //                jokerIsInDeck = value;
        //            }
        //        }
        //    }
        

        // this indexer is a special property that allows the Deck class to access the deck list through a subscript. Essentially, it 
        // will get the position specified at cardIndex in the Card List.  

        //public Card this[int cardIndex]
        //{
        //    get
        //    {
        //        // foe each card in the deck, check to make sure the index number you want to pull off does not equal to the same index number int he list
        //        // what is a deck but a list of cards?  
               


        //        return (Card)List[cardIndex]; // Originally, the list property has to return an object.  So what we're doing here is 
        //        // were casting the number at Card Index in the List as a whole Card Object.  So instead
        //        // of return a numebr it returns an object. 
        //    }
        //    set
        //    {
        //        List[cardIndex] = value;  // list at position cardIndex equal to the value that gets sent
        //    }
        //}

        #endregion


        #region "PUBLIC METHODS"

       // public BunchOfCards cards;   // instantiates new ArrayList of Cards object called cards

        // used for cloning deck.  Generic clone used for multiple decks.
        //public object Clone()
        //{
        //    return this.MemberwiseClone(); // becasue there are no class types.  You can simply return a memberwise clone.  Implements ICloneable interface.
        //}

        // deck class will maintain 52 card objects. This is a generic abstract class used to define a standard deck.  The talon class
        // will inherit from this abstract class and will concretize the logical data listed here.  To do this, use a simple array.  This array will NOT be accesible UNLESS you
        // use a use a getCard() method which will return a card at a given index.  This class will also use a Shuffle method to 
        // rearrange cards in the array.

        //public List<Card> cards;  // declaration of list...

        /// <summary>
        /// method to return the number of cards in a deck
        /// </summary>
        public Deck(bool hasJoker = false) 
        {
            // once the lsit is instantiated, then the magic can begin....
           // cards = new BunchOfCards();  // instantiate new List object that only accepts Card objects
            // once the slots are there, begin to fill the deck with card objects, referenced from the Card class using a for loop.
            joker = hasJoker;
            Initialize();
        }

        virtual public void Initialize()
        {
            // start a for loop, for suits
            for (Suit suitVal = Suit.Clubs; suitVal <= Suit.Hearts; suitVal++)     // iterate through the suits...
            
            {
                for (Rank rankVal = Rank.Two; rankVal <= Rank.Ace; rankVal++)   // at the same time, iterate through the ranks...
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

            if (joker)
            {
                this.Add(new Card(Suit.Clubs, Rank.Joker));
                this.Add(new Card(Suit.Hearts, Rank.Joker));
            }

        }

        public Card Draw()
        {
            // the card to draw at position 0 (first position) in deck
            Card drawnCard = this[0];
            // remove that card from deck. NOTE: the cardToDraw still exists in memory. It has not gone to gardbage collection because it still makes reference.
            // This particular card will be added to the hand object 
            this.Remove(drawnCard);
            return drawnCard;

        }


        // GET CARD - use this for displaying cards to the console window
        // this method returns a card at a specified index.  If it cant find a card, it will throw an exception...
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum < this.Count)
                return this[cardNum];
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and 35"));
        }


        // The shuffle function will instantiate a new deck of cards.  It will then copy the cards from the existing card 
        // array and place into the new array at random (dependant on the random number it generated). The sole function of 
        // this shuffle array is to loop 52 times from 0 to 51.  Each cycle will produce a number between 0 and 51 using the random
        // function. Then, using the .Next(x) method, the function will generate a random number between 0 and x. This number will 
        // then assign that id to slot in the new array. 


        // WHAT DO I WANT THIS TO DO?  

        // REPEAT STEP ONE AN ARBITRARY NUMBER OF TIMES (SAY 5?)

        // STEP ONE:
        // while deck (!empty)
        // PICK A RANDOM INDEX
        // PICK A RANDOM NUMBER OF CARDS TO PULL FROM THE OLD DECK
        // MAKE SURE THE NUMBER OF CARDS YOU WANT TO PULL DOESNT EXCEED THE SIZE OF THE OLD DECK (CARDS TO PULL < DECK.SIZE).  IF SO, THEN
        // ADD THE LAST CARDS FROM THE OLD DECK TO THE TOP OF THE NEW DECK 
        // ADD # OF CARDS TO PULL TO THE TOP OF NEW DECK LIST AND REMOVE FROM OLD DECK LIST
        // STEP TWO:
        // MOVE ALL CARDS FROM NEW DECK LIST BACK TO OLD DECK LIST IN ORDER (FOR LOOP TO ITERATE THROUGH THE NEW DECK LIST AND FILL THE OLD DECK LIST)  


        public void Shuffle()
        {
            

            BunchOfCards newDeck = new BunchOfCards();  // ArrayList called newDeck to hold a Cards object (essentially a bunch f card objects)
            //Card[] newDeck = new Card[52];  // temporary card array for original deck of cards to be copied into
            bool[] assigned = new bool[this.Count];  // array of boolean variables to flag whether a card exists at that index
            Random sourceGen = new Random();  // instantated random number using Random class
            for (int i = 0; i < this.Count; i++)  // iterate through all 52 card objects...
            {
                int sourceCard = 0;  // iterator 
                //int destCard = 0;  // container to hold the randomly generated number used for the index
                bool foundCard = false;   // flag to see if the card exists, defaulted to false
                while (foundCard == false)  // while the flag has not found a card in that slot
                {
                    sourceCard = sourceGen.Next(this.Count);  // iterate through 52 cards and assign a random number
                    if (assigned[sourceCard] == false)  // if there is no card in that slot in the boolean array
                        foundCard = true;               // set the found statement to true
                                                        //destCard = sourceGen.Next(52);  // generate a random number to 52
                                                        //if (assigned[destCard] == false)  // if the spot in the assigned array is empty at the index of the randomly generated number
                                                        //  foundCard = true;  // raise that index spots flag to true 
                }
                assigned[sourceCard] = true;  // once the boolean array all equals true.....
                newDeck.Add(this[sourceCard]);  // add the cards iterating through all 52 card objects and add them tot he ArrayList
                //assigned[destCard] = true; // set the assigned card array to true
                //newDeck[destCard] = cards[i];  // slot that created card object into the cards array at that index
            }

            //newDeck.CopyTo(cards, 0);  // once all the cards have been created, copy the cards from the temp array to the cards array
            newDeck.CopyTo(this);  //copy new deck to cards deck for use in play

        }

        private void AddRange(List<Card> newDeck)
        {
            throw new NotImplementedException();
        }

        public void DealCards()
        {
            // at this point, the deck has been made, so this function is to deal cards to players in the form of hands.  Initial deal
            // is six cards.  Afterwards, the player has the option to pick up cards if their hand is less than six cards.

            //Card[] hand = new Card[6];  // this is a hand array (but its not dynamic)

     //       List<Card> handList = new List<Card>();     // this is a empty list of card objects 
            while (this != null)
            {
                this.Draw();
            }
     

        }

        // generically, you want to be able to add a card to the deck.  Durak specific though, I dont think you need to, but its good to 
        // implement. This stores the card object to the END of the Deck regardless of card.  This could be used for Trump placement after
        // assigning Trump which is assigned after dealing.  Errr...wait, does that make a new card object and add it to the deck.  As in 
        // the deck now contains 53 cards with two of the same cards??  If so, then use the Insert instead

        //public void Add(Card newCard)
        //{
        //    // you can use list, give gives you access to the array list that stores the items.  
        //    List.Add(newCard);

        //}

        // other list methods needed for generic deck class


        // removes the FIRST occurance of a card from a deck.  Needed for draw card?
        //public void Remove(Card deckCard)
        //{
        //    List.Remove(deckCard);
        //}

        // determines whether the Deck contains a specific card.  Returns a number value for the index of the specific card you were 
        // looking for. Generic Deck method, probably wont need it for Durak spcific gameplay

        //public int IndexOf(Card specificCard)
        //{
        //    return List.IndexOf(specificCard);
        //}

        // Insert a card into the Deck at a specified index.  Needed for putting the Trump at the bottom of the deck.

        //public void Insert(int specifiedIndex, Card newCard)
        //{
        //    List.Insert(specifiedIndex, newCard);
        //}

        //// what would you use a .contains for? It checks to see whether the deck contains a specific card and returns a 
        //// true/false boolean.  Assumedly, you wouldn't need to check to see if a deck contains a specific card.  Hand maybe
        //// to check if the your hand has trump suits.  Or speaking more generically, check to see if the deck contains a Joker?

        //public bool Contains(Card aCard)
        //{
        //    return List.Contains(aCard);
        //}

          
        
        /// <summary>
        /// Set the suit of the first card of the deck after dealing as trump.  From here on in, that card value is higher than an ace
        /// </summary>
        /// <param name="firstCardinDeck"></param>
        /// <returns></returns>
        public Suit SetTrump(Card firstCardinDeck)
        {
            // get the trump suit of the first card in the deck 
            getTrumpSuit = firstCardinDeck.Suit;

            return getTrumpSuit;
        }


    }

        #endregion

    }
       
 

