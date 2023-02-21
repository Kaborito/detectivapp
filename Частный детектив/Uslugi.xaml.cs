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
    /// Логика взаимодействия для Uslugi.xaml
    /// </summary>
    public partial class Uslugi : Window
    {
        EntityModelContainer db = new EntityModelContainer();
        public Uslugi()
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from n in db.Uslugas orderby n.Id select new { n.Id, n.Name, n.Price };
            dataGridUslugi1.ItemsSource = query.ToList();
        }

    }
}
