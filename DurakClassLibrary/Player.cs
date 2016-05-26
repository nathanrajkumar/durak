using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{
    /// <summary>
    /// This class won't get used in the GUI version as player objects will be loaded on form load anyway. But for debug purposes,
    /// its made to test player functionality.
    /// </summary>
    public class Player : IPlayer
    {
        /* THIS IS WHAT I WANT THIS CLASS TO DO:
                1. EMPTY CONSTRUCTOR TO INITALIZE A NEW PLAYER 
                2. PARAMETERIZED CONSTRUCTOR TO INITIALIZE A NEW PLAYER PASSING IN NAME, PLAYER HAND, PLAYER NUMBER ASSOCIATED WITH THAT PLAYER 
        
        */

        // FIELDS

        String name;
        Hand hand;
        int number;
        bool attacker;
        bool focus;
        Talon talon;
        bool victory = false;

        // CONSTRUCTORS

        /// <summary>
        /// default constructor - might not need this, but code for later in case
        /// </summary>
        public Player()
        {

        }

        /// <summary>
        /// constructor to pass in a name, hand object and player number (name, handlist, 1)
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="playerHandInPlay"></param>
        /// <param name="numberofPlayers"></param>
        public Player(String playerName, Hand playerHandInPlay, int playerNumberOfPlayer)
        {
            name = playerName;
            hand = playerHandInPlay;
            number = playerNumberOfPlayer;
            //attacker = false;
        }

        // EXPLICIT INTERFACE MEMBER IMPLEMENTATION

        /// <summary>
        /// used for explicity returning a name when getName is called from the interface
        /// </summary>
        /// <returns> the name of the player</returns>
        String IPlayer.getName()
        {
            return name;
        }
        
        /// <summary>
        /// used for explicitly returning a hand when getHand is called from the interface
        /// </summary>
        /// <returns>the current list of hand objects in the players hand</returns>
        Hand IPlayer.getPlayerHand()
        {
            return hand;
        }

        
        /// <summary>
        /// used for explicitly returning the player number when getPlayerNumber is called from the interface
        /// </summary>
        /// <returns>the player number associated with the player</returns>
        int IPlayer.getPlayerNumber()
        {
            return number;
        }

        bool IPlayer.getAttackStatus()
        {
            if (IsAttacker == true)
            {
                Console.WriteLine("ATTACKER");
                return true;
                
            }
            else
            {
                Console.WriteLine("DEFENDER");
                return false;
                
            }

            //return IsAttacker;
        }

        /// <summary>
        /// refill hand 
        /// </summary>
        /// <param name="numberOfCardsToDraw"></param>
        /// <param name="gameTalon"></param>
        public void RefillHand(int numberOfCardsToDraw, Talon gameTalon)
        {
            for (int i = 0; i < numberOfCardsToDraw; i++)
            {
                gameTalon.Draw();
            }
        }

        
        /// <summary>
        /// WIN CONDITION - Each player has a win condition....1. Deck is empty 2. Hand is empty.  If Victory, set game over to true.
        /// </summary>
        /// <returns></returns>
        public bool CheckVictory()
        {
            if (talon.Count == 0 && hand.Count == 0)
            {
                victory = true;
            }
            return victory;
        }

        /// <summary>
        /// is this player an attacker, return true
        /// </summary>
        public bool HasFocus
        {
            get
            {
                return focus;
            }
            set
            {
                focus = value;
            }
            

            // attacker goes first, how do I do that?
        }

        /// <summary>
        /// is this player a defender, return false
        /// </summary>
        public bool IsAttacker
        {
            get
            {
                return attacker;
            }
            set
            {
                attacker = value;
            }
        }

        /// <summary>
        /// is the player is an attacker, dont make him one anymore.
        /// </summary>
        public bool ChangeTurns()
        {
            
            return attacker = !attacker;
            //if (attacker == true)
            //{
            //    attacker = false;
            //}
            //else if (attacker == false)
            //{
            //    attacker = true;
            //} 


            //return attacker;
        }


        /// <summary>
        /// ToString - overridden string to create human readable output
        /// </summary>
        /// <returns></returns>

        public override string ToString()  // overrides the system.object toString method...(mainly for output purposes)
       {
           return "PLAYER NAME: " + name + "\nNUMBER OF CARDS IN HAND LIST: " + hand.Count + "\nPLAYER NUMBER: " + number;
       }
       
    }
}
