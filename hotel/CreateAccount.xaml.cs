using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using System.Text.RegularExpressions;
using hotel.Entities;

namespace hotel
{
    /// <summary>
    /// Логика взаимодействия для CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void createAcc_Click(object sender, RoutedEventArgs e)
        {
            string Login = login.Text;
            Login = Login.Replace(" ", "");
            string Password = password.Text;
            Password = Password.Replace(" ", "");

            string RepPassword = repPassword.Text;

            var CheckLogin = App.Context.users.Where(n => n.login == Login).FirstOrDefault();
            if (CheckLogin == null) {
                if (Login == "")
                {
                    MessageBox.Show("Логин не был введен");
                } else if (Login.Length < 4 || Login.Length > 15)
                {
                    MessageBox.Show("Длина логина должна быть больше 3 и не более 15");
                } else if (!Regex.IsMatch(Login, "^[A-Za-z0-9]+$"))
                {
                    MessageBox.Show("Логин может состоять только из английских букв и цифр");
                } else if (Password == "")
                {
                    MessageBox.Show("Пароль не был введен");
                } else if (Password.Length < 8)
                {
                    MessageBox.Show("Пароль должен быть минимум 8 символов");
                } else if (!(Regex.IsMatch(Password, "[a-z]") &&
                           Regex.IsMatch(Password, "[A-Z]") &&
                           Regex.IsMatch(Password, "[0-9]") &&
                           Regex.IsMatch(Password, "[~`!@#$%^&*()_+=]")))
                {
                    MessageBox.Show("Пароль должен состоять из английских букв, минимум одной цифры, заглавной буквы и спец символа. Доступные спец символы: ~ ` ! @ # $ % ^ & * ( ) _ + =");
                } else if (Password != RepPassword)
                {
                    MessageBox.Show("Пароли не совпадают");
                } else
                {
                    var userAdd = new Entities.user
                    {
                        login = Login,
                        password = Password,
                        id_role = 2
                    };
                    App.Context.users.Add(userAdd);
                    App.Context.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно");
                }
            }
            else
            {
                MessageBox.Show("Пользователь с таким именем уже есть");
            }
            /*if ()
            {

            }
            else
            {
                *//*var userAdd = new hotel.Entities.user
                {
                    login = login.Text,
                    password = password.Text,
                    id_role = 1,
                    image = null

                };
                App.Context.users.Add(userAdd);*//*
                MessageBox.Show("Регистрация прошла успешно");
            }*/
        }
    }
}
