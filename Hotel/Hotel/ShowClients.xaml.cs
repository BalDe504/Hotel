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

            InitializeComponent();
            var items = new ObservableCollection<Object>();
            using (var context = new HotelContext())
            {
                var query = from k in context.Kliencis join p in context.Pobyties on k.IdKlienta equals p.IdKlienta orderby p.IdKlienta select new
                {
                    k.Imie,
                    k.Nazwisko,
                    k.Telefon,
                    p.DataPrzyjazdu,
                    p.ZakonczonyPobyt
                };
                foreach (var klient in query)
                {
                    items.Add(klient);
                }
            }
            myListView.ItemsSource = items;

        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Window mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void myListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
