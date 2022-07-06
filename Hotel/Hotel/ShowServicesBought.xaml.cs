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
    /// Logika interakcji dla klasy ShowServicesBought.xaml
    /// </summary>
    public partial class ShowServicesBought : Window
    {
        public ShowServicesBought()
        {
            InitializeComponent();
            var items = new ObservableCollection<WykupioneUslugi>();
            using (var context = new HotelContext())
            {
                var query = from p in context.WykupioneUslugis orderby p.Id select p;
                foreach (var wykup in query)
                {
                    items.Add(wykup);
                }
            }
            myListView2.ItemsSource = items;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Window mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
