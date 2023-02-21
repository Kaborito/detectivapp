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
    /// Логика взаимодействия для DetectivSms.xaml
    /// </summary>
    public partial class DetectivSms : Window
    {
        Detective Detective;
        Client Client;
        Sms Sms;
        TextBox body;
        EntityModelContainer db = new EntityModelContainer();
        string text;

        public DetectivSms(Detective detective, Client client)
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
            Detective = detective;
            Client = client;
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Detectiv form = new Detectiv(Detective);
            form.textblock.Text = "Добро пожаловать в Личный кабинет, " + Detective.Name + "\n" + "Здесь можете просматривать входящие заявки на консультацию, писать и отвечать на сообщения.";
            form.Show();
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DetectiveSmses form = new DetectiveSmses(Detective);
            form.Show();
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                int DetId = Detective.Id;
                int ClId = Client.Id;
                var query = from n in db.Smss
                            where n.DetectiveId == DetId && n.ClientId == ClId
                            orderby n.Id
                            select new { n.Id };

                foreach (var w in query)
                    text = text + "," + $"{w}";

                if (text.Contains("Id"))
                {

                    text = text.Replace("Id", "");
                    text = text.Replace("=", "");
                    text = text.Replace(" ", "");
                    text = text.Replace("{", "");
                    text = text.Replace("}", "");
                    text = text.Substring(1);
                    string[] m = text.Split(new char[] { ',' }); //[1, 2, 3]
                    int dl = m.Length;
                    int sch = 0;
                    while (dl != 0)
                    {
                        int id = Convert.ToInt32(m[sch]);
                        Sms = db.Smss.Find(id);
                        body = new TextBox();
                        body.Style = (Style)Resources["Text"];
                        body.Text = Sms.Sender + "  |    " + Sms.Text;
                        stack.Children.Add(body);
                        dl = dl - 1;
                        sch = sch + 1;
                        scroll.ScrollToEnd();
                    }
                }
                else { }
            }
            catch{}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBoxMessage.Text != "")
                {
                    if (textBoxMessage.Text.Length < 90)
                    {
                        Sms sms = new Sms();
                        sms.Text = textBoxMessage.Text;
                        sms.Sender = "Детектив";
                        sms.DetectiveId = Detective.Id;
                        sms.ClientId = Client.Id;
                        db.Smss.Add(sms);
                        db.SaveChanges();

                        body = new TextBox();
                        body.Style = (Style)Resources["Text"];
                        body.Text = "Детектив" + "  |    " + textBoxMessage.Text;
                        stack.Children.Add(body);
                        scroll.ScrollToEnd();
                        textBoxMessage.Text = "";
                    }
                    else { MessageBox.Show("Сообщение длинное, ограничение - 90 символов"); }
                }
                else { MessageBox.Show("Сообщение пустое!"); }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
