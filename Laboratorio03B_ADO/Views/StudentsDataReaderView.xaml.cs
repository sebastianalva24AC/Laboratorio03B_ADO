using System.Windows;
using Laboratorio03B_ADO.Data;

namespace Laboratorio03B_ADO.Views
{
    public partial class StudentsDataReaderView : Window
    {
        private readonly DatabaseHelper _db = new DatabaseHelper();

        public StudentsDataReaderView()
        {
            InitializeComponent();
            dgStudents.ItemsSource = _db.GetStudentsList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            dgStudents.ItemsSource = _db.SearchStudentsByName(txtSearchName.Text);
        }
    }
}