using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using WpfChess.Logic;

namespace WpfChess
{
    class WpfDrawer
    {
        private int X, Y;
        private bool color;
        public Button cell = new Button();
        private Cell Figure { get; set; }

        public WpfDrawer(int x, int y)
        {
            X = x;
            Y = y;

            if ((x + y) % 2 == 1)
                color = true;
            else
                color = false;
        }

        public void OutputCellBoard(Canvas Field, FiguresLocation board)
        {
            var cellSize = (Field.ActualHeight + Field.ActualWidth) / 20;

            //cell.Name = $"y{Y}x{X}";

            cell.Width = cellSize;
            cell.Height = cellSize;

            if (color)
                cell.Background = Brushes.Gray;
            else
                cell.Background = Brushes.White;

            if (board.cell[Y - 1, X - 1] != null)
            {
                cell.Content = board.cell[Y - 1, X - 1].Name.ToString();
                Figure = board.cell[Y - 1, X - 1];

                if (board.cell[Y - 1, X - 1].Color == Logic.Colors.White)
                {
                    cell.Foreground = Brushes.LightBlue;
                }
                else
                {
                    cell.Foreground = Brushes.Black;
                }
            }

            cell.FontSize = cellSize / 2;

            Field.Children.Add(cell);

            Canvas.SetTop(cell, X * cellSize);
            Canvas.SetLeft(cell, Y * cellSize);
        }

        /*private static char ch = 'A';
        public void OutputCellRamk(Canvas Field)
        {
            var cellSize = (Field.ActualHeight + Field.ActualWidth) / 20;

            var text = new TextBlock();
            text.Text = Convert.ToString(ch);

            if (ch == 'H')
                ch = (char)(ch - 24);

            ch = (char)(ch + 1);

            text.Height = cellSize / 4;
            text.Width = cellSize / 4;
            text.FontSize = cellSize / 4;

            Field.Children.Add(text);

            Canvas.SetTop(text, X * cellSize);
            Canvas.SetLeft(text, Y * cellSize);

            if (ch == '9')
                ch = 'A';
        }*/
    }
}
