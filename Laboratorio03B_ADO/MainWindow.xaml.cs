using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Laboratorio03B_ADO.Views;

namespace Laboratorio03B_ADO
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStudentsDataTable_Click(object sender, RoutedEventArgs e) =>
            new StudentsDataTableView().Show();

        private void btnStudentsDataReader_Click(object sender, RoutedEventArgs e) =>
            new StudentsDataReaderView().Show();

        private void btnProductsDataTable_Click(object sender, RoutedEventArgs e) =>
            new ProductsDataTableView().Show();

        private void btnProductsDataReader_Click(object sender, RoutedEventArgs e) =>
            new ProductsDataReaderView().Show();
    }
}