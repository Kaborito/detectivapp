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

namespace Частный_детектив
{
    /// <summary>
    /// Логика взаимодействия для Klient.xaml
    /// </summary>
    public partial class Klient : Window
    {
        Client Client;
        public Klient(Client client)
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
            Client = client;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            KlientSms form = new KlientSms(Client);
            form.Show();
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
