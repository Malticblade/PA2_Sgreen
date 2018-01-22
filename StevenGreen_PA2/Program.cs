//Steven Green section 2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StevenGreen_PA2
{
    class Program
    {
        public enum hand { Rock = 1, Paper = 2, Scissors = 3, Lizard = 4, Spock = 5 };
        public enum Outcome { Win, Lose, Tie };


        static void Main(string[] args)
        {
            bool gameOver = false, halCount = false;
            var rand = new Random();
            char responce, playerSelect, computerSelect, playerHand , computerHand;
            string playerName, computerName, playerHandName, computerHandName;
            int playerScore = 0, computerScore = 0, i, gameCount = 0, gameSelect = 0;

            while (!gameOver)
            {
                gameCount++;
                Console.WriteLine("Welcome, Please Select Gametype (1 for Singleplayer, 2 for a two players): ");
                gameSelect = Convert.ToInt32(Console.ReadLine());
                if (gameSelect == 2)
                {
                    computerScore = 0;
                    Console.WriteLine("Please Enter your name Player 1: ");
                    playerName = Console.ReadLine();
                    Console.WriteLine("Please Enter your name Player 2: ");
                    computerName = Console.ReadLine();

                    //player 1
                    Console.WriteLine("Please Select from the Following");
                    Console.WriteLine("(R)ock, (P)aper, (S)cissors, (L)izard, or Spoc(K)");
                    playerSelect = Convert.ToChar(Console.ReadLine()); //converts selection to an uppcase char
                    playerHand = char.ToUpper(playerSelect);

                    //player 2
                    Console.Clear();
                    Console.WriteLine("Please Select from the Following");
                    Console.WriteLine("(R)ock, (P)aper, (S)cissors, (L)izard, or Spoc(K)");
                    computerSelect = Convert.ToChar(Console.ReadLine()); //converts selection to an uppcase char
                    computerHand = char.ToUpper(playerSelect);
                }
                else if (gameSelect == 1)
                {
                    Console.WriteLine("Please Enter your name Player 1: ");
                    playerName = Console.ReadLine();
                    Console.WriteLine("Please Enter The Computers Name (HAL 9000 for fun): ");
                    computerName = Console.ReadLine();
                    if (computerName != "HAL 9000")
                    {
                        halCount = false;
                        //player 1 
                        Console.WriteLine("Please Select from the Following");
                        Console.WriteLine("(R)ock, (P)aper, (S)cissors, (L)izard, or Spoc(K)");
                        playerSelect = Convert.ToChar(Console.ReadLine());
                        playerHand = char.ToUpper(playerSelect);

                        //player 2
                        // random Computer Hand
                        i = rand.Next(1, 5);
                        computerSelect = Convert.ToChar(i);
                        computerHand = computerSelect;
                    }
                    else
                    {
                        halCount = true;
                        //player 1 
                        Console.WriteLine("Please Select from the Following");
                        Console.WriteLine("(R)ock, (P)aper, (S)cissors, (L)izard, or Spoc(K)");
                        playerSelect = Convert.ToChar(Console.ReadLine());
                        playerHand = char.ToUpper(playerSelect);
                        computerHand = Convert.ToChar(halSelect(playerHand));

                    }

                    
                }
                else
                {
                    //error out for invalid selection of game
                    Console.WriteLine("Welcome, Please Select Gametype (1 for Singleplayer, 2 for a two players): ");
                    gameSelect = Convert.ToInt32(Console.ReadLine());
                    return;
                }

                //convert and show hands
                //Console.Clear();
                if (halCount == true) 
                {
                    //HAL HAND
                    // automaticaly picks the winning hand
                    playerHandName = getHandNamePlr(playerHand);
                    computerHandName = getHandNameCmp(computerHand);
                    Console.WriteLine("\bGame {0} results", gameCount);
                    Console.WriteLine("\t{0}'s Hand: {1}", playerName, playerHandName);
                    Console.WriteLine("\t{0}'s Hand: {1}", computerName, computerHandName);
                }
                else
                { 
                    playerHandName = getHandNamePlr(playerHand);
                    computerHandName = getHandNameCmp(computerHand);
                    Console.WriteLine("\bGame {0} results", gameCount);
                    Console.WriteLine("\t{0}'s Hand: {1}", playerName, playerHandName);
                    Console.WriteLine("\t{0}'s Hand: {1}", computerName, computerHandName);
                }
                //determinants
                if (DetermineWinner(playerHandName, computerHandName) == Outcome.Win)
                {
                    playerScore++;
                    Console.WriteLine(playerHandName + " beats " + computerHandName + ". ",playerName + " wins!" ,playerName);
                }
                else if (DetermineWinner(playerHandName, computerHandName) == Outcome.Lose)
                {
                    if (halCount == true)
                    {
                        Console.WriteLine(playerName + ", although you took very thorough precautions in the game, I could see you type.  ");
                        computerScore++;
                        Console.WriteLine(computerHandName + " beats " + playerHandName + ". ", computerName + " wins!", playerName);
                    }
                    else
                    {
                        computerScore++;
                        Console.WriteLine(computerHandName + " beats " + playerHandName + ". ", computerName + " wins!", playerName);
                    }
                }
                else if (DetermineWinner(playerHandName, computerHandName) == Outcome.Tie)
                {
                    Console.WriteLine("Tie game!");
                }
                else
                {
                    throw new Exception("Unexpected Error");
                }

                // Console.Clear();
                Console.WriteLine("\bCurrent Score");
                Console.WriteLine("\t{0} = " + playerScore, playerName);
                Console.WriteLine("\t{0} = " + computerScore, computerName);
                Console.WriteLine("\nWould you like to play again (Y or N)? ");
                responce = Convert.ToChar(Console.ReadLine());
                responce = char.ToUpper(responce);

                while (responce != 'Y' && responce != 'N')
                {
                    Console.WriteLine("INVALID SELECTION");
                    responce = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine("\nWould you like to play again (Y or N)? ");
                    responce = Convert.ToChar(Console.ReadLine());
                    responce = char.ToUpper(responce);
                }
                if (responce == 'N')
                {//gameover
                    gameOver = true;
                    //Console.Clear();
                    if (halCount == true)
                    {
                        Console.WriteLine(playerHandName + " Thank you for a very enjoyable game.");
                        Console.WriteLine("\bFinal Score");
                        Console.WriteLine("\b{0} = " + playerScore, playerName);
                        Console.WriteLine("\b{0} = " + computerScore, computerName);
                        Console.WriteLine("\nPress Enter to continue.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("\bFinal Score");
                        Console.WriteLine("\b{0} = " + playerScore, playerName);
                        Console.WriteLine("\b{0} = " + computerScore, computerName);
                        Console.WriteLine("\nPress Enter to continue.");
                        Console.ReadLine();
                    }

                }
            }
        }

        public static Outcome DetermineWinner(string pHand, string cHand)
        {
            string playerHand = pHand;
            string computerHand = cHand;
            //Wins
            if (playerHand == Convert.ToString(hand.Scissors) && (computerHand == Convert.ToString(hand.Lizard) || computerHand == Convert.ToString(hand.Paper)))
            {
                return Outcome.Win;
            }
            else if (playerHand == Convert.ToString(hand.Paper) && (computerHand == Convert.ToString(hand.Spock) || computerHand == Convert.ToString(hand.Rock)))
            {
                return Outcome.Win;
            }
            else if (playerHand == Convert.ToString(hand.Rock) && (computerHand == Convert.ToString(hand.Scissors) || computerHand == Convert.ToString(hand.Lizard)))
            {
                return Outcome.Win;
            }
            else if (playerHand == Convert.ToString(hand.Lizard) && (computerHand == Convert.ToString(hand.Spock) || computerHand == Convert.ToString(hand.Paper)))
            {
                return Outcome.Win;
            }
            else if (playerHand == Convert.ToString(hand.Spock) && (computerHand == Convert.ToString(hand.Scissors) || computerHand == Convert.ToString(hand.Rock)))
            {
                return Outcome.Win;
            }//Loses
            else if (playerHand == Convert.ToString(hand.Scissors) && (computerHand == Convert.ToString(hand.Spock) || computerHand == Convert.ToString(hand.Rock)))
            {
                return Outcome.Lose;
            }
            else if (playerHand == Convert.ToString(hand.Paper) && (computerHand == Convert.ToString(hand.Scissors) || computerHand == Convert.ToString(hand.Lizard)))
            {
                return Outcome.Lose;
            }
            else if (playerHand == Convert.ToString(hand.Rock) && (computerHand == Convert.ToString(hand.Paper) || computerHand == Convert.ToString(hand.Spock)))
            {
                return Outcome.Lose;
            }
            else if (playerHand == Convert.ToString(hand.Lizard) && (computerHand == Convert.ToString(hand.Scissors) || computerHand == Convert.ToString(hand.Rock)))
            {
                return Outcome.Lose;
            }
            else if (playerHand == Convert.ToString(hand.Spock) && (computerHand == Convert.ToString(hand.Lizard) || computerHand == Convert.ToString(hand.Paper)))
            {
                return Outcome.Lose;
            }
            else
            {
                return Outcome.Tie;
            }
        }

        public static string getHandNamePlr(char handSelect)// for player hands
        {
            string handValue;
            switch (handSelect)
            {
                case 'R':
                    handValue = "Rock";
                    break;
                case 'P':
                    handValue = "Paper";
                    break;
                case 'S':
                    handValue = "Scissors";
                    break;
                case 'L':
                    handValue = "Lizard";
                    break;
                case 'K':
                    handValue = "Spock";
                    break;
                default:
                    throw new Exception("Unexpected Error");
            }
            return handValue;
        }
        public static string getHandNameCmp(int handSelect) //for computer hands
        {
            string handValue;
            switch (handSelect)
            {
                case 1:
                    handValue = "Rock";
                    break;
                case 2:
                    handValue = "Paper";
                    break;
                case 3:
                    handValue = "Scissors";
                    break;
                case 4:
                    handValue = "Lizard";
                    break;
                case 5:
                    handValue = "Spock";
                    break;
                default:
                    throw new Exception("Unexpected Error");
            }
            return handValue;
        }
        public static int halSelect(char playerhand)
        {
            int handValue;
            switch (playerhand)
            {
                case 'R':
                    handValue = 2;
                    break;
                case 'P':
                    handValue = 3;
                    break;
                case 'S':
                    handValue = 5;
                    break;
                case 'L':
                    handValue = 1;
                    break;
                case 'K':
                    handValue = 4;
                    break;
                default:
                    throw new Exception("Unexpected Error");
            }
            return handValue;
        }
    }
    }
