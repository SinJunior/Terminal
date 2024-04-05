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

namespace TrenDemo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities entities = new Entities();
        List<Tovar> orderTovar = new List<Tovar>();
        public MainWindow()
        {
            InitializeComponent();
            dataGridTovar.ItemsSource = entities.Tovar.ToList();
            buttonBasket.Visibility = Visibility.Hidden;
        }

        private void menuItemAddBasket_Click(object sender, RoutedEventArgs e)
        {
            var selectedTovar = dataGridTovar.SelectedItem as Tovar;
            if (selectedTovar != null)
            {
                orderTovar.Add(selectedTovar);
                buttonBasket.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Выбирите товар!", "Внимание !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonBasket_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowBasket(orderTovar);
            window.Show();
        }
    }
}
