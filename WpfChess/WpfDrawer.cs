using System;
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

        public void DoingCellBoard(Canvas Field, FiguresLocation board)
        {
            var cellSize = (Field.ActualHeight + Field.ActualWidth) / 20;

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

        private static char ch = 'A';
        public void DoingCellsFrame(Canvas Field)
        {
            var cellSize = (Field.ActualHeight + Field.ActualWidth) / 20;
            
            var text = new TextBlock
            {
                Text = $" {Convert.ToString(ch)}",
                Height = cellSize / 1.5,
                Width = cellSize / 2,
                FontSize = cellSize / 2
            };
            var border = new Border
            {
                Width = cellSize,
                Height = cellSize,
                Child = text
            };

            ch = (char)(ch + 1);

            if (ch == 'I')
                ch = '8';
            else if (ch == '9')
                ch = '7';
            else if (ch == '8')
                ch = '6';
            else if (ch == '7')
                ch = '5';
            else if (ch == '6')
                ch = '4';
            else if (ch == '5')
                ch = '3';
            else if (ch == '4')
                ch = '2';
            else if (ch == '3')
                ch = '1';

            else if (ch == '2')
                ch = 'A';

            Field.Children.Add(border);

            Canvas.SetTop(border, X * cellSize);
            Canvas.SetLeft(border, Y * cellSize);
        }
    }
}
