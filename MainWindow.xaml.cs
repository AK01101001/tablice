using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace listy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Film> films { get; set; } = new ObservableCollection<Film>();
        public List<string> kategorie { get; set; } = new List<string>();
        public static MainWindow instance;
        public MainWindow()
        {
            instance = this;
            InitializeComponent();
            DataContext = this;
            przygotujFilmy();
            przygotujKategorie();
            kat.ItemsSource = kategorie;
        }

        private void przygotujKategorie()
        {
            kategorie.Add("Animowany");
            kategorie.Add("Sci-fi");
            kategorie.Add("Dramat");
            kategorie.Add("Fantasy");
            kategorie.Add("Horror");

        }

        public void przygotujFilmy()
        {
            films.Add(new Film("Chłopi", "Animowany", 2023, true));
            films.Add(new Film("Zwierzogród", "Animowany", 2016, false));
            films.Add(new Film("Shreck", "Animowany", 2001, false));
            films.Add(new Film("Interstellar", "Sci-fi", 2014, false));
            films.Add(new Film("Matrix", "Sci-fi", 1999, true));
            films.Add(new Film("Titanic", "Dramat", 1997, false));
            films.Add(new Film("Hobbit", "Fantasy", 2012, false));
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (tytul.Text.Length > 0 && kategoria.Text.Length > 0)
            {
                if (int.TryParse(rok.Text, out int rokW))
                {
                    bool tylkoDlaDoroslych = false;
                    switch (tdd.IsChecked)
                    {
                        case true:
                            tylkoDlaDoroslych = true;
                            break;
                        case false:
                            tylkoDlaDoroslych = false;
                            break;
                        default:
                            break;

                    }
                    films.Add(new Film(tytul.Text, kategoria.Text, rokW, tylkoDlaDoroslych));
                }
            }
        }
        public void usun(object sender, RoutedEventArgs e)
        {
            Button przycisk = sender as Button;
            if (przycisk != null)
            {
                string name = "";
                name += przycisk.Name[1];

                int.TryParse(name, out int id);
                films.RemoveAt(id);
            }
        }
    }
}