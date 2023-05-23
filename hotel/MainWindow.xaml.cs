using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
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
using hotel.Entities;

namespace hotel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void createAcc_Click(object sender, RoutedEventArgs e)
        {

            CreateAccount createAccount = new CreateAccount();

            createAccount.Show();

            this.Close();
        }

        public void Auth_Click(object sender, RoutedEventArgs e)
        {
            var getLogin = App.Context.users.Where(n => n.login == login.Text).FirstOrDefault();

            var getPassword = App.Context.users.Where(n => n.password == password.Password).FirstOrDefault();

            if (getLogin != null && getPassword != null)
            {
                var getRole = App.Context.Roles.Where(n => n.id_role == getLogin.id_role).FirstOrDefault().roleName;
                App.Current.Properties["userName"] = getLogin.login;
                App.Current.Properties["userRole"] = getRole;
                Profile profile = new Profile();
                profile.Show();
                this.Close();
            } else
            {
                MessageBox.Show("Не верный логин или пароль");
            }
        }
    }
}
