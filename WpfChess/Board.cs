using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfChess.Logic;

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

        public static void DeactivateBoard()
        {
            Activation(false);
        }

        public static void ActivateBoard()
        {
            Activation(true);
        }

        public static void Activation(bool item)
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    Game.ChessBoard[i, j].IsEnabled = item;
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
            /*if (Game.MoveFirstPlayer == true)
            {
                FiguresLocation.PlayerTwo.AddPoints((string)pressedButton.Content);
            }
            else
            {
                ModelBoard.PlayerOne.AddPoints((string)pressedButton.Content);
            }*/

            pressedButton.Content = Game.PrevButton.Content;
            pressedButton.Foreground = Game.PrevButton.Foreground;
            Game.PrevButton.Content = null;
            Game.PrevButton.Foreground = Brushes.Black;

            if (Game.ColorCellGray)
                Game.PrevButton.Background = Brushes.Gray;
            else
                Game.PrevButton.Background = Brushes.White;

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
                ActivateBoard();
                CloseSteps();
                Game.IsMoving = false;
            }
        }
    }
}
