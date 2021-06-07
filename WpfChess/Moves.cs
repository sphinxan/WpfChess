﻿using System;
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
                Game.ThereIsMove = true;
            }
            else
            {
                if ((Game.ChessBoard[j, i].Foreground == Brushes.LightBlue) != Game.MoveFirstPlayer)
                {
                    Game.ChessBoard[j, i].Background = Brushes.Yellow;
                    Game.ThereIsMove = true;
                }
                return false;
            }
            return true;
        }
    }
}
