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

            dishPrices.Add("Карпача из лосося", 5.00m);
            dishPrices.Add("Борщ", 7.50m);
            dishPrices.Add("Салат", 6.00m);
            dishPrices.Add("Чай", 2.00m);
            dishPrices.Add("Кофе", 4.50m);
            dishPrices.Add("Гренки", 5.30m);
            dishPrices.Add("Паста", 12.00m);
            dishPrices.Add("Пицца", 8.70m);
            dishPrices.Add("Кока Кола", 3.45m);
            dishPrices.Add("Пельмени", 8.25m);
            dishPrices.Add("Бургер", 13.25m);
            dishPrices.Add("Роллы", 10.10m);

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
        private void bntSaveInfo(object sender, EventArgs e)
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


        private void btnCheckPrice(object sender, EventArgs e)
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