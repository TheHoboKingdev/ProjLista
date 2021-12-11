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
using System.IO;

namespace ListApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> Elemek = new List<string>();
        List<string> TElemek = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            //Mentett lista betöltése
            if (File.Exists(@"Elemek")) {
                foreach (string line in File.ReadAllLines(@"Elemek")) {
                    Elemek.Add(line);
                    CheckBox listaelem = new CheckBox();
                    listaelem.Content = line;
                    Lista.Items.Add(listaelem);
                }
            }

            //Mentett Törölt Lista betöltése
            if (File.Exists(@"TElemek"))
            {
                foreach (string line in File.ReadAllLines(@"TElemek"))
                {
                    TElemek.Add(line);
                    CheckBox Tlistaelem = new CheckBox();
                    Tlistaelem.Content = line;
                    TLista.Items.Add(Tlistaelem);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Listaelem felvétele
            File.AppendAllText(@"Elemek", Adat.Text + System.Environment.NewLine);
            Elemek.Add(Adat.Text);
            CheckBox listaelem = new CheckBox();
            listaelem.Content = Adat.Text;
            listaelem.AddHandler(CheckBox.CheckedEvent, new RoutedEventHandler(listaelem_isChecked));
            Lista.Items.Add(listaelem);
        }

        private void listaelem_isChecked(object sender, RoutedEventArgs e)
        {
            (sender as CheckBox).Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Áthelyezés a kukába
            File.AppendAllText(@"TElemek", Adat.Text + System.Environment.NewLine);
            TElemek.Add(Adat.Text);
            CheckBox Tlistaelem = new CheckBox();
            Tlistaelem.Content = Adat.Text;
            TLista.Items.Add(Tlistaelem);
            Elemek.RemoveAt(Lista.SelectedIndex);
            Lista.Items.RemoveAt(Lista.SelectedIndex);
            Lista.Items.Refresh();
        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //A  beviteli adatmezőnél a kiválasztott elem nevét helyettesíti be
            if (Lista.SelectedIndex < Elemek.Count && Lista.SelectedIndex > -1)
            {
                Adat.Text = Elemek[Lista.SelectedIndex];
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Kukába helyezett elemek törlése
            TElemek.Clear();
            TLista.Items.Clear();
            File.Delete(@"TElemek");
        }
    }
}
