using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{


    public class Computer : Player
    {
        String name;
        int number;
        Hand hand;
        int trumpNumber;
        bool attacker;
        bool canPlay;


        public Computer(String compName, Hand computerHand, int compPlayerNumber)
        {
            name = compName;
            hand = computerHand;
            number = compPlayerNumber;
        }



        

        /// <summary>
        /// used for explicity returning a name when getName is called from the interface
        /// </summary>
        /// <returns> the name of the player</returns>
        String getName()
        {
            return name;
        }

        /// <summary>
        /// used for explicitly returning a hand when getHand is called from the interface
        /// </summary>
        /// <returns>the current list of hand objects in the players hand</returns>
        Hand getPlayerHand()
        {
            return hand;
        }


        /// <summary>
        /// used for explicitly returning the player number when getPlayerNumber is called from the interface
        /// </summary>
        /// <returns>the player number associated with the player</returns>
        int getPlayerNumber()
        {
            return number;
        }

        bool getAttackStatus()
        {
            return IsAttacker;
        }

        // to play after human plays an attacking card
        /// <summary>
        /// check the attacking card, if the attacking card value is less than the defending card value, play card in hand
        /// </summary>
        /// <param name="attackerCard"></param>
        public bool CheckAttackCard(int attackValue)
        {
            for (int i = 0; i < hand.Count; i++)
            {
                if (attackValue < hand[i].CardValue)
                {
                    //hand.PlayCard(hand[i]);
                    canPlay = true;
                }
                else
                {
                    canPlay = false;
                }
            }

            return canPlay;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="defenderCard"></param>
        public void CheckDefenderCard(Card defenderCard)
        {
            for (int i = 0; i < hand.Count; i++)
            {
                if (defenderCard.CardValue < hand[i].CardValue)
                {
                    hand.PlayCard(hand[i]);
                    break;
                    // dependant on attacker or defender, cbxP1.PerformClick() or cbxP2.PerformClick()
                }
            }
        }

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

        // return the number of trump in the playing field, do this in the form

    }
}
