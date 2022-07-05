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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var items = new ObservableCollection<Klienci>();
            using (var context = new HotelContext())
            {
                var query = from p in context.Kliencis orderby p.IdKlienta select p;
                foreach(var klient in query)
                {
                    items.Add(klient);
                }
            }
            myListView.ItemsSource = items;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window accommodationWindow = new ShowAccomodations();
            accommodationWindow.Show();
            this.Close();
        }

    }
}
