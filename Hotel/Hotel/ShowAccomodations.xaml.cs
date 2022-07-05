using Hotel.Models;
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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Hotel
{
    /// <summary>
    /// Logika interakcji dla klasy ShowAccomodations.xaml
    /// </summary>
    public partial class ShowAccomodations : Window
    {
        public ShowAccomodations()
        {
            InitializeComponent();
            var items = new ObservableCollection<Pobyty>();
            using (var context = new HotelContext())
            {
                var query = from p in context.Pobyties orderby p.Id select p;
                foreach (var pobyt in query)
                {
                    items.Add(pobyt);
                }
            }
            myListView1.ItemsSource = items;
        }

    }
}
