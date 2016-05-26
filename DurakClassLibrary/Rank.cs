/**
*
* Class Description: Represents the enumerated ranking of each card rank in a deck of 52 cards (Ace to King).
*
* @author   Nathan Rajkumar
* @version  1.0
* @since    2016-01-24
* @see      Chapter 10 - Definiing Class Members from Beginning Visual C# 2012 Programming
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DurakClassLibrary
{
    public enum Rank : int
    {
        
        Two = 1,
        Three = 2,
        Four = 3,
        Five = 4,
        Six = 5,
        Seven = 6,
        Eight = 7,
        Nine = 8,
        Ten = 9,
        Jack = 10,
        Queen = 11,
        King = 12,
        Ace = 13,
        Joker = 14
    }
}