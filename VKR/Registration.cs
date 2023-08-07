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
    public partial class Registration : Form
    {
        private SqlConnection sqlConnection = null;
        
        public Registration()
        {
            InitializeComponent();
        }

        private void REGISTR_Click(object sender, EventArgs e)
        {
            var login = LoginReg.Text;
            var pass = PasswordReg.Text;

            
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);
            sqlConnection.Open();

            string querystring = $"INSERT INTO Users (login, password, is_admin) VALUES ('{login}','{pass}', 0) ";
            SqlCommand command = new SqlCommand(querystring, sqlConnection);
           
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Регистрация прошла успешно!");
                Authorization frmAut = new Authorization();
                this.Hide();
                frmAut.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Ошибка регистрации!");
            }

            sqlConnection.Close();

        }
        
    }
}
