using System;





namespace ProjectPartB_B1
{
    class Program
    {
        static void Main(string[] args)
        {
            DeckOfCards myDeck = new DeckOfCards();
            myDeck.CreateFreshDeck();
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);





            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            myDeck.Sort();
            Console.WriteLine(myDeck);





            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            myDeck.Shuffle();
            Console.WriteLine(myDeck);
            Console.WriteLine("Lets play a game of highest card with two players.");













            //Your code to play the game comes here
            //steg 7
            int numCardsToGet = Askforcards();





            //steg 8
            int numRoundsToPlay = AskForRounds();







            //steg 9
            int round = 0;
            while (round < numRoundsToPlay)
            {
                HandOfCards player1 = new HandOfCards();// steg 14 jag flyttade ner dom hhär för att inte ta tillbaka kortet på varje runda.
                HandOfCards player2 = new HandOfCards();
                round++; // Öka omgångsnumret med 1 för varje omgång
                Console.WriteLine($"Round Nr: {round}");
                Deal(myDeck, numCardsToGet, player1, player2);
                DetermineWinner(player1, player2);
            }









        }





        static int Askforcards()
        {
            //steg 7
            int nrOfCards;
            while (true)
            {





                Console.WriteLine("How many cards do you want (1-5)? ");
                if (int.TryParse(Console.ReadLine(), out nrOfCards) && nrOfCards >= 1 && nrOfCards <= 5)
                {
                    return nrOfCards;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
            }
        }
        static int AskForRounds()
        //steg 8
        {
            int nrOfRounds;
            while (true)
            {
                Console.WriteLine("How many rounds do you want to play (1-5)? ");
                if (int.TryParse(Console.ReadLine(), out nrOfRounds) && nrOfRounds >= 1 && nrOfRounds <= 5)
                {
                    return nrOfRounds;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
            }
        }









        /// <summary>
        /// Asking a user to give how many cards should be given to players.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfCards">Number of cards given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfCards(out int NrOfCards)
        {
            NrOfCards = 0;
            return false;
        }
        int numCardsToGet = Askforcards();





        /// <summary>
        /// Asking a user to give how many round should be played.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfRounds">Number of rounds given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>





        private static bool TryReadNrOfRounds(out int NrOfRounds)
        {
            NrOfRounds = 0;
            return false;
        }







        /// <summary>
        /// Removes from myDeck one card at the time and gives it to player1 and player2. 
        /// Repeated until players have recieved nrCardsToPlayer 
        /// </summary>
        /// <param name="myDeck">Deck to remove cards from</param>
        /// <param name="nrCardsToPlayer">Number of cards each player should recieve</param>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2)
        {
            //steg 11
            for (int i = 0; i < nrCardsToPlayer; i++)
            {
                PlayingCard cardToGive = myDeck.RemoveTopCard();



                if (cardToGive != null)
                {
                    player1.Add(cardToGive);
                    Console.WriteLine($"Gave 1 card to Player 1: {cardToGive}");
                }



            }



            for (int i = 0; i < nrCardsToPlayer; i++)
            {
                PlayingCard cardToGive2 = myDeck.RemoveTopCard();
                if (cardToGive2 != null)
                {
                    player2.Add(cardToGive2);
                    Console.WriteLine($"Gave 1 card to Player 2: {cardToGive2}");
                }
            }



            Console.WriteLine($"The deck now has {myDeck.Count} cards.");
            Console.WriteLine($"Player 1 hand with {player1.Count} cards: ");
            



            Console.WriteLine($"Player 2 hand with {player2.Count} cards: ");
            Console.WriteLine(player1);
            Console.WriteLine(player2);
        }





        /// <summary>
        /// Determines and writes to Console the winner of player1 and player2. 
        /// Player with higest card wins. If both cards have equal value it is a tie.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void DetermineWinner(HandOfCards player1, HandOfCards player2)
        {



            // steg 15 skriva jag ut högsta och lägsta kort på båda spelare här.
            Console.WriteLine($"Highest card in hand player1 is {player1.Highest}");
            Console.WriteLine($"Lowest card in hand player1 is {player1.Lowest}");




            Console.WriteLine($"Highest card in hand player2 is {player2.Highest}");
            Console.WriteLine($"Lowest card in hand player2 is {player2.Lowest}");



            // steg 16 sista steget är att jag använda en if för att jämföra kort på båda spelare vilka som vinner eller lika
            if (player1.Highest.CompareTo(player2.Highest) > 0)
                Console.WriteLine("Player1 win!");



            if (player1.Highest.CompareTo(player2.Highest) < 0)
                Console.WriteLine("Player2 win!");



            if (player1.Highest.CompareTo(player2.Highest) == 0)
                Console.WriteLine("Tie!");







        }
    }
}