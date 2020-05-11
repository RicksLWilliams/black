using System;

namespace black
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      Console.WriteLine("Hello World!");
      bool playing = true;
      int gamesPlayed = 0;
      int gamesWon = 0;
      int gamesLost = 0;
      int gamesTied = 0;
      int playerTotal = 0;
      int dealerTotal = 0;
      int dealerAces = 0;
      int dealerDisplay = 0;
      int numAces = 0;
      int displayTotal = 0;
      Random random = new Random();
      int computerChoice = 0;
      string[] computerCards = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
      int[] computerValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };

      while (playing)
      {
        System.Console.WriteLine("Would you like to play a game? Y/N");
        string userInput = Console.ReadLine();
        playing = userInput.ToLower() == "y";
        if (playing)
        {
          playerTotal = 0;
          numAces = 0;
          displayTotal = 0;

          gamesPlayed++;
          computerChoice = random.Next(0, 13);
          System.Console.WriteLine($"First Card {computerCards[computerChoice]}");
          playerTotal += computerValues[computerChoice];
          if (computerChoice == 0)
          {
            numAces++;
          }

          computerChoice = random.Next(0, 13);
          System.Console.WriteLine($"Second Card {computerCards[computerChoice]}");
          playerTotal += computerValues[computerChoice];
          if (computerChoice == 0)
          {
            numAces++;
          }
          if (numAces > 0)
          {
            displayTotal = playerTotal + 10;
          }
          else
          {
            displayTotal = playerTotal;
          }

          System.Console.WriteLine($"Your Total is {displayTotal}");
          System.Console.WriteLine("(H)it or (S)tand");
          string choice = Console.ReadLine();
          if (choice.ToLower() != "h" & choice.ToLower() != "s")
          {
            System.Console.WriteLine("invalid selection");
            continue;
          }

          if (choice.ToLower() == "h")
          {
            System.Console.WriteLine("player draw card");
            computerChoice = random.Next(0, 13);
            System.Console.WriteLine($"next Card {computerCards[computerChoice]}");
            playerTotal += computerValues[computerChoice];
            if (computerChoice == 0)
            {
              numAces++;
            }
            if (numAces > 0)
            {
              displayTotal = playerTotal + 10;
            }
            else
            {
              displayTotal = playerTotal;
            }

            System.Console.WriteLine($"Your Total is {displayTotal}");
            choice = "s";
            //continue;
          }

          if (choice.ToLower() == "s")
          {
            System.Console.WriteLine(" dealer draw card");
            dealerTotal = 0;
            dealerAces = 0;
            dealerDisplay = 0;

            while ((dealerTotal < playerTotal) & (dealerTotal < 21) & (playerTotal < 21))
            {
              computerChoice = random.Next(0, 13);
              System.Console.WriteLine($"Dealer Card {computerCards[computerChoice]}");
              dealerTotal += computerValues[computerChoice];
              if (computerChoice == 0)
              {
                dealerAces++;
              }
              if (dealerAces > 0 & dealerDisplay < 12 )
              {
                dealerDisplay = dealerTotal + 10;
              }
              else
              {
                dealerDisplay = dealerTotal;
              }

              System.Console.WriteLine($"Dealer Display total is {dealerDisplay}");
              //System.Console.WriteLine($"Dealer Total is {dealerTotal}");
              //System.Console.WriteLine($"player Total is {playerTotal}");
              System.Console.WriteLine("--");

            }
            if (playerTotal > 21 )
            {
                System.Console.WriteLine($"player bust, you lose");
                gamesLost++;
            }
            else if (dealerTotal > 21 )
            {
                System.Console.WriteLine($"Dealer bust, you win");
                gamesWon++;
            }
            else if (dealerTotal == playerTotal )
            {
                System.Console.WriteLine($"push, you tied");
                gamesTied++;
            }
            else if (dealerTotal > playerTotal )
            {
                System.Console.WriteLine($"you lose");
                gamesLost++;
            }           
            else if (dealerTotal < playerTotal )
            {
                System.Console.WriteLine($"you win");
                gamesWon++;
            }
            else
            {
              System.Console.WriteLine($"this should never happen");  
            }

            continue;
          }

        }
      }
      System.Console.WriteLine("Thanks for playing!");
      System.Console.WriteLine($"You played {gamesPlayed} games {gamesWon} / {gamesLost} / {gamesTied}");

    }
  }
}
