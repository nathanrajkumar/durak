using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{
    public class Hand : BunchOfCards//, ICloneable  // a hand is also a bunch of cards as well (like a deck)
    {

        private int HAND_LIMIT = 6;
        PlayField gameField;
        //protected List<Card> hand;  // create an empty list of cards (for hand manipulation)

        // default ctor - returns a hand object filled with cards 
        public Hand(Deck gameTalon)
        {

            //Talon newTalon = new Talon();

            //hand = new List<Card>(); // empty list initialized

            for (int i = 1; i <= HAND_LIMIT; i++)
            {

                // draw the first card in the deck, and add to the hand, loop this until it reachses number of cards (aka 6)                
                // DONT CREATE A NEW CARD, RATHER TAKE FROM DECK.DRAW

                this.Add(gameTalon.Draw()); // add instantiated new card object to empty list
            }

            

            //Console.WriteLine("CARDS LEFT IN TALON WHEN HAND CTOR IS CALLED: " + gameTalon.Count);
            //Console.WriteLine("CARD TOTAL IN HAND: " + this.Count);
            //Console.WriteLine("CARDS IN HAND: ");
            /*
            foreach (Card aCard in this) {
                Console.WriteLine(aCard);
            }
            */
        }

        // constructor to build hand with a set number of cards in talon.  I want this to pass the number of cards to fill, and the deck name (aka the talon).
        // How?  Generate a hand list.  loop through the hand list (numberOfCards = 5 for example)
        //public Hand(int numberOfCards, Talon theDeck)
        //{
            

            //

            // loop through the empty hand list and fill with card objects

           
        //}
        
            
            
            // method that returns nothing to add card object to list to a list

            //public void add(Card card)
            //{
            //    hand.Add(card);
            //}
            // used to remove card object from list, returns nothing
            //public void remove(Card card)
            //{
            //    hand.Remove(card);
            //}
            
        
        // after every bout, check (boolean) to see if the player needs to draw (i.e if there hand has less than 6 cards in it), if so return true otherwise return false
        
        
        
        // once we have checked for whether or not they have to draw or not, we have to return the actual number of cards they should draw...
        // In Durak, the magic number of cards to ahve in your hand at all times is six.  However, if you oever six cards in your hand, that 
        // means your good.  If not, you need to draw the appropriate numebr of cards to reach six cards in your hand.  Therefore, really, 
        // its always gonna be 6 cards - the size of your current hand to find the number of cards to draw ONLY if they have less that six cards
        // already (which we found out thanks to the method above).

        public int CardsToDraw() {

            int numberOfCardsToDraw = 0;

            if (this.Count < HAND_LIMIT)
            {
                numberOfCardsToDraw = HAND_LIMIT - this.Count;  
            }
            else
            {
                numberOfCardsToDraw = -1;
            }

            return numberOfCardsToDraw;
            
        }

        // In your hand, you want to be able to retrieve a specific card in your hand in order to play that card or discard it.  Thus,
        // your hand is organized through a position number.  To retrieve a specific card, your going to need a specific index number for that
        // card in your hand.

        // USE handObj[6]  indexer, dont even need indexer, because you've already declared a list in the class header.  That means that THe list will ONLY
        // take card objects.  Thus, you dont need to redeclare saying take this generic list, and make sure it only accepts card objects (cause it already does).

        /*
        public Card this[int cardIndex]
        {
            get
            {
                return (Card)List[cardIndex]; // Originally, the list property has to return an object.  So what we're doing here is 
                                              // were casting the number at Card Index in the List as a whole Card Object.  So instead
                                              // of return a numebr it returns an object. 
            }
            set
            {
                List[cardIndex] = value;  // list at position cardIndex equal to the value that gets sent
            }
        }
        */
        
        /// <summary>
        /// This gets a card in a specific poistion in the hand
        /// </summary>
        /// <param name="position"></param>
        /// <returns> a card </returns>
        public Card GetCard (int position)
        {
            if (position < 0 || position > this.Count)
            {
                throw new ArgumentOutOfRangeException("Requested index in hand does not exist");
            } 
            else
            {
                return this[position];
            }
        }

        // Using a hand, you also want to be able to remove cards at a specified position incase of discard or play.  In this particular case, 
        // remove card from hand at specified position.  In the case of the GUI, card objects will be wired by the use of graphical cards.
        
        /// <summary>
        /// This should retrieve the card that got removed from the hand, CLONE IT, and then add it to the play field list
        /// </summary>
        /// <param name="position"></param>
        public Card PlayCard (Card playCard)
        {
            // remvoe from hand
            this.Remove(playCard);

            //clone card
            //playCard.Clone();

            // add the cloned card to the play field list


            return playCard;
        }

        public int SortByRank(Card compareCardOne, Card compareCardTwo)
        {
                return compareCardOne.Rank.CompareTo(compareCardTwo.Rank);
        }

        public void GetTrump(int position)
        {
           
        }

        public Hand RefillHand(int numberOfCardsToDraw, Talon gameTalon)
        {
            for (int i = 0; i < numberOfCardsToDraw; i++)
            {
                this.Add(gameTalon.Draw());
                
            }
            return this;
        }


        public void AddCards(Card attack, Card defend)
        {
            gameField = new PlayField();
            this.AddRange(gameField.TakeItAll(attack, defend));
            
            
        }


    }
}
