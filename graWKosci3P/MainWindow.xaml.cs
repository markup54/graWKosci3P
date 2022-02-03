using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace graWKosci3P
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Dice> results { get; set; }
        public ObservableCollection<Score> scores { get; set; }
        public int NumberOfDice { get; set; } 
        public int NumberOfTries { get; set; } 

        public MainWindow()
        {
            InitializeComponent();
            results = new ObservableCollection<Dice>();
            scores = new ObservableCollection<Score>();
            NumberOfDice = 5;
            NumberOfTries = 3;
            prepareGame();
            DataContext = this;
        }
        private void prepareGame()
        {
            scores.Add(new Score("trzy jedynki"));
            scores.Add(new Score("trzy dwojki"));
            scores.Add(new Score("trzy trojki"));
            scores.Add(new Score("trzy czworki"));
            scores.Add(new Score("trzy piątki"));
            scores.Add(new Score("trzy szóstki"));
            scores.Add(new Score("para"));
            scores.Add(new Score("dwie pary"));
            scores.Add(new Score("full"));
            scores.Add(new Score("kareta"));
            scores.Add(new Score("poker"));
            scores.Add(new Score("mały street"));
            scores.Add(new Score("duży street"));
            scores.Add(new Score("szansa"));
        }
        private int suma_takich_samych(ObservableCollection<Dice>tablica, int nr)
        {
            int s = 0;
            foreach(Dice d in tablica)
            {
                if (d.Value == nr)
                    s += d.Value;
            }
            s = s - nr * 3;
            return s;
        }
        private void clearbtn_Click(object sender, RoutedEventArgs e)
        {
            results.Clear();
            for(int i = 0; i < NumberOfDice; i++)
            {
                results.Add(new Dice());
            }
        }

        private void rollbtn_Click(object sender, RoutedEventArgs e)
        {
            if(NumberOfTries > 0)
            {
                var random = new Random();
                foreach (Dice dice in results)
                {
                    if (!dice.IsSelected)
                    {
                        dice.Value = random.Next(1,7);
                    }
                }
                NumberOfTries--;
                showPoints();
                //pokazywanie punktow
            }
            else
            {
                rollbtn.IsEnabled = false;
            }
            
        }
        private void showPoints()
        {
            for(int i = 0; i < 6; i++)
            {
                if(scores[i].IsSet == false)
                {
                    scores[i].Points = suma_takich_samych(results, i + 1);
                }
            }
        }

        private void Button_Dice_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var dice = button.DataContext as Dice;
            dice.IsSelected = !dice.IsSelected;
        }

        private void zatwierdzbtn_Click(object sender, RoutedEventArgs e)
        {
            NumberOfTries = 3;
            rollbtn.IsEnabled = true;
            results.Clear();
            //zatwierdzić zaznaczony wynik i wyłączyć jego klikanie
            for (int i = 0; i < NumberOfDice; i++)
            {
                results.Add(new Dice());
            }
        }
    }
}
