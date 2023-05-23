using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using hotel.Entities;

namespace hotel
{
    /// <summary>
    /// Логика взаимодействия для hotelNumber.xaml
    /// </summary>
    public partial class hotelNumber : Window
    {
        public hotelNumber()
        {
            InitializeComponent();

            var gethotelRooms = App.Context.hotelRooms.ToList();
            foreach (var hotelRoom in gethotelRooms)
            {
                listBox.Items.Add(new hotelRoom
                {
                    id_number = hotelRoom.id_number,
                    numberOfPeople = hotelRoom.numberOfPeople,
                    pricePerDay = hotelRoom.pricePerDay,
                    comfort = hotelRoom.comfort,
                    status = hotelRoom.status
                });
            };
        }

        private void AddNumber_Click(object sender, RoutedEventArgs e)
        {
            AddNumber addNumber = new AddNumber();
            addNumber.Show();
        }

        private void DeleteNumber_Click(object sender, RoutedEventArgs e)
        {
            DeleteNumber deleteNumber = new DeleteNumber();
            deleteNumber.Show();
        }

        private void UpdateNumber_Click(object sender, RoutedEventArgs e)
        {
            UpdateNumber updateNumber = new UpdateNumber();
            updateNumber.Show();
        }
    }
}
