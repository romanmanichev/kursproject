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
using System.Text.RegularExpressions;

namespace hotel
{
    /// <summary>
    /// Логика взаимодействия для AddNumber.xaml
    /// </summary>
    public partial class AddNumber : Window
    {
        public AddNumber()
        {
            InitializeComponent();
        }

        private void AddNumber_Click(object sender, RoutedEventArgs e)
        {

            string PricePerDay = pricePerDay.Text;
            string NumberOfPeople = numberOfPeople.Text;
            string Comfort = comfort.Text;
            string Status = status.Text;
            int Id_number = Convert.ToInt32(id_number.Text);
            int CheckId = 0;

            var getSameIdCheck = App.Context.hotelRooms.ToList();

            if (!Regex.IsMatch(PricePerDay, "^[0-9]+$"))
            {
                MessageBox.Show("Не доступен ввод иных символов, отличных от цифр в строке \"Цена за сутки\"");
            }
            else if (!Regex.IsMatch(NumberOfPeople, "^[0-9]+$"))
            {
                MessageBox.Show("Не доступен ввод иных символов, отличных от цифр в строке \"Количество человек\"");
            }
            else if (!Regex.IsMatch(Comfort, "^[А-Яа-я]+$"))
            {
                MessageBox.Show("Не доступен ввод иных символов, отличных от букв в строке \"Комфорт\"");
            }
            else if (!Regex.IsMatch(Status, "^[а-я]+$"))
            {
                MessageBox.Show("Не доступен ввод иных символов, отличных от цифр в строке \"Статус\"");
            }
            else
            {
                foreach (var i in getSameIdCheck)
                {
                    if (i.id_number == Id_number)
                    {
                        CheckId = 1;
                        MessageBox.Show("Номер такой комнаты уже есть в строке \"Номер комнаты\"");
                        break;
                    }
                }

                if (CheckId == 0)
                {
                    var data = new Entities.hotelRoom
                    {
                        id_number = Id_number,
                        pricePerDay = Convert.ToInt32(PricePerDay),
                        numberOfPeople = Convert.ToInt32(NumberOfPeople),
                        comfort = Comfort,
                        status = Status
                    };


                    App.Context.hotelRooms.Add(data);
                    App.Context.SaveChanges();
                }
            }
        }
    }
}
