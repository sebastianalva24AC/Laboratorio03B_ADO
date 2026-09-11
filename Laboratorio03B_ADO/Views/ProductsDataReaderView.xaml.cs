using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Laboratorio03B_ADO.Data;

namespace Laboratorio03B_ADO.Views
{
    public partial class ProductsDataReaderView : Window
    {
        private readonly DatabaseHelper _db = new DatabaseHelper();

        public ProductsDataReaderView()
        {
            InitializeComponent();
            dgProducts.ItemsSource = _db.GetProductsList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(txtMaxPrice.Text, out decimal maxPrice))
                dgProducts.ItemsSource = _db.SearchProductsByPrice(maxPrice);
            else
                MessageBox.Show("Ingresa un precio válido.");
        }
    }
}
