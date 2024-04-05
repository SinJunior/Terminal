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

namespace TrenDemo.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowCheck.xaml
    /// </summary>
    public partial class WindowCheck : Window
    {
        List<Tovar> orderTovar = new List<Tovar>();
        Entities entities = new Entities();
        public WindowCheck(List<Tovar> ordertovar, Orders order)
        {
            InitializeComponent();
            orderTovar = ordertovar;

            textBlockCheckInfo.Text = "\n+===================+";
            textBlockCheckInfo.Text += $"\n| Заказ № {order.O_Id} от {order.O_Date.ToShortDateString()} |";
            textBlockCheckInfo.Text += "\n+===================+";
            foreach (var tovar in orderTovar)
            {
                textBlockCheckInfo.Text += $"\n{tovar.T_Name} ------------ {tovar.T_Price} руб.";
            }
            textBlockCheckInfo.Text += "\n+===================+";
            textBlockCheckInfo.Text += $"\nОбщая стоимость: {orderTovar.Sum(tovar => tovar.totalPrice)} руб.";
            textBlockCheckInfo.Text += $"\nРазмер скидки: {orderTovar.Sum(tovar => tovar.T_Price) - orderTovar.Sum(tovar => tovar.totalPrice)} руб.";
            textBlockCheckInfo.Text += $"\nПункт выдачи: {order.PickPoint.P_Adress}";
            textBlockCheckInfo.Text += $"\nКод получения: {order.O_Code}";
            if(orderTovar.Min(tovar => tovar.T_Count) > 4)
            {
                textBlockCheckInfo.Text += $"\nСрок доставки - 2 дня";
            }
            else
            {
                textBlockCheckInfo.Text += $"\nСрок доставки - 7 дней";
            }
            textBlockCheckInfo.Text += "\n+===================+";
        }

        private void buttonSaveCheck_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog saveFileDialog = new PrintDialog();
            if(saveFileDialog.ShowDialog() == true )
            {
                IDocumentPaginatorSource ipd = CheckOrder;
                saveFileDialog.PrintDocument(ipd.DocumentPaginator, "Flow Document");
            }
        }
    }
}
