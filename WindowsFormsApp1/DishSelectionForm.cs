using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DishSelectionForm : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Кирилл\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\ClientInto.mdf;Integrated Security=True";
        private Dictionary<string, decimal> dishPrices = new Dictionary<string, decimal>();
        private decimal totalCost;
        public DishSelectionForm()
        {
            InitializeComponent();

            dishPrices.Add("Картошка", 5.00m);
            dishPrices.Add("Суп", 7.50m);
            dishPrices.Add("Салат", 6.00m);
            dishPrices.Add("Чай", 2.00m);

            foreach (string dish in dishPrices.Keys)
            {
                comboBox1.Items.Add(dish);
            }
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("3");
            comboBox2.Items.Add("4");
            comboBox2.Items.Add("5");
            comboBox2.Items.Add("6");
            comboBox2.Items.Add("7");
            comboBox2.Items.Add("8");
            comboBox2.Items.Add("9");
            comboBox2.Items.Add("10");

        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите блюдо и количество.");
                return;
            }


            string selectedName = comboBox1.SelectedItem.ToString();
            string selectedQuantityString = comboBox2.SelectedItem.ToString();

            if (!int.TryParse(selectedQuantityString, out int selectedQuantity))
            {
                MessageBox.Show("Некорректное значение в ComboBox2. Пожалуйста, выберите число.");
                return;
            }

            SaveSelectedValueToDatabase(selectedName, selectedQuantity, (int)totalCost);
        }
        private void SaveSelectedValueToDatabase(string Name, int Quantity, int totalPrice)
        {
            string query = "INSERT INTO Dishes (Name, Quantity, TotalPrice) VALUES (@name, @quantity, @totalPrice)";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    sqlConnection.Open();
                    command.Parameters.AddWithValue("@name", Name);
                    command.Parameters.AddWithValue("@quantity", Quantity);
                    command.Parameters.AddWithValue("@TotalPrice", totalPrice);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите блюдо и количество.");
                return;
            }
            string selectedDish = comboBox1.SelectedItem.ToString();
            string selectedQuantityString = comboBox2.SelectedItem.ToString();
            decimal selectedPrice;
            if (!int.TryParse(selectedQuantityString, out int selectedQuantity))
            {
                MessageBox.Show("Некорректное значение в ComboBox2. Пожалуйста, выберите число.");
                return;
            }
            if (!dishPrices.ContainsKey(selectedDish))
            {
                MessageBox.Show("Для выбранного блюда нет цены.");
                return;
            }
            else
            {
                selectedPrice = dishPrices[selectedDish];
            }
            totalCost = selectedPrice * selectedQuantity;
            labelTotal.Text = $"Итоговая стоимость: {totalCost:C}";
        }

     
    }
}