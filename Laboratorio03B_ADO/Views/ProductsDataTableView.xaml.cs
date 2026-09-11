using System.Windows;
using Laboratorio03B_ADO.Data;

namespace Laboratorio03B_ADO.Views
{
    public partial class ProductsDataTableView : Window
    {
        private readonly DatabaseHelper _db = new DatabaseHelper();

        public ProductsDataTableView()
        {
            InitializeComponent();
            dgProducts.ItemsSource = _db.GetProductsDataTable().DefaultView;
        }
    }
}