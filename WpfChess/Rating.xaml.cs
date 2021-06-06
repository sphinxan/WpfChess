using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfChess.Logic;

namespace WpfChess
{
    /// <summary>
    /// Логика взаимодействия для Rating.xaml
    /// </summary>
    public partial class Rating : Window
    {
        public Rating()
        {
            InitializeComponent();

            /*string[] ratingInFile = File.ReadAllLines("Rating.txt");

            foreach (string line in ratingInFile)
            {
                string[] element = line.Split(' ');
                var textBlock = new TextBlock();
                textBlock.Text = element[0] + " " + element[1];
                RatingWindow.Children.Add(textBlock);
            } */
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
