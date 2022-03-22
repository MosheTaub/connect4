using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewConect4
{
    class Board
    {
        private Row[] board;

        public Board()
        {
            board = new Row[6];
            for (int i = 0; i < this.board.Length; i++)
            {
                board[i] = new Row();
            }
        }
        public Row[] GetBoard()
        {
            return board;
        }
        public void Print()
        {
            Console.WriteLine();
            for (int i = 0; i < this.board.Length; i++)
            {
                Console.Write(" ");
                for (int j = 0; j < this.board[i].GetRow().Length; j++)
                {
                    if (this.board[i].GetRow()[j].GetNum() == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" " + this.board[i].GetRow()[j].GetCell());
                        Console.ResetColor();
                    }
                    else if (this.board[i].GetRow()[j].GetNum() == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" " + this.board[i].GetRow()[j].GetCell());
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" " + this.board[i].GetRow()[j].GetCell());
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  1 2 3 4 5 6 7");
            Console.WriteLine();
        }
        public bool PushToBoard(int line, int player)
        {
            if (this.board[0].GetRow()[line].GetNum() != 0)
            {
                return false;
            }
            for (int i = this.board.Length - 1; i > 0; i--)
            {
                if (this.board[i].GetRow()[line].GetNum() == 0)
                {
                    this.board[i].GetRow()[line].SetNum(player);
                    return true;
                }
            }
            this.board[0].GetRow()[line].SetNum(player);
            return true;
        }
        public bool CheckWinByRow(int row, int line)
        {
            int tempLine = line;
            int count = 1;
            while (line < 6 && this.board[row].GetRow()[line].GetNum() == this.board[row].GetRow()[line + 1].GetNum())
            {
                count++;
                line++;
            }
            line = tempLine;
            while (line > 0 && this.board[row].GetRow()[line].GetNum() == this.board[row].GetRow()[line - 1].GetNum())
            {
                count++;
                line--;
            }
            if (count >= 4)
            {
                return true;
            }
            return false;
        }
        public bool CheckWinByLine(int row, int line)
        {
            int count = 1;
            if (row < 3)
            {
                while (row < 5 && this.board[row].GetRow()[line].GetNum() == this.board[row + 1].GetRow()[line].GetNum())
                {
                    count++;
                    row++;
                }
                if (count >= 4)
                {
                    return true;
                }
            }          
            return false;
        }
        public bool CheckWinBySlant(int row, int line)
        {
            int helpRow = row;
            int helpLine = line;
            int count = 1;
            while (row > 0 && line < 6 && this.board[row].GetRow()[line].GetNum() == this.board[row - 1].GetRow()[line + 1].GetNum())
            {
                count++;
                row--;
                line++;
            }
            row = helpRow;
            line = helpLine;
            while (row < 5 && line > 0 && this.board[row].GetRow()[line].GetNum() == this.board[row + 1].GetRow()[line - 1].GetNum())
            {
                count++;
                row++;
                line--;
            }
            if (count >= 4)
            {
                return true;
            }
            count = 1;
            row = helpRow;
            line = helpLine;
            while (row < 5 && line < 6 && this.board[row].GetRow()[line].GetNum() == this.board[row + 1].GetRow()[line + 1].GetNum())
            {
                count++;
                row++;
                line++;
            }
            row = helpRow;
            line = helpLine;
            while (row > 0 && line > 0 && this.board[row].GetRow()[line].GetNum() == this.board[row - 1].GetRow()[line - 1].GetNum())
            {
                count++;
                row--;
                line--;
            }
            if (count >= 4)
            {
                return true;
            }
            return false;
        }
        public bool CheckTie()
        {
            for (int i = 0; i < 7; i++)
            {
                if (board[0].GetRow()[i].GetNum() == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public int GetRowFromLine(int line)
        {
            int count = 0;
            while (this.board[count].GetRow()[line].GetNum() == 0)
            {
                count++;
            }
            return count;
        }
    }
}