using System;
using System.Windows;
using System.Windows.Media;

namespace WpfChess
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Color_Change(object sender, RoutedEventArgs e)
        {
            var rnd = new Random();
            Application.Current.Resources["BackgroundColor"] = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(255), (byte)rnd.Next(255), (byte)rnd.Next(255)));
        }

        private void BtnSaveAndExit_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
