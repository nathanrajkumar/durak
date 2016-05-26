using System;
using System.Drawing;  // reference added to include System.Drawing.Image

// This is the card object class while instatiates new card objects for use during card games.  Since Durak doesn't have any special rules
// for cards.  It pulls in the rank and suit based on the enumerated rank and suit.  Dont forgt to bild solution before you create a 
// reference to it, otherwise the dll file to this reference does not exist.

namespace DurakClassLibrary
{
    public class Card : ICloneable, IComparable
    {

        #region "FIELDS AND PROPERTIES"

        // readonly because it doesnt make sense to have a "blank" card and cards should be able to change once they have been created...

        // Card attribute 
        protected Rank myRank;  // protected field rank creted from enumerated class Rank
        protected Suit mySuit;  // protected field suit created from enumerated class Suit

        private bool isTrump = false;
        private int trumpCounter;
        

        // properties to access the read only fields. Since its read only, cannot set the fields.

        /// <summary>
        /// Rank Property 
        /// Used to set or get the Rank
        /// </summary>
        public Rank Rank
        {
            get  // accessing the protected field rank
            {
                return myRank;
            }
            set // mutating the protected field rank
            {
                myRank = value;
            }

        }

        /// <summary>
        /// Suit Property
        /// Used to set or get the suit
        /// </summary>
        public Suit Suit
        {
            get // accessing the protected field suit
            {
                return mySuit;
            }
            set // mutating protected field suit
            {
                mySuit = value;
            }

        }

        /// <summary>
        /// Card Value property
        /// Used to set or get the Card Value
        /// </summary>
        protected int myValue;

        public int CardValue
        {
            get
            {
                return myValue;
            }
            set
            {
                myValue = value;
            }
        }

        /// <summary>
        /// Alternate Value property
        /// This is a nullable property as indicated by the question mark.  Most card games wont use this property, thats why its nullable.  You 
        /// dont have to implement it and it returns null.  Null means that it doesnt have a value as opposed to setting it to 0 or -1.
        /// </summary>
        protected int? altValue = null; // nullable type

        public int? AlternateValue
        {
            get
            {
                return altValue;
            }
            set
            {
                altValue = value;
            }
        }
        /// <summary>
        /// FaceUp Property 
        /// Used to set or get whether the card is face up
        /// Set to false by default
        /// </summary>
        public bool faceUp = true;

        public bool FaceUp
        {
            get
            {
                return faceUp;
            }
            set
            {
                faceUp = value;
            }
        }
        #endregion

        #region "CONSTRUCTORS"


        /// <summary>
        /// Card Constructor 
        /// Initializes the playing card object. By default, card is facedown, with no alternate values.
        /// </summary>
        /// <param name="newSuit"></param>
        /// <param name="newRank"></param>

        public Card(Suit suit = Suit.Hearts, Rank rank = Rank.Ace)  // builds card from a supplied suit and rank...
        {
            // set rank and suit
            this.mySuit = suit;   // pass in suit for building card object
            this.myRank = rank;   // pass in rank for building card object

            // set default card values

            this.myValue = (int)rank;  // converetd the card rank to an int Ace will 1, Two will be 2 etc etc

            // CONSTRUCT MAH PRETTIES!!

        }

        #endregion

        #region "RELATIONAL OPERATORS"
        /// <summary>
        /// Operator Overload ( == )
        /// Used to define == operator when comparing two cards
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>left cardvalue == right card value</returns>
        public static bool operator ==(Card left, Card right)
        {
            return (left.CardValue == right.CardValue);
        }

        /// <summary>
        /// Operator Overload ( != )
        /// Used to define != operator when comparing two cards
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>left cardvalue != right card value</returns>
        public static bool operator !=(Card left, Card right)
        {
            return (left.CardValue != right.CardValue);
        }

        /// <summary>
        /// Operator Overload ( < )
        /// Used to define < operator when comparing two cards
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>left cardvalue < right card value</returns>
        public static bool operator <(Card left, Card right)
        {
            return (left.CardValue < right.CardValue);
        }

        /// <summary>
        /// Operator Overload ( <= )
        /// Used to define <= operator when comparing two cards
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>left cardvalue <= right card value</returns>
        public static bool operator <=(Card left, Card right)
        {
            return (left.CardValue <= right.CardValue);
        }

        /// <summary>
        /// Operator Overload ( > )
        /// Used to define > operator when comparing two cards
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>left cardvalue > right card value</returns>
        public static bool operator >(Card left, Card right)
        {
            return (left.CardValue > right.CardValue);
        }

        /// <summary>
        /// Operator Overload ( >= )
        /// Used to define >= operator when comparing two cards
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>left cardvalue >= right card value</returns>
        public static bool operator >=(Card left, Card right)
        {
            return (left.CardValue >= right.CardValue);
        }

        public static int operator +(Card left, Card right)
        {
            return (left.CardValue + right.CardValue);
        }

        #endregion

        #region "PUBLIC METHODS"

        /// <summary>
        /// CompareTo Method
        /// Method needed to implement in order to support IComparable. Card-specific comparison method used to sort Card instances.  
        /// Do you want to sort cards (in Hand) by suit or rank.  What compareTo does is when the sort method is called, it will use 
        /// this compareTo to compare cards for sort.
        /// </summary>
        /// <param name="obj">the object this card is being compared to</param>
        /// <returns>an integer that indicates whether this card precedes, follows or occurs in the sort method</returns>
        public virtual int CompareTo(object obj)
        {
            // is the argument null.  As in NOT a zero or -1?
            if (obj == null)
            {
                // throw arguement is null exception
                throw new ArgumentNullException("Unable to compare a Card to a null object");
            }

            // convert argument to card
            Card compareCard = obj as Card;  // create a new playing card

            // if conversion worked 
            if (compareCard != null)
            {
                // compare based on value first then suit.  In Surak specific, for example, we want to lump all the trump together first 
                // before we organize them by suit.  So if we increase the value of the trump cards, it will lump all the trumps together
                // and then after that, it will sort by suit.  The value is more important than the suit in sorting.
                int thisSort = this.myValue * 10 + (int)this.mySuit;  // value of card * 10 plus suit
                int compareCardSort = compareCard.myValue * 10 + (int)this.mySuit;

                return (thisSort.CompareTo(compareCardSort));  // returns either -1. 0 or 1 value.  Which should come first in a sort?
            }
            else  // other wise the conversion failed
            {
                throw new ArgumentException("Object being compared cannot be converted a Card");
            }
        }  // end of CompareTo

        /// <summary>
        /// Clone Method
        /// To support the ICloneable interface. Used for Deep Copying in Card Collection classes.
        /// </summary>
        /// <returns> a Copy of the Card as a System.Object </returns>
        public object Clone()
        {
            return this.MemberwiseClone(); // becasue there are no class types.  You can simply return a memberwise clone.  Implements ICloneable interface.
        }

        public override string ToString()
        {
            string cardString;  // holds the playing card name 

            // if the card is face up 
            if (faceUp)
            {
                // if the card is a Joker
                if (myRank == Rank.Joker)
                {
                    // set the card name string to (Red|Black) Joker
                    // if the suit is black
                    if (mySuit == Suit.Clubs || mySuit == Suit.Spades)
                    {
                        // set the name string to black joker 
                        cardString = "black_joker";
                    }
                    else  // the suit must be red
                    {
                        //se the name string to red joker
                        cardString = "red_joker";
                    }
                }
                // otherwise, the card is faceup but not a Joker
                else
                {
                    cardString = myRank.ToString() + " of " + mySuit.ToString();
                }
            }
            // otherwise, the card is face down
            else
            {
                // set the card name to face down
                cardString = "Face Down";
            }

            // return the approriate card name string
            return cardString;
        }

        /// <summary>
        /// Equals: overrides System.Object.Equals().  Wants to return whether this objects value is equal to the objects value when I 
        /// type cast it as Playing Card
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true if the card values are equal</returns>
        public override bool Equals(object obj)
        {
            return (this.CardValue == ((Card)obj).CardValue);

        }
        /// <summary>
        /// Equals: Overrides System.Object.GetHashCode(). Hashcode - unique integer value that represents the state of the object.  The state of the card is
        /// represented by the equation.  Also checks to see if its face up. If face up add 1, if not add 0.
        /// </summary>
        /// <returns>card value * 100 + suit number + faceup representation number</returns>
        public override int GetHashCode()
        {
            return this.myValue * 100 + (int)this.mySuit * 10 + ((this.faceUp) ? 1 : 0);

        }
        /// <summary>
        /// GetCardImage()
        /// Get the image associated with the card from the resource file. Determines based 
        /// on the name of a resrouce in my project, what card image shoudl be associated with this card.  It 
        /// is set up much like the ToString() method 
        /// </summary>
        /// <returns>an image corresponding to the playing card</returns>
        public Image GetCardImage()
        {
            string imageName;  // the name of the image in the resources file
            Image cardImage;  // holds the image

            // if the card is not face up
            if (!faceUp)
            {
                // set the image name to "Back
                imageName = "Back"; // set it to the image name for the back of the card
            }
            else if (myRank == Rank.Joker)  // if the card is a Joker
            {
                // if the suit is black
                if (mySuit == Suit.Clubs || mySuit == Suit.Spades)
                {
                    imageName = "black_joker";
                }
                else  // the suit must be red
                {
                    // set the image to red joker
                    imageName = "red_joker";
                }

            }
            else // otherwise, the card is face up and not a joker
            {
                // set the image name to (Suit)_(Rank)
                imageName = mySuit.ToString() + "_" + myRank.ToString();  // enumerations are handy!
            }
            // Set the image to the appropriate object we get from the resource file
            cardImage = Properties.Resources.ResourceManager.GetObject(imageName) as Image;

            // return the image
            return cardImage;
        }

        /// <summary>
        /// DebugString
        /// Generates a string showing the state of the card object; useful for debug purposes.
        /// </summary>
        /// <returns>a string showing the state of the card object</returns>
        public string DebugString()
        {
            // build string based on rank and ruit
            string cardState = (string)(myRank.ToString() + " of " + mySuit.ToString()).PadLeft(20);

            // check whether its face up or face down
            cardState += (string)((FaceUp) ? "(FACE UP)" : "(FACE DOWN").PadLeft(12);

            // output the cards value
            cardState += "Value: " + myValue.ToString().PadLeft(2);

            // check whether it has an alternate value.   If so print out the alternate value
            cardState += ((altValue != null) ? "/" + altValue.ToString() : "");

            // return the card state
            return cardState;
        }

        /// <summary>
        /// This checks you hand to see if the card in your hand is the same as the trump card, if it is, label as trump cards in hand
        /// </summary>
        /// <param name="trumpSuit"></param>
        /// <returns></returns>
        public bool CheckTrump(Suit trumpSuit)
        {
            if (trumpSuit == this.Suit)
            {
                isTrump = true;
                Console.WriteLine("THIS IS TRUMP..." + this);  
            }
            else
            {
                isTrump = false;
                Console.WriteLine("THIS IS NOT TRUMP..." + this); 
            }

            return isTrump;
        }
        
        public int TrumpCounter(Suit trumpSuit)
        {
            if (trumpSuit == this.Suit)
            {
                trumpCounter++;
                
            }

            return trumpCounter;
        }

        public void ConvertToTrump(Suit trumpSuit)
        {
            this.Suit.CompareTo(trumpSuit);
        }

        /// <summary>
        /// returns the rank value for comparison between a regualar card rank and a trump card rank
        /// </summary>
        /// <returns></returns>
        public int GetRankValue()
        {
            return (int)this.Rank;
        }

        #endregion
    }
    /*

    /// <summary>
    /// ToString - overridden string to create human readable output
    /// </summary>
    /// <returns></returns>

    public override string ToString()  // overrides the system.object toString method...(mainly for output purposes)
    {
        return "The " + rank + " of " + suit;
    }
    */

}
   

