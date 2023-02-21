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
    /// Логика взаимодействия для DetectivRed.xaml
    /// </summary>
    public partial class DetectivRed : Window
    {
        Detective Detective;
        User User;
        EntityModelContainer db = new EntityModelContainer();
        public DetectivRed(Detective detective, User user)
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
            Detective = detective;
            User = user;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
