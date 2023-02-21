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
    /// Логика взаимодействия для Zayavka.xaml
    /// </summary>
    public partial class Zayavki : Window
    {
        public Zayavki()
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBoxName.Text != "" && textBoxNumber.Text != "" && textBoxTextUslugi.Text != "")
                {
                    if (textBoxTextUslugi.Text.Length < 100)
                    {
                        using (EntityModelContainer db = new EntityModelContainer())
                        {
                            int CountDetectives = db.Detectives.Count();
                            Random rnd = new Random();
                            int id = rnd.Next(1, CountDetectives + 1);
                            Detective detective = db.Detectives.Find(id);
                            Zayavka zayavka = new Zayavka() { Detective = detective, Name = textBoxName.Text, Number = textBoxNumber.Text, TextZayavki = textBoxTextUslugi.Text, Status = "На рассмотрении" };
                            db.Zayavkas.Add(zayavka);
                            db.SaveChanges();
                        }
                    }
                    else { MessageBox.Show("Текст заявки длинный, ограничение - 100 символов"); }

                }
                else { MessageBox.Show("Заполните все поля!"); }
            }
            catch
            {
                MessageBox.Show("Произошла непредвиденная ошибка, повторите попытку позже");
            }
            this.Hide();
        }

    }
}
