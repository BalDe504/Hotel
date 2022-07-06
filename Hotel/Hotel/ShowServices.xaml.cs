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
    /// Logika interakcji dla klasy ShowServices.xaml
    /// </summary>
    public partial class ShowServices : Window
    {
        public ShowServices()
        {
            InitializeComponent();
            var items = new ObservableCollection<Uslugi>();
            using (var context = new HotelContext())
            {
                var query = from p in context.Uslugis orderby p.IdUslugi select p;
                foreach (var usluga in query)
                {
                    items.Add(usluga);
                }
            }
            myListView3.ItemsSource = items;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Window mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
