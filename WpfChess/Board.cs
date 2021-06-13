using System;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media;

namespace WpfChess
{
    public class Board
    {
        public static void SaveBoard()
        {
            string[] boardInFile = new string[8];

            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (Game.ChessBoard[i, j].Content != null)
                        boardInFile[i - 1] += Game.ChessBoard[i, j].Content.ToString();
                    else
                    {
                        boardInFile[i - 1] += "No ";
                        Game.ChessBoard[i, j].Foreground = Brushes.Gray;
                    }

                    if (Game.ChessBoard[i, j].Foreground == Brushes.LightBlue)
                        boardInFile[i - 1] += "W ";
                    else if (Game.ChessBoard[i, j].Foreground == Brushes.Black)
                        boardInFile[i - 1] += "B ";

                }
                File.WriteAllLines("Board.txt", boardInFile);
            }
        }

        public static void MakeMove(Button pressedButton)
        {
            pressedButton.Content = Game.PrevButton.Content;
            pressedButton.Foreground = Game.PrevButton.Foreground;
            
            Game.PrevButton.Content = null;

            Game.PrevButton = null;
            Game.IsMoving = false;
        }
    }
}
