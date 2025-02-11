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
    public partial class ClientForm : Form
    {

        SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Кирилл\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\ClientInto.mdf;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_SaveInfo(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string query = "INSERT INTO Clients (Address, House, PhoneNumber) VALUES (@address, @house, @phone)";

            using (var cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@address", addressTextBox.Text);
                cmd.Parameters.AddWithValue("@house", houseTextBox.Text);
                cmd.Parameters.AddWithValue("@phone", phoneTextBox.Text);
                cmd.ExecuteNonQuery();
            }
            DishSelectionForm dishSelectionForm = new DishSelectionForm();
            dishSelectionForm.ShowDialog();
        }
    }
}
