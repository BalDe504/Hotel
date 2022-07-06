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

namespace Hotel
{
    /// <summary>
    /// Logika interakcji dla klasy AddAccomodoations.xaml
    /// </summary>
    public partial class AddAccomodoations : Window
    {
        public AddAccomodoations()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new HotelContext())
            {
                Pobyty pobyt = new Pobyty { IdKlienta = int.Parse(IDKlienta.Text), IdPokoju = int.Parse(IDPokoju.Text), DataPrzyjazdu = DateTime.Parse(Data_przyjazdu.Text), ZakonczonyPobyt = bool.Parse(Zakonczony_pobyt.Text) };
                context.Pobyties.Add(pobyt);
                
                var result = await context.SaveChangesAsync();

            }
            

        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Window clientsWindow = new ShowClients();
            clientsWindow.Show();
            this.Close();
        }
    }
}
