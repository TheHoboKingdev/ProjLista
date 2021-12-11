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

        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(@"Elemek")){
                foreach (string line in File.ReadAllLines(@"Elemek")){
                    Elemek.Add(line);
                    CheckBox listaelem = new CheckBox();
                    listaelem.Content = line;
                    Lista.Items.Add(listaelem);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            File.AppendAllText(@"Elemek", Adat.Text + System.Environment.NewLine);
            Elemek.Add(Adat.Text);
            CheckBox listaelem = new CheckBox();
            listaelem.Content = Adat.Text;
            Lista.Items.Add(listaelem);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Lista.Items.Remove(Adat.Text);
            File.AppendAllText(@"TElemek", Adat.Text + System.Environment.NewLine);
            Elemek.Remove(Adat.Text);
            CheckBox Tlistaelem = new CheckBox();
            Tlistaelem.Content = Adat.Text;
            TLista.Items.Add(Tlistaelem);
        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Adat.Text = (Lista.SelectedItem as ListBoxItem).Content.ToString();
        }
    }
}
