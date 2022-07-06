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
    /// Logika interakcji dla klasy AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new HotelContext())
            {
                Klienci klient = new Klienci { Imie = Imie.Text, Nazwisko = Nazwisko.Text, Telefon = Telefon.Text };
                context.Kliencis.Add(klient);
                try
                {
                    var result = await context.SaveChangesAsync();
                    Console.WriteLine(result);
                    AddButton.Content = "Added";

                } catch (Exception ex)
                {
                    throw ex;
                }

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
