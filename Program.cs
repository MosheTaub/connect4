using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewConect4
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            bool endGame = false;
            string win = "Player 1 win!";
            Console.WriteLine("Enter the game when you are ready");
            ConsoleKeyInfo toets = Console.ReadKey(true);
            while (!endGame)
            {
                Console.Clear();
                board.Print();
                win = "Player 1 win!";
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Player 1 pick a line between 1-7");
                Console.ResetColor();
                int line = int.Parse(Console.ReadLine());
                while (line < 1 || line > 7 || !board.PushToBoard(line - 1, 0))
                {
                    Console.Clear();
                    board.Print();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Player 1 pick a line between 1-7");
                    Console.ResetColor();
                    line = int.Parse(Console.ReadLine());
                }
                line--;
                board.PushToBoard(line, 1);
                int row = board.GetRowFromLine(line);
                endGame = board.CheckWinByRow(row, line) || board.CheckWinByLine(row, line) || board.CheckWinBySlant(row, line) || board.CheckTie();
                Console.Clear();
                if (!endGame)
                {
                    board.Print();
                    win = "Player 2 win!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Player 2 pick a line between 1-7");
                    Console.ResetColor();
                    line = int.Parse(Console.ReadLine());
                    while (line < 1 || line > 7 || !board.PushToBoard(line - 1, 0))
                    {
                        Console.Clear();
                        board.Print();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Player 2 pick a line between 1-7");
                        Console.ResetColor();
                        line = int.Parse(Console.ReadLine());
                    }
                    line--;
                    board.PushToBoard(line, 2);
                    row = board.GetRowFromLine(line);
                    endGame = board.CheckWinByRow(row, line) || board.CheckWinByLine(row, line) || board.CheckWinBySlant(row, line) || board.CheckTie();
                    Console.Clear();;
                }
            }
            board.Print();
            if (board.CheckTie())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Tie!");
                Console.ResetColor();
            }
            else if (win.Equals("Player 1 win!"))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(win);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(win);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}
