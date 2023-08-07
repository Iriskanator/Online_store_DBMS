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
using System.IO;

namespace VKR
{
    
    public partial class Authorization : Form
    {
        public SqlConnection sqlConnection = null;
        
        public Authorization()
        {
            InitializeComponent();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString.Replace("%Path%", Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\Users.mdf"));
            sqlConnection.Open();
            textBox1.MaxLength = 50;
            textBox2.MaxLength = 50;
        }

        private void Entry_Click(object sender, EventArgs e)
        {
            var loginUser = textBox1.Text;
            var passwordUser = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"SELECT Id_Users, login, password, is_admin FROM Users WHERE login = '{loginUser}' and password = '{passwordUser}'";

            SqlCommand command = new SqlCommand(queryString, sqlConnection);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                var user = new CheckUser(table.Rows[0].ItemArray[1].ToString(), Convert.ToBoolean(table.Rows[0].ItemArray[3]));


                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Store frmAdmin = new Store(user);
                this.Hide();
                frmAdmin.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Такого аккаунта не существует!");
        }

        private void Close1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
