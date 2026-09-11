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
    public partial class StudentsDataTableView : Window
    {
        private readonly DatabaseHelper _db = new DatabaseHelper();

        public StudentsDataTableView()
        {
            InitializeComponent();
            dgStudents.ItemsSource = _db.GetStudentsDataTable().DefaultView;
        }
    }
}
