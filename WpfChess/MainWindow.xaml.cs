using System.Windows;

namespace WpfChess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool IsNewGame { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            IsNewGame = true;
            new Authorization().Show();
            Close();
        }

        private void BtnContinue_Click(object sender, RoutedEventArgs e)
        {
            IsNewGame = false;
            new Game().Show();
            Close();
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            new Settings().Show();
            Close();
        }

        private void BtnRating_Click(object sender, RoutedEventArgs e)
        {
            new Rating().Show();
            Close();
        }
    }
}
