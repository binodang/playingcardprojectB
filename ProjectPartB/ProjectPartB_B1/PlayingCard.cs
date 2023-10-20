using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ProjectPartB_B1
{
    public class PlayingCard : IComparable<PlayingCard>, IPlayingCard
    {
        public PlayingCardColor Color { get; init; }
        public PlayingCardValue Value { get; init; }



        #region IComparable Implementation
        //Need only to compare value in the project
        public int CompareTo(PlayingCard card1)
        {
            //steg 13
            if (Value > card1.Value)
                return 1;
            else if (Value < card1.Value) return -1; else return 0;
        }
        #endregion



        #region ToString() related
        string ShortDescription
        {
            //Use switch statment or switch expression
            //https://en.wikipedia.org/wiki/Playing_cards_in_Unicode
            get
            {
                // steg 1 Skapar symboler för kortfärgerna.
                char[] symbols = new char[] { '\u2663', '\u2666', '\u2665', '\u2660' };// ♠	♥ ♦ ♣
                // Kombinerar rätt symbol (baserat på kortets färg) med kortets Value och returnerar den korta beskrivningen.
                return symbols[(int)Color] + Value.ToString();
            }
        }



        public override string ToString() => ShortDescription;
        #endregion
    }
}