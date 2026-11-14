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

namespace Dolgozatok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Dolgozat
        {
            public string Nev { get; set; }
            public int Eletkor { get; set; }
            public int Pontszam { get; set; }

            public Dolgozat(string nev, int eletkor, int pontszam)
            {
                Nev = nev;
                Eletkor = eletkor;
                Pontszam = pontszam;
            }

        }


        List<Dolgozat> dolgozatok = new List<Dolgozat>();
        public MainWindow()
        {
            InitializeComponent();

            

            dolgozatok.Add(new Dolgozat("Kiss Péter", 16, 87));
            dolgozatok.Add(new Dolgozat("Nagy Anna", 17, 92));
            dolgozatok.Add(new Dolgozat("Szabó Tamás", 16, 78));
            dolgozatok.Add(new Dolgozat("Tóth Éva", 18, 95));
            dolgozatok.Add(new Dolgozat("Varga Bence", 17, 81));
            dolgozatok.Add(new Dolgozat("Horváth Zsolt", 16, 65));
            dolgozatok.Add(new Dolgozat("Molnár Réka", 18, 89));
            dolgozatok.Add(new Dolgozat("Lakatos Dániel", 17, 72));

            
            dgdolgozat.ItemsSource = dolgozatok;
        }

        private void btnHozzaad_Click(object sender, RoutedEventArgs e)
        {
            Dolgozat dolgozat = new Dolgozat(txtNev.Text, int.Parse(txtEletkor.Text), int.Parse(txtPontszam.Text));
            dolgozatok.Add(dolgozat);

            dgdolgozat.Items.Refresh();

            txtNev.Clear();
            txtEletkor.Clear();
            txtPontszam.Clear();
        }

        private void btnModosit_Click(object sender, RoutedEventArgs e)
        {
            var sorok = dolgozatok.Select(x => $"{x.Nev};{x.Eletkor};{x.Pontszam}").ToList();

            System.IO.File.WriteAllLines("dolgozatok.txt", sorok);

            MessageBox.Show("Sikeres Mentés!");
        }
    }
}