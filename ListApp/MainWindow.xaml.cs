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
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            File.AppendAllText(@"Elemek", Adat.Text + "/n");
            Elemek.Add(Adat.Text);
            Lista.ItemsSource = Elemek;
        }
    }
}
