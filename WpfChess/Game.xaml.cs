using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfChess.Logic;

namespace WpfChess
{
    public partial class Game : Window
    {
        private static FiguresLocation Figure { get; set; } = new FiguresLocation();
        public static Button[,] ChessBoard { get; } = new Button[9, 9];

        public Game()
        {
            InitializeComponent();
            this.Closing += Game_Closing;
        }

        private void Field_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (MainWindow.IsNewGame)
            {
                Figure.FigureStartLocaton();
            }
            else
            {
                Figure.FigureContinueLocaton();
            }

            Field.Children.Clear();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    ChessBoard[i, j] = new Button();

                    var field = new WpfDrawer(i, j);

                    if (i != 0 && j != 0)
                    {
                        field.DoingCellBoard(Field, Figure);
                    }
                    else if (!(i == 0 && j == 0))
                    {
                        field.DoingCellsFrame(Field);
                    }

                    ChessBoard[i, j] = field.cell;
                    ChessBoard[i, j].Click += new RoutedEventHandler(ClickFigure);
                }
            }
        }

        public static Button PrevButton { get; set; }
        public static bool ColorCellGray { get; set; }
        public static bool IsMoving { get; set; } = false;
        public static bool MoveFirstPlayer { get; set; } = true;
        public static bool ThereIsMove { get; set; }

        private void ClickFigure(object sender, RoutedEventArgs e) //ход
        {
            Button pressedButton = sender as Button;

            if (!IsMoving && ((pressedButton.Foreground == Brushes.LightBlue) == (MoveFirstPlayer)) && pressedButton.Content != null)
            {
                PrevButton = pressedButton;

                //Board.CloseSteps();

                if (pressedButton.Content != null && ((pressedButton.Foreground == Brushes.LightBlue) == (MoveFirstPlayer)))
                {
                    IsMoving = true;
                }
            }
            else if (IsMoving)
            {
                IsMoving = false;
                Board.MakeMove(pressedButton);
                Board.CloseSteps();
                SwitchPlayer();
            }
        }
        private void SwitchPlayer()
        {
            if (MoveFirstPlayer == true)
            {
                MoveFirstPlayer = false;
            }
            else
            {
                MoveFirstPlayer = true;
            }
        }

        private void Game_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Board.SaveBoard();
            new MainWindow().Show();
        }
    }
}
