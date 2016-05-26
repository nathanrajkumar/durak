using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{
    public class PlayField : BunchOfCards
    {

        int FIELD_LIMIT = 12;

        bool isWin = false;

        List<Card> removedCards;

        /// <summary>
        /// default constructor - you can have an empty play field
        /// </summary>
        public PlayField()
        {
            
            
        }

        public void AddCard(Card playedCard)
        {
            if (this.Count <= FIELD_LIMIT)
            {
                this.Add(playedCard);
            }
            else
            {
                Console.WriteLine("You can't play more than " + FIELD_LIMIT + " cards in a game field");
            }
        }

        public bool Bout(Card attackingCard, Card defendingCard, Suit trump)
        {
            int attackValue = attackingCard.CheckTrump(trump) ? attackingCard.CardValue + (int)Rank.Ace : attackingCard.CardValue;
            int defendValue = defendingCard.CheckTrump(trump) ? defendingCard.CardValue + (int)Rank.Ace : defendingCard.CardValue;


            if (attackValue > defendValue)
            {
                isWin = true;
                Console.WriteLine("ATTACKER WIN!!! PERFECT!!");
                
            } else if (attackValue == defendValue)
            {
                Console.WriteLine("DRAW!!");
            } else
            {
                isWin = false;
                Console.WriteLine("DEFENDER WINS!!!");
            }

            return isWin;
        }
        
        public List<Card> TakeItAll(Card attackingCard, Card defendingCard)
        {
            removedCards = new List<Card>();
            // copy cards 
            //attackingCard.Clone();
            //defendingCard.Clone();
            
            // remove all the cards from the playfield
            this.Remove(attackingCard);
            this.Remove(defendingCard);

            // add to list
            removedCards.Add(attackingCard);
            removedCards.Add(defendingCard);

            return removedCards;
        }
    }
}
