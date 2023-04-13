using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// Tic Tac Toe is english version of name for game Kolko i Krrzyzyk
// this clase is responsible for implementation of this game 
namespace KolkoIKrzyzyk 
{
    internal class TicTacToe
    {
        static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

        static void PrintBoard()
        {
            Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
        }

        static bool CheckWin(char mark)
        {
            if ((board[0] == mark && board[1] == mark && board[2] == mark) ||
                (board[3] == mark && board[4] == mark && board[5] == mark) ||
                (board[6] == mark && board[7] == mark && board[8] == mark) ||
                (board[0] == mark && board[3] == mark && board[6] == mark) ||
                (board[1] == mark && board[4] == mark && board[7] == mark) ||
                (board[2] == mark && board[5] == mark && board[8] == mark) ||
                (board[0] == mark && board[4] == mark && board[8] == mark) ||
                (board[2] == mark && board[4] == mark && board[6] == mark))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static void Play()
        {
            char turn = 'X';
            int count = 0;
            int move;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Kółko i krzyżyk\n");
                PrintBoard();
                Console.Write("\nGracz {0}, Podaj ruch (1-9): ", turn);

                if (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > 9)
                {
                    Console.WriteLine("Nieprawidłowy ruch. Podaj wartość z zakresu 1-9.");
                    continue;
                }               


                if (board[move - 1] == ' ')
                {
                    board[move - 1] = turn;
                    count++;
                }
                else
                {
                    Console.WriteLine("To pole jest już zajęte. Spróbuj jeszcze raz.");
                    Console.ReadKey();
                    continue;
                }

                // Sprawdzenie wygranej lub remisu
                if (count >= 5)
                {
                    if (CheckWin(turn))
                    {
                        Console.Clear();
                        Console.WriteLine("Kółko i krzyżyk\n");
                        PrintBoard();
                        Console.WriteLine("\nGracz {0} wygrał!", turn);
                        break;
                    }
                }

                if (count == 9)
                {
                    Console.Clear();
                    Console.WriteLine("Kółko i krzyżyk\n");
                    PrintBoard();
                    Console.WriteLine("\nRemis!");
                    break;
                }

                // Zamiana gracza
                if (turn == 'X')
                {
                    turn = 'O';
                }
                else
                {
                    turn = 'X';
                }
            }

            // Zapytanie o ponowną grę
            Console.Write("\nCzy chcesz zagrać ponownie? (Tak/Nie): ");
            string again = Console.ReadLine().ToLower();
            if (again == "tak")
            {
                board = new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
                PrintBoard();
                Play();
            }
        }

    }
}
