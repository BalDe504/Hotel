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
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window accommodationWindow = new ShowAccomodations();
            accommodationWindow.Show();
            this.Close();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Window clientsWindow = new ShowClients();
            clientsWindow.Show();
            this.Close();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Window ServicesBWindow = new ShowServicesBought();
            ServicesBWindow.Show();
            this.Close();
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            Window ServicesWindow = new ShowServices();
            ServicesWindow.Show();
            this.Close();
        }
    }
}
