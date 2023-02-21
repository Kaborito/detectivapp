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
    /// Логика взаимодействия для Vhod.xaml
    /// </summary>
    public partial class Vhod : Window
    {
        string id2;
        public Vhod()
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int x = 0;
            try
            {
                if (textBoxLogin.Text != "" && textBoxPassword.Text != "")
                {
                    using (EntityModelContainer db = new EntityModelContainer())
                    {
                        foreach (User user in db.Users)
                        {
                            if (user.Login == textBoxLogin.Text && user.Password == textBoxPassword.Text && user.Role == "Клиент")
                            {
                                int id = user.Id;
                                var query = from n in db.Clients
                                             join m in db.Users
                                             on n.User equals m
                                             where m.Id == id
                                             orderby n.Id
                                             select n.Id;
                                foreach (var w in query)
                                    id2 = $"{w}";
                                int id3 = Convert.ToInt32(id2);
                                Client client = db.Clients.Find(id3);
                                x = 1;
                                Klient form = new Klient(client);
                                form.textblock.Text = "Добро пожаловать в Личный кабинет, " + client.Name + "\n" + "Здесь можете задать вопрос детективу.";
                                form.Show();
                                this.Hide();
                            }
                            if (user.Login == textBoxLogin.Text && user.Password == textBoxPassword.Text && user.Role == "Детектив")
                            {
                                int id = user.Id;
                                var query = from n in db.Detectives
                                            join m in db.Users
                                            on n.User equals m
                                            where m.Id == id
                                            orderby n.Id
                                            select n.Id;
                                foreach (var w in query)
                                    id2 = $"{w}";
                                int id3 = Convert.ToInt32(id2);
                                Detective detective = db.Detectives.Find(id3);
                                x = 1;
                                Detectiv form = new Detectiv(detective);
                                form.textblock.Text = "Добро пожаловать в Личный кабинет, " + detective.Name + "\n" + "Здесь можете просматривать входящие заявки на консультацию, писать и отвечать на сообщения.";
                                form.Show();
                                this.Hide();
                            }
                            if (user.Login == textBoxLogin.Text && user.Password == textBoxPassword.Text && user.Role == "Администратор")
                            {
                                x = 1;
                                Admin form = new Admin();
                                form.Show();
                                this.Hide();
                            }
                        }
                        if (x == 0) { MessageBox.Show("Не существует пользователя с такими данными");}
                        
                    }
                }
                else { MessageBox.Show("Заполните все поля!"); }
            }
            catch { MessageBox.Show("Непредвиденная ошибка, повторите позже"); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Vostan form = new Vostan();
            form.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Registr form = new Registr();
            form.Show();
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
            this.Hide();
        }
    }
}
