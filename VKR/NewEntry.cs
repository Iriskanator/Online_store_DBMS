using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace VKR
{
    public partial class NewEntry : Form
    {
        private SqlConnection sqlConnection = null;
        public NewEntry()
        {
            InitializeComponent();
        }

        private void New_Save_Click(object sender, EventArgs e)
        {
            int price;
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Store"].ConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand(
                   $"INSERT INTO[Store] (type_of, count_of, postavka, price) VALUES (@type_of, @count_of, @postavka, @price)", sqlConnection);


            command.Parameters.AddWithValue("type_of", New_type_of.Text);
            command.Parameters.AddWithValue("count_of", New_count_of.Text);
            command.Parameters.AddWithValue("postavka", New_postavka.Text);
            command.Parameters.AddWithValue("price", New_price.Text);

            if(int.TryParse(New_price.Text, out price))
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Запись создана!");

            }
            else
            {
                MessageBox.Show("Ошибка!");
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Store", sqlConnection);

            DataSet db = new DataSet();

            dataAdapter.Fill(db);
            sqlConnection.Close();

        }
    }
}
