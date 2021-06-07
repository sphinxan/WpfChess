using System;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media;

namespace WpfChess
{
    public class Board
    {
        public static void CloseSteps()
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if ((i + j) % 2 == 1)
                        Game.ChessBoard[i, j].Background = Brushes.Gray;
                    else
                        Game.ChessBoard[i, j].Background = Brushes.White;
                }
            }
        }

        public static void SaveBoard()
        {
            string[] cellInFile = new string[8];

            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (Game.ChessBoard[i, j].Content != null)
                        cellInFile[i - 1] += Convert.ToString(Game.ChessBoard[i, j].Content);
                    else
                        cellInFile[i - 1] += "N ";

                    if (Game.ChessBoard[i, j].Foreground == Brushes.LightBlue)
                        cellInFile[i - 1] += "W ";
                    else if (Game.ChessBoard[i, j].Foreground == Brushes.Black)
                        cellInFile[i - 1] += "B ";

                }
                File.WriteAllLines("Board.txt", cellInFile);
            }
        }


        public static void MakeMove(Button pressedButton)
        {
            pressedButton.Content = Game.PrevButton.Content;
            pressedButton.Foreground = Game.PrevButton.Foreground;
            Game.PrevButton.Content = null;
            Game.PrevButton.Foreground = Brushes.Black;

            Game.PrevButton = null;
            Game.IsMoving = false;
        }

        public static void SetFigure(Button pressedButton)
        {
            int i = int.Parse(Convert.ToString(pressedButton.Name[1]));
            int j = int.Parse(Convert.ToString(pressedButton.Name[3]));
            int dir;

            if (Game.MoveFirstPlayer == true)
                dir = -1;
            else
                dir = 1;

            switch (pressedButton.Content)
            {
                case "P":
                    Moves.MovingPawn(j, i, dir);
                    break;

                case "R":
                    Moves.GoingVerticalHorizontal(j, i);
                    break;

                case "B":
                    Moves.GoingDiagonal(j, i);
                    break;

                case "H":
                    Moves.MovingHorse(j, i);
                    break;

                case "Q":
                    Moves.GoingVerticalHorizontal(j, i);
                    Moves.GoingDiagonal(j, i);
                    break;

                case "K":
                    Moves.GoingVerticalHorizontal(j, i, true);
                    Moves.GoingDiagonal(j, i, true);
                    break;
            }
            if (!Game.ThereIsMove)
            {
                CloseSteps();
                Game.IsMoving = false;
            }
        }
    }
}
