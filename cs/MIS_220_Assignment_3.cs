using System;

namespace Assignments
{
    class Program
    {

        static void Main(string[] args)
        {
            
            int playerEnergy = 200;
            int opponentEnergy = 200;
            string menuSelection = "";

            while (true)
            {
                ShowMenu();
                menuSelection = Console.ReadLine();
                
                while(menuSelection != "5")
                {
                    switch (menuSelection)
                    {
                        case "1":
                            PlayPickUpSticks(ref playerEnergy, ref opponentEnergy);
                            break;
                        case "2":
                            PlayMotherMayI(ref playerEnergy, ref opponentEnergy);
                            break;
                        case "3":
                            ViewScoreboard(ref playerEnergy, ref opponentEnergy);
                            break;
                        default:
                            Console.WriteLine("Invalid selection.");
                            break;
                    }
                    menuSelection = Console.ReadLine();
                }
            }
           
        }

        static void ShowMenu()
        {
            Console.WriteLine("1. Play Pick Up Sticks");
            Console.WriteLine("2. Play Mother May I");
            Console.WriteLine("3. View Scoreboard");
            Console.WriteLine("4. Restart");
            Console.WriteLine("5. Exit");
            Console.Write("Enter a selection: ");
        }

        static void PlayPickUpSticks(ref int playerEnergy, ref int opponentEnergy)
        {
            string playerInput = "";
            int totalSticks = 0;
            int playerSticks = 0, opponentSticks = 0, playerSticksTotal = 0, opponentSticksTotal = 0;
            bool sticksRemaining = true;
            string winner = "";

            Console.WriteLine("\nPICK UP STICKS\nHow to play:\nChoose the amount of starting sticks. Each player takes a turn picking up 1, 2 or 3 sticks. \nWhoever picks up the last stick is the loser!\n");
            Console.Write("How many sticks will be in the pile? Only 20-100 allowed. >");
            playerInput = Console.ReadLine();

            if (playerInput != "")
            {
                totalSticks = Int32.Parse(playerInput);
            }

            while (totalSticks < 20 || totalSticks > 100 || totalSticks == 0)
            {
                Console.WriteLine("Only between 20 and 100 sticks allowed.");
                Console.Write("\nStarting sticks> ");
                playerInput = Console.ReadLine();
                if (playerInput == "")
                {
                    totalSticks = 0;
                }
                else
                {
                    totalSticks = Int32.Parse(playerInput);
                }
            }

            playerSticks = GetPlayerSticks();
            sticksRemaining = PickUpSticks(playerSticks, ref totalSticks);
            playerSticksTotal += playerSticks;
      
            while (sticksRemaining)
            {

                Console.WriteLine("\nSticks remaining: " + totalSticks);
                Console.WriteLine("\nOpponent moves.");

                Random random = new Random();
                if (totalSticks <= 3)
                {
                    opponentSticks = 1;
                }
                else
                {
                    opponentSticks = random.Next(1, 3);
                }

                Console.WriteLine("Opponent picks up " + opponentSticks + " stick(s).");

                sticksRemaining = PickUpSticks(opponentSticks, ref totalSticks);
                opponentSticksTotal += opponentSticks;
              
                if (totalSticks <= 0)
                {
                    winner = "Player";
                    playerEnergy += playerSticksTotal;
                    opponentEnergy -= playerSticksTotal;
                }
                else
                {

                    Console.WriteLine("\nSticks remaining: " + totalSticks);

                    playerSticks = GetPlayerSticks();
                    sticksRemaining = PickUpSticks(playerSticks, ref totalSticks);
                    playerSticksTotal += playerSticks;

                    if (totalSticks <= 0)
                    {
                        winner = "Opponent";
         
                        opponentEnergy += opponentSticksTotal;
                        playerEnergy -= opponentSticksTotal;
                    }
                }
            }
            Console.WriteLine("\n" + winner + " wins!");
            Console.WriteLine("Player Energy: " + playerEnergy);
            Console.WriteLine("Opponent Energy: " + opponentEnergy);
            Console.WriteLine("\nPlay again? (y = yes, n = no)");
            string choice = Console.ReadLine();
            Console.WriteLine(choice);

            if (choice == "y")
            {
                PlayPickUpSticks(ref playerEnergy, ref opponentEnergy);
            }
            else
            {
                ShowMenu();
            }
        }

        static bool PickUpSticks(int selection, ref int stickCount)
        {
            bool sticksRemaining = true;

                switch (selection)
                {
                    case 1:
                        stickCount -= 1;
                        break;
                    case 2:
                        stickCount -= 2;
                        break;
                    case 3:
                        stickCount -= 3;
                        break;
                }

            if (stickCount <= 0)
            {
                sticksRemaining = false;
            }

            return sticksRemaining;
        }

        static int GetPlayerSticks()
        {
            string playerInput = "";
            int numSticks = 0;
            Console.Write("\nYour turn. Enter number of sticks to pick up: ");
            playerInput = Console.ReadLine();

            if (playerInput != "")
            {
                numSticks = Int32.Parse(playerInput);
            }

            while (numSticks < 1 || numSticks > 3)
            {
                Console.WriteLine("Only 1, 2 or 3 sticks allowed.");
                Console.Write("\nYour turn. Enter number of sticks to pick up: ");
                playerInput = Console.ReadLine();
                if (playerInput != "")
                {
                    numSticks = Int32.Parse(playerInput);
                }
            }
            return numSticks ;
        }

        static void ViewScoreboard(ref int playerEnergy, ref int opponentEnergy)
        {
            Console.WriteLine("Player Energy: " + playerEnergy);
            Console.WriteLine("Children's Energy: " + opponentEnergy);
        }

        static void PlayMotherMayI(ref int playerEnergy, ref int opponentEnergy)
        {
            string playerInput = "";
            string winner = "";
            int playerSteps = 0;
            int playerRoll = 0;
            int opponentSteps = 0;
            int opponentRoll = 0;
            int maxSteps = 21;
            bool stepsRemaining = true;

            Random dieRoll = new Random();

            Console.WriteLine("Press any key to roll the dice: ");
            Console.ReadKey();

            playerRoll = RollDie(dieRoll.Next(0, 9));
            playerSteps += playerRoll;
            playerRoll = RollDie(dieRoll.Next(0, 9));
            playerSteps += playerRoll;
            opponentRoll = RollDie(dieRoll.Next(0, 9));
            opponentSteps += opponentRoll;
            opponentRoll = RollDie(dieRoll.Next(0, 9));
            opponentSteps += opponentRoll;

            while (stepsRemaining)
            {
                Console.WriteLine("\nPlayer steps: " + playerSteps);
                Console.WriteLine("Opponent steps: " + opponentSteps);
                Console.Write("\nRoll again? (y = yes): ");
                playerInput = Console.ReadLine();
                if (playerInput == "y")
                {
                    playerRoll = dieRoll.Next(1, 6);
                    Console.WriteLine("You rolled: " + playerRoll);
                    playerSteps += playerRoll;
   
                    if (playerSteps > 21)
                    {
                        stepsRemaining = false;
                        winner = "Opponent";
                    } 
                    else if (playerSteps == 21)
                    {
                        stepsRemaining = false;
                        winner = "Player";
                    }
                    else if (playerSteps == opponentSteps)
                    {
                        stepsRemaining = false;
                        winner = "Opponent";
                    }
                }
                else
                {
                    if (opponentSteps <= 17)
                    {
                        opponentRoll = dieRoll.Next(1, 6);
                        Console.WriteLine("\nOpponent rolls: " + opponentRoll);
                        opponentSteps += opponentRoll;
                        if (opponentSteps > 21)
                        {
                            stepsRemaining = false;
                            winner = "Player";
                        }
                        else if (opponentSteps == 21)
                        {
                            stepsRemaining = false;
                            winner = "Opponent";
                        }
                    }           
                }
            }
          
            if (winner == "Player")
            {
                Console.WriteLine("\nYou win!");
                playerEnergy += playerSteps;
            }
            else
            {
                Console.WriteLine("\nOpponent wins!");
                playerEnergy -= 21;
                opponentEnergy += opponentSteps;
            }

            Console.WriteLine("\nPlay again? (y = yes)");
            playerInput = Console.ReadLine();
            if (playerInput == "y")
            { 
                PlayMotherMayI(ref playerEnergy, ref opponentEnergy);
            }
            else
            {
                ShowMenu();
            }
        }

        static int RollDie(int roll)
        {
            int result = 0;
            if (roll == 0)
            {
                result = 10;
            }
            else
            {
                result = roll;
            }
     
            return result;
        }

    }
}  

