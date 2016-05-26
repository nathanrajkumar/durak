using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{
    public interface IPlayer
    {
        /* THIS IS WHAT IPLAYER SHOULD DO:
            1. GET/SET PLAYER NAME
            2. GET/SET PLAYER HAND
            3. GET/SET PLAYER NUMBER
            4. TO RUN THROUGH THE NUMBER OF PLAYERS FOR THE SAKE OF CREATING HAND OBJECTS ** call the 
               player number to find the number of players playing
        */

        /// <summary>
        /// Method header that takes no arguments and returns a string, Name of the Player
        /// </summary>
        String getName();

        /// <summary>
        /// Method header that takes no arguments and returns a hand object, return hand that player has
        /// </summary>
        Hand getPlayerHand();

        /// <summary>
        /// Method header that takes no arguments and returns a player number associated to that specific player,
        /// return a number to indicate which player number they are either one or two (for now)
        /// </summary>
        int getPlayerNumber();



        bool getAttackStatus();
    }
}
