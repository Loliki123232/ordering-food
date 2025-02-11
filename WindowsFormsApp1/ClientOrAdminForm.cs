using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public partial class ClientOrAdminForm : Form
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Кирилл\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\ClientInto.mdf;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        public ClientOrAdminForm()
        {
            InitializeComponent();
            if (sqlConnection != null)
            {
                sqlConnection.Open();
                MessageBox.Show("Connection true");
            }
            else
            {
                MessageBox.Show("Connection false");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientForm form = new ClientForm();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminForm form = new AdminForm();
            form.ShowDialog();
        }

        private void ClientOrAdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}
