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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Частный_детектив
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EntityModelContainer model = new EntityModelContainer();
        public MainWindow()
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uslugi form = new Uslugi();
            form.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Garanti form = new Garanti();
            form.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Contact form = new Contact();
            form.Show();
            this.Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Zayavki form = new Zayavki();
            form.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Vhod form = new Vhod();
            form.Show();
            this.Hide();
        }

        private void up_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            qrcod form = new qrcod();
            form.Show();
        }
    }
}
