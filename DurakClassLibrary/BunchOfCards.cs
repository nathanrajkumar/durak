using System;
using System.Collections;  // cards collection uses System.Collections library....
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{
    public class BunchOfCards : List<Card>//,  ICloneable
    {

        /// <summary>
        /// Utility method for copying card instances into another Cards
        /// instance—used in Deck.Shuffle(). This implementation assumes that
        /// source and target collections are the same size.
        /// </summary>
        public void CopyTo(BunchOfCards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }

        // now we need to clone every card object object in the original collection. How? Make a DEEP COPY. 
        //public object Clone()
        //{
          //  BunchOfCards newCards = new BunchOfCards();  // instantiate new cards object (where the card objects are going to be)
           // foreach (Card sourceCard in this)  // for each source card (see shuffle) in the List
           // {
           //     newCards.Add((Card)sourceCard.Clone());  // add card object to the newCard Cards object whilst making clones of each card
          //  }
          //  return newCards;  // return the newCards object
        //}


    }

}
