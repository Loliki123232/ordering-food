using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminForm : Form
    {

        SqlCommand command = new SqlCommand();
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadDataClients();
            LoadDataDishes();
        }
        private void LoadDataClients()
        {
            try
            {

                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Кирилл\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\ClientInto.mdf;Integrated Security=True"))
                {
                   
                    string query = "SELECT * FROM Clients";

                    // Создаем объект адаптера данных
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                      
                        DataTable dataTable = new DataTable();
                        
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataDishes()
        {
            try
            {

                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Кирилл\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\ClientInto.mdf;Integrated Security=True"))
                {

                    string query = "SELECT * FROM Dishes";

                    // Создаем объект адаптера данных
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {

                        DataTable dataTable = new DataTable();

                        adapter.Fill(dataTable);

                        dataGridView2.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
