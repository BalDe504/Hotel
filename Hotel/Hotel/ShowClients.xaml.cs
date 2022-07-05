using Hotel.Models;
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
using System.Windows.Shapes;

namespace Hotel
{
    /// <summary>
    /// Logika interakcji dla klasy ShowClients.xaml
    /// </summary>
    public partial class ShowClients : Window
    {

        public ShowClients()
        {
            var items = new ObservableCollection<Klienci>();
            items.Add(new Klienci() { Imie = "John Doe" });
            myListView.ItemsSource = items;
            InitializeComponent();

        }

        private void myListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
