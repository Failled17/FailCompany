using FailCompany.Resourses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FailCompany.MyPages
{
    /// <summary>
    /// Логика взаимодействия для RegiPage.xaml
    /// </summary>
    public partial class RegiPage : Window
    {
        DispatcherTimer timer;
        public static RegiPage Instance { get; set; }
        public RegiPage()
        {
            InitializeComponent();
        }

        private void RegFormBtn_Click(object sender, RoutedEventArgs e)
        {
            string loginn = LoginTb.Text.Trim();
            string pass = Password.Password;
            string pass_2 = Password_1.Password;
            string Phnum = PhNum.Text.Trim();
            string FName = FirstName.Text.Trim();
            string LName = LastName.Text.Trim();
            string patr = Patronymic.Text.Trim();
            string mail = Mail.Text.Trim();

            char[] chars = { '!', '@', '#', '$', '%', '^' };
            var check = App.db.User.Where(x => x.login == loginn).FirstOrDefault();
            if (check == null)
            {
                if (pass.Length > 5 && pass.Any(ch => Char.IsUpper(ch)) && pass.Any(ch => Char.IsLower(ch)) && pass.Any(ch => Char.IsDigit(ch)) && pass.Any(ch => chars.Contains(ch)))
                {
                    App.db.User.Add(new User
                    {
                        login = loginn,
                        password = pass,
                        lastname = LName,
                        firstname = FName,
                        patronymic = patr
                    });
                    App.db.SaveChanges();
                    MessageBox.Show("Сохранено!");
                    AutoPage task = new AutoPage();
                    task.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Проверьте На правильность заполнения");
                }
            }
            else
            {
                MessageBox.Show("Такой пользователь уже существует");
            }
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            AutoPage ask = new AutoPage();
            ask.Show();
            Close();
        }
        }
}




        
            
            
    

