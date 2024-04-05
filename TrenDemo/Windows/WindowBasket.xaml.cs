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
using TrenDemo.Windows;

namespace TrenDemo
{
    /// <summary>
    /// Логика взаимодействия для WindowBasket.xaml
    /// </summary>
    public partial class WindowBasket : Window
    {
        Entities entities = new Entities();
        List<Tovar> orderTovar = new List<Tovar>();
        public WindowBasket(List<Tovar> ordertovar)
        {
            InitializeComponent();
            orderTovar = ordertovar;
            foreach (var adress in entities.PickPoint)
            {
                comboBoxPunkt.Items.Add(adress);
            }

            dataGridTovar.ItemsSource = orderTovar;
            lableCost.Content = $"Общая стоимость: {orderTovar.Sum(tovar => tovar.totalPrice)} руб.";
            lableDiscount.Content = $"Размер скидки: {orderTovar.Sum(tovar => tovar.T_Price) - orderTovar.Sum(tovar => tovar.totalPrice)} руб.";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedTovar = dataGridTovar.SelectedItem as Tovar;

            if (selectedTovar != null)
            {
                var rezult = MessageBox.Show("Вы уверены что хотите удалить товар из корзины ?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);

                orderTovar.Remove(selectedTovar);
                dataGridTovar.ItemsSource = null;
                dataGridTovar.ItemsSource = orderTovar;
                lableCost.Content = $"Общая стоимость: {orderTovar.Sum(tovar => tovar.totalPrice)} руб.";
                lableDiscount.Content = $"Размер скидки: {orderTovar.Sum(tovar => tovar.T_Price) - orderTovar.Sum(tovar => tovar.totalPrice)} руб.";
            }
        }

        private void buttonOrderAccess_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            var selectedAdress = comboBoxPunkt.SelectedItem as PickPoint;

            if(selectedAdress != null)
            {
                Orders newOrder = new Orders();
                entities.Orders.Add(newOrder);
                newOrder.O_Date = DateTime.Now;
                newOrder.O_Status = "Новый";
                newOrder.O_Code = random.Next(100, 999);
                newOrder.O_PickPoint = (comboBoxPunkt.SelectedItem as PickPoint).P_Id;
                entities.SaveChanges();

                foreach(var tovars in orderTovar)
                {
                    Orders_Tovar newOrdersTovar = new Orders_Tovar();
                    entities.Orders_Tovar.Add(newOrdersTovar);
                    newOrdersTovar.OT_Id_Order = newOrder.O_Id;
                    newOrdersTovar.OT_Id_Tovar = tovars.T_Id;
                    entities.SaveChanges();
                }
                MessageBox.Show("Заказ успешено сформирован!", "Успех!",MessageBoxButton.OK, MessageBoxImage.Information);
                var window = new WindowCheck(orderTovar, newOrder);
                window.ShowDialog();
            }
        }
    }
}
