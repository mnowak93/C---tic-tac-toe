using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Board
    {
        private char [,] newBoard = {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            };

        private bool win = false;
        private int rounds = 1;
        private string another = "";

        private void print_board()
        {
            //printing the board
            Console.WriteLine("   1  2  3");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine((i + 1) + " [" + newBoard[i, 0] + "]" + "[" + newBoard[i, 1] + "]" + "[" + newBoard[i, 2] + "]");
            }
        }

        private void read_char(char ch)
        {
            //reading position from user and putting it in newBoard

            string i = "z";
            string j = "z";
            int x, y;

            Console.WriteLine("\n" + ch + " player turn");

            while (i != "1" && i != "2" && i != "3")
            {
                Console.Write("Enter Column (1,2,3): ");
                i = Console.ReadLine();               
            }

            while (j != "1" && j != "2" && j != "3")
            {
                Console.Write("Enter Row (1,2,3): ");
                j = Console.ReadLine();
            }

            x = Convert.ToInt32(i) - 1;
            y = Convert.ToInt32(j) - 1;
            if (newBoard[y, x] == ' ')
            {
                newBoard[y, x] = ch;
            }
            else
            {
                Console.WriteLine("Choose another field");
                read_char(ch);
            }
        }

        private bool check4win()
        {
            //check if the win contitionds are met
            //check for win in columns and rows
            for (int i = 0; i < 3; i++)
            {
                if(newBoard[i, 0] == newBoard[i, 1] && newBoard[i, 1] == newBoard[i, 2] && newBoard[i, 0] != ' ')
                {
                    Console.Clear();
                    print_board();
                    Console.WriteLine("\n" + newBoard[i, 0] + " WINS!!");
                    win = true;
                    return win;
                }
                if(newBoard[0, i] == newBoard[1, i] && newBoard[1, i] == newBoard[2, i] && newBoard[0, i] != ' ')
                {
                    Console.Clear();
                    print_board();
                    Console.WriteLine("\n" + newBoard[0, i] + " WINS!!");
                    win = true;
                    return win;
                }                
            }
            //check for win diagonally
            if (newBoard[0, 0] == newBoard[1, 1] && newBoard[1, 1] == newBoard[2, 2] && newBoard[0, 0] != ' ')
            {
                Console.Clear();
                print_board();
                Console.WriteLine("\n" + newBoard[0, 0] + " WINS!!");
                win = true;
                return win;
            }

            if (newBoard[0, 2] == newBoard[1, 1] && newBoard[1, 1] == newBoard[2, 0] && newBoard[2, 0] != ' ')
            {
                Console.Clear();
                print_board();
                Console.WriteLine("\n" + newBoard[0, 2] + " WINS!!");
                win = true;
                return win;
            }
            return win;
        }

        public void game(char ch1, char ch2)
        {
            //main game function
            //welcome screen
            Console.Clear();
            Console.WriteLine("Welcome to Tic Tac Toe (Press enter to continue)");
            Console.ReadLine();

            //rounds
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Round: " + rounds + "\n");
                print_board();
                read_char(ch1);
                rounds++;
                if (check4win())break;

                if (rounds >= 9)
                {
                    Console.Clear();
                    Console.WriteLine("No winner");
                    break;
                }

                Console.Clear();
                Console.WriteLine("Round: " + rounds + "\n");
                print_board();
                read_char(ch2);
                rounds++;
                if (check4win()) break;                
            }
            
            //playing again
            while (another != "y" && another != "n")
            {
                Console.Write("Play another round? (y - yes, n - no): ");
                another = Console.ReadLine();
            }

            if (another == "y")
            {
                newBoard = new char[,]
                {
                    {' ', ' ', ' '},
                    {' ', ' ', ' '},
                    {' ', ' ', ' '},
                };
                rounds = 1;
                another = "";
                win = false;
                game(ch1, ch2);
            }

            if (another == "n")
            {
                another = "";
                Console.Clear();
                Console.WriteLine("Thanks for playing");
            }
        }
    }
}