using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
using Microsoft.Win32;

namespace hotel
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            yourName.Text = "Ваше имя: " + App.Current.Properties["userName"].ToString();
            yourRole.Text = "Ваша роль: " + App.Current.Properties["userRole"].ToString();
            var userName = (string)App.Current.Properties["userName"];
            var getImage = App.Context.users.Where(n => n.login == userName).FirstOrDefault();
            if (getImage.image != null)
            {
                MemoryStream byteStream = new MemoryStream(getImage.image);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                avatar.Source = image;
            }

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {

            App.Current.Properties["userName"] = null;
            App.Current.Properties["userRole"] = null;
            yourName.Text = null;
            yourRole.Text = null;

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdPicture = new OpenFileDialog();
            ofdPicture.Filter = "Image files|*.jpg;*.jpeg;*.png";
            if (ofdPicture.ShowDialog() == true)
            {
                //avatar.Source = new BitmapImage(new Uri(ofdPicture.FileName));
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(ofdPicture.FileName);
                image.EndInit();

                avatar.Source = image;
                byte[] imageData = File.ReadAllBytes(ofdPicture.FileName);
                var userName = (string)App.Current.Properties["userName"];
                var getLogin = App.Context.users.FirstOrDefault(n => n.login == userName);
                if (getLogin != null)
                {
                    getLogin.image = imageData;
                    App.Context.SaveChanges();
                    MessageBox.Show("Картинка была изменена");
                }

            }
        }

        private void goWatchNumber_Click(object sender, RoutedEventArgs e)
        {
            hotelNumber HotelNumber = new hotelNumber();
            HotelNumber.Show();
        }
    }
}
