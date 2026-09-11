using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;
using Laboratorio03B_ADO.Models;

namespace Laboratorio03B_ADO.Data
{
    public class DatabaseHelper
    {
        private const string ConnectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=Tecsup2026DB;Trusted_Connection=True;";

        // ---------- STUDENTS ----------

        public DataTable GetStudentsDataTable()
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(
                    "SELECT StudentId, FirstName, LastName FROM Students", conn);
                adapter.Fill(table);
            }
            return table;
        }

        public List<Student> GetStudentsList()
        {
            var students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("SELECT StudentId, FirstName, LastName FROM Students", conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            StudentId = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2)
                        });
                    }
                }
            }
            return students;
        }

        public List<Student> SearchStudentsByName(string name)
        {
            var students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(
                    "SELECT StudentId, FirstName, LastName FROM Students WHERE FirstName LIKE @name OR LastName LIKE @name", conn);
                cmd.Parameters.AddWithValue("@name", "%" + name + "%");
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            StudentId = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2)
                        });
                    }
                }
            }
            return students;
        }

        // ---------- PRODUCTS ----------

        public DataTable GetProductsDataTable()
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(
                    "SELECT ProductId, Name, Price FROM Products", conn);
                adapter.Fill(table);
            }
            return table;
        }

        public List<Product> GetProductsList()
        {
            var products = new List<Product>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("SELECT ProductId, Name, Price FROM Products", conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2)
                        });
                    }
                }
            }
            return products;
        }

        public List<Product> SearchProductsByPrice(decimal maxPrice)
        {
            var products = new List<Product>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("SELECT ProductId, Name, Price FROM Products WHERE Price <= @maxPrice", conn);
                cmd.Parameters.AddWithValue("@maxPrice", maxPrice);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2)
                        });
                    }
                }
            }
            return products;
        }
    }
}