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
    /// Логика взаимодействия для DeleteNumber.xaml
    /// </summary>
    public partial class DeleteNumber : Window
    {
        public DeleteNumber()
        {
            InitializeComponent();
        }

        private void DeleteNumber_Click(object sender, RoutedEventArgs e)
        {
            int NumberForDel = Convert.ToInt32(numberForDel.Text);

            if (!Regex.IsMatch(NumberForDel.ToString(), "^[0-9]+$"))
            {
                MessageBox.Show("Не доступен ввод иных символов, отличных от цифр");
            } else
            {
                var record = App.Context.hotelRooms.FirstOrDefault(x => x.id_number == NumberForDel);
                App.Context.hotelRooms.Remove(record);
                App.Context.SaveChanges();
                MessageBox.Show("Запись была удалена");
            }
        }
    }
}
