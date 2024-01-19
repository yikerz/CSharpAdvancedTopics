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

namespace ListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Match> matches = new List<Match>();
            matches.Add(new Match() 
            { 
                Team1 = "Avalanche", 
                Team2 = "Kings",
                Score1 = 8, 
                Score2 = 0, 
                Completion = 50 
            });
            matches.Add(new Match()
            {
                Team1 = "Oilers",
                Team2 = "Kracken",
                Score1 = 4,
                Score2 = 0,
                Completion = 40
            });
            matches.Add(new Match()
            {
                Team1 = "Ducks",
                Team2 = "Flames",
                Score1 = 5,
                Score2 = 3,
                Completion = 35
            });
            games.ItemsSource = matches;
        }

        public class Match
        {
            public int Score1 { get; set; }
            public int Score2 { get; set; }
            public string Team1 { get; set; }
            public string Team2 { get; set; }
            public int Completion { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(games.SelectedItem != null)
            {
                MessageBox.Show("Selected Match: " +
                    (games.SelectedItem as Match).Team1 + " " +
                    (games.SelectedItem as Match).Score1 + " " +
                    (games.SelectedItem as Match).Score2 + " " +
                    (games.SelectedItem as Match).Team2
                    );
            }
        }
    }
}
