using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using WpfChess.Logic;

namespace WpfChess
{
    class Moves
    {
        public static bool InsideBorder(int j, int i)
        {
            if (i >= 9 || j >= 9 || i < 1 || j < 1)
                return false;
            return true;
        }

        public static void MovingPawn(int j, int i, int dir)
        {
            if (InsideBorder(j + 1 * dir, i))
            {
                if (Game.ChessBoard[j + 1 * dir, i].Content == null)
                {
                    Game.ChessBoard[j + 1 * dir, i].Background = Brushes.Yellow;
                    Game.ChessBoard[j + 1 * dir, i].IsEnabled = true;
                    Game.ThereIsMove = true;
                }
            }

            if (InsideBorder(j + 1 * dir, i + 1))
            {
                if (Game.ChessBoard[j + 1 * dir, i + 1].Content != null && ((Game.ChessBoard[j + 1 * dir, i + 1].Foreground == Brushes.Red) != Game.MoveFirstPlayer))
                {
                    Game.ChessBoard[j + 1 * dir, i + 1].Background = Brushes.Yellow;
                    Game.ChessBoard[j + 1 * dir, i + 1].IsEnabled = true;
                    Game.ThereIsMove = true;
                }
            }

            if (InsideBorder(j + 1 * dir, i - 1))
            {
                if (Game.ChessBoard[j + 1 * dir, i - 1].Content != null && ((Game.ChessBoard[j + 1 * dir, i - 1].Foreground == Brushes.Red) != Game.MoveFirstPlayer))
                {
                    Game.ChessBoard[j + 1 * dir, i - 1].Background = Brushes.Yellow;
                    Game.ChessBoard[j + 1 * dir, i - 1].IsEnabled = true;
                    Game.ThereIsMove = true;
                }
            }
        }

        public static void MovingHorse(int j, int i)
        {
            if (InsideBorder(j - 2, i + 1))
            {
                DeterminePath(j - 2, i + 1);
            }
            if (InsideBorder(j - 2, i - 1))
            {
                DeterminePath(j - 2, i - 1);
            }
            if (InsideBorder(j + 2, i + 1))
            {
                DeterminePath(j + 2, i + 1);
            }
            if (InsideBorder(j + 2, i - 1))
            {
                DeterminePath(j + 2, i - 1);
            }
            if (InsideBorder(j - 1, i + 2))
            {
                DeterminePath(j - 1, i + 2);
            }
            if (InsideBorder(j + 1, i + 2))
            {
                DeterminePath(j + 1, i + 2);
            }
            if (InsideBorder(j - 1, i - 2))
            {
                DeterminePath(j - 1, i - 2);
            }
            if (InsideBorder(j + 1, i - 2))
            {
                DeterminePath(j + 1, i - 2);
            }
        }

        public static void GoingDiagonal(int J, int I, bool isOneStep = false)
        {
            int j = I + 1;
            for (int i = J - 1; i >= 1; i--)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j < 8)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }

            j = I - 1;
            for (int i = J - 1; i >= 1; i--)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j > 1)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }

            j = I - 1;
            for (int i = J + 1; i < 9; i++)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j > 1)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }

            j = I + 1;
            for (int i = J + 1; i < 9; i++)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j < 8)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }
        }

        public static void GoingVerticalHorizontal(int J, int I, bool isOneStep = false)
        {
            for (int i = J + 1; i < 9; i++)
            {
                if (InsideBorder(i, I))
                {
                    if (!DeterminePath(i, I))
                        break;
                }
                if (isOneStep)
                    break;
            }
            for (int i = J - 1; i >= 1; i--)
            {
                if (InsideBorder(i, I))
                {
                    if (!DeterminePath(i, I))
                        break;
                }
                if (isOneStep)
                    break;
            }
            for (int j = I + 1; j < 9; j++)
            {
                if (InsideBorder(J, j))
                {
                    if (!DeterminePath(J, j))
                        break;
                }
                if (isOneStep)
                    break;
            }
            for (int j = I - 1; j >= 1; j--)
            {
                if (InsideBorder(J, j))
                {
                    if (!DeterminePath(J, j))
                        break;
                }
                if (isOneStep)
                    break;
            }
        }

        public static bool DeterminePath(int j, int i)
        {
            if (Game.ChessBoard[j, i].Content == null)
            {
                Game.ChessBoard[j, i].Background = Brushes.Yellow;
                Game.ChessBoard[j, i].IsEnabled = true;
                Game.ThereIsMove = true;
            }
            else
            {
                if ((Game.ChessBoard[j, i].Foreground == Brushes.LightBlue) != Game.MoveFirstPlayer)
                {
                    Game.ChessBoard[j, i].Background = Brushes.Yellow;
                    Game.ChessBoard[j, i].IsEnabled = true;
                    Game.ThereIsMove = true;
                }
                return false;
            }
            return true;
        }


        public static void MakeMove(Button pressedButton, FiguresLocation board)
        {
            /*if (MoveFirstPlayer == true)
            {
                FiguresLocation.PlayerTwo.AddPoints((string)pressedButton.Content);
            }
            else
            {
                FiguresLocation.PlayerOne.AddPoints((string)pressedButton.Content);
            }*/

            board.cell[pressedButton.Name[1] - 49, pressedButton.Name[3] - 49].Color = board.cell[Game.PrevButton.Name[1] - 49, Game.PrevButton.Name[3] - 49].Color;
            board.cell[pressedButton.Name[1] - 49, pressedButton.Name[3] - 49].Name = board.cell[Game.PrevButton.Name[1] - 49, Game.PrevButton.Name[3] - 49].Name;
            board.cell[Game.PrevButton.Name[1] - 49, Game.PrevButton.Name[3] - 49] = null;
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
        /*public static void DrawCorrectMove(Button pressedButton, FiguresLocation board)
        {
            List<string> listCorrectMove = new List<string>();

            int i = int.Parse(Convert.ToString(pressedButton.Name[1]));
            int j = int.Parse(Convert.ToString(pressedButton.Name[3]));

            CorrectMoves.SetFigure(i, j, board, listCorrectMove, Convert.ToString(pressedButton.Content));

            for (int k = 0; k < listCorrectMove.Count; k++)
            {
                Game.ChessBoard[listCorrectMove[k][1] - 47, listCorrectMove[k][0] - 47].Background = Brushes.Yellow;
                Game.ChessBoard[listCorrectMove[k][1] - 47, listCorrectMove[k][0] - 47].IsEnabled = true;
                Game.thereIsMove = true;
            }
            if (!Game.thereIsMove)
            {
                Board.ActivateBoard();
                Board.CloseSteps();
                Game.isMoving = false;
            }
        }*/
    }
}
