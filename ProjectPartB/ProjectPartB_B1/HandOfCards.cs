using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ProjectPartB_B1
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);
        public PlayingCard this[int idx] => cards[idx];
        public int Count => cards.Count;
        #region Pick and Add related
        public void Add(PlayingCard card)
        {
            cards.Add(card);
        }
        #endregion



        #region Highest Card related
        public PlayingCard Highest
        {
            //steg 12
            get
            {
                if (cards.Count == 0)
                {
                    return null;
                }



                PlayingCard currenhighest = cards[0];
                for (int i = 0; i < cards.Count; i++)
                {
                    if (cards[i].CompareTo(currenhighest) > 0)
                    {
                        currenhighest = cards[i];
                    }
                }

                return currenhighest;
            }
        }
        public PlayingCard Lowest
        {
            get
            {
                if (cards.Count == 0)
                {
                    return null;
                }



                PlayingCard currenlowest = cards[0];
                for (int i = 0; i < cards.Count; i++)
                {
                    if (cards[i].CompareTo(currenlowest) < 0)
                    {
                        currenlowest = cards[i];
                    }
                }



                return currenlowest;
            }
        }
        #endregion
    }
}