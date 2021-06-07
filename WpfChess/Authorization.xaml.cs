using System.Windows;
using WpfChess.Logic;

namespace WpfChess
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            FirstPlayer.Name = tbFirstPlayer.Text;
            SecondPlayer.Name = tbSecondPlayer.Text;

            Game game = new Game();
            game.Show();
            Close();
        }
    }
}
