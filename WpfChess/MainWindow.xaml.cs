using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfChess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*Board ChessBoard = new Board();
        List<BoardCell> ChessBoardCells = new List<BoardCell>();*/

        public MainWindow()
        {
            InitializeComponent();
            //Drawer.MainWindow = this;
            Board.MyCanvas = (Canvas)FindName("Сanvas");

            /*for (char i = 'A'; i <= 'H'; i++)
            {
                for (char j = '1'; j <= '8'; j++)
                {
                    BoardCell ChessBoardCell = new BoardCell(i, j, ChessBoard.Get(i, j), (Canvas)FindName("Сanvas"));
                    ChessBoardCells.Add(ChessBoardCell);
                }
            }*/
        }

        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();

            //Board.FillBoard();
            //WpfDrawer.CreatePreviousGameWindow();
        }

        private void BtnContinue_Click(object sender, RoutedEventArgs e)
        {
            //Board.DataWorker.LoadBoard();
            //WpfDrawer.CreateGameWindow();
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
            Close();
            /*NewGame giveName = new NewGame();
            giveName.Show();*/
        }

        private void BtnRating_Click(object sender, RoutedEventArgs e)
        {
            //WpfDrawer.CreateRatingWindow();
        }
    }
}
