using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;





namespace ProjectPartB_B1
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);





        public PlayingCard this[int idx] => cards[idx]; // Här tappade jag vilket steg det är men jag ändrade null till cards[idx]
        public int Count => cards.Count;
        #endregion





        #region ToString() related
        public override string ToString()
        {
            //steg 2 Skapar en tom sträng s.
            string s = "";
            for (int i = 0; i < cards.Count; i++) // Loopar igenom alla kort i kortleken.
            {
                // Lägger till en kortbeskrivning (från PlayingCard.ToString()) och en tabulator ('\t' för att separera mellan korter) till strängen s.
                s += cards[i].ToString() + '\t';
                if ((i + 1) % 13 == 0) //här Om det har nått slutet på en rad med kort (efter varje 13 kort), läggs en ny rad (newline) till.
                    s += System.Environment.NewLine;
            }
            return s; // Returnerar strängen s som innehåller kortleken i en tabellform.
        }
        #endregion





        #region Shuffle and Sorting
        public void Shuffle()
        {
            //steg 4 Skapa en slump.
            Random rnd = new Random();
            int n = cards.Count;
            //jag använder en for-loop för att gå igenom varje position i kortleken (i från 0 till n-1, där n är antalet kort i kortleken).
            for (int i = 0; i < n - 1; i++)
            {
                int randomIndex = rnd.Next(i, n);// Slumpmässigt välj ett index mellan i och n-1.
                // Byt plats på korten vid index i och randomIndex.
                //Temp används som en kortplats för att hålla värdet av ett kort säkert medan två kort byter plats.
                //så att inget värdefullt tappas eller skrivs över. Det hjälper till att byta platser på korten korrekt
                PlayingCard temp = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
                // Inuti loopen slumpmässigt väljer jag ett index randomIndex mellan i och n-1.
                // sen byter jag plats på korten vid index i och randomIndex genom att använda en temporär variabel temp för att utföra bytet.





            }





        }
        public void Sort()
        {
            // steg 5 Skapa en melanlagrad lista för att lagra de sorterade korten.
            List<PlayingCard> sortedCards = new List<PlayingCard>();





            // Gå igenom varje värde (Two till Ace).
            foreach (PlayingCardValue value in Enum.GetValues(typeof(PlayingCardValue)))
            {
                // Gå igenom varje färg (i ordning, om du vill ha en specifik ordning).
                foreach (PlayingCardColor color in Enum.GetValues(typeof(PlayingCardColor)))
                {
                    // Hitta alla kort med det aktuella värdet och färgen och lägg till dem i den sorterade listan.
                    var matchingCards = cards.Where(card => card.Value == value && card.Color == color);
                    sortedCards.AddRange(matchingCards);
                }
            }





            // Ersätt den ursprungliga kortlistan med den sorterade listan.
            cards = sortedCards;
        }





        #endregion





        #region Creating a fresh Deck
        public void Clear()
        {
            // steg 6 Loopa igenom alla kort i kortleken och ta bort dem ett efter ett.
            //jag använder en for-loop som räknar bakåt från det sista kortet i listan till det första.
            for (int i = cards.Count - 1; i >= 0; i--)
            {
                //I varje iteration tar du bort kortet från listan med.
                //Efter att loopen är klar kommer alla kort att ha tagits bort från listan.
                cards.RemoveAt(i);
            }
        }
        public void CreateFreshDeck()
        {
            //steg 3 Återskapar kortleken som en ny lista (Återställ kortleken).
            cards = new List<PlayingCard>(MaxNrOfCards);
            //på den for-loop går igenom färgerna(spader, ruter, hjärter och klöver) genom att använda värdena 0 till 3 i Loop för färger (PlayingCardColor).
            for (int i = 0; i < 4; i++)
            {
                // Den här loopen går igenom valörerna (2 till 14) för varje färg genom att använda värdena 2 till 14 för j.
                for (int j = 2; j < 15; j++)
                {
                    cards.Add(new PlayingCard //// Skapar och lägger till ett nytt PlayingCard-objekt med rätt färg och valör i kortleken.
                    {
                        Color = (PlayingCardColor)i,
                        Value = (PlayingCardValue)j,
                    });
                }
            }
        }
        #endregion





        #region Dealing
        public PlayingCard RemoveTopCard()
        {
            //steg 10
            if (cards.Count > 0)
            {
                PlayingCard topCard = cards[0];
                cards.RemoveAt(0);
                return topCard;
            }
            else
            {
                return null; // Returnera null om det inte finns några kort kvar.
            }
        }
        #endregion
    }
}