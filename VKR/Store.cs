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
using Excel = Microsoft.Office.Interop.Excel;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Net.NetworkInformation;

namespace VKR
{
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class Store : Form
    {
        private SqlConnection sqlConnection = null;
        int SelectedRow;
        private DataTable tb = null;
        private readonly CheckUser _user;
        

        public Store(CheckUser user)
        {
            _user = user;
            InitializeComponent();
        }

        private void isAdmin()
        {
            toolStrip1.Enabled = _user.IsAdmin;
            New_entry.Enabled = _user.IsAdmin;
            Delete.Enabled = _user.IsAdmin;
            Change.Enabled = _user.IsAdmin;
            Save.Enabled = _user.IsAdmin;
            text_encr.Enabled = _user.IsAdmin;
            pictureBox2.Enabled = _user.IsAdmin;
            pictureBox3.Enabled = _user.IsAdmin;
            export.Enabled = _user.IsAdmin;
            Registr.Enabled = _user.IsAdmin;

        }

        private void CreatColums()
        {
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("type_of", "Тип товара");
            dataGridView1.Columns.Add("count_of", "Количество");
            dataGridView1.Columns.Add("postavka", "Поставщик");
            dataGridView1.Columns.Add("price", "Цена");
            dataGridView1.Columns.Add("ISNew", string.Empty);

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetString(3), record.GetInt32(4), RowState.ModifiedNew);
        }

        private void RefreshData(DataGridView dgw)
        {
            dgw.Rows.Clear();
            sqlConnection = new SqlConnection((ConfigurationManager.ConnectionStrings["Store"].ConnectionString.Replace("%Path%", Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\Store.mdf")));
            sqlConnection.Open();
            string queryString = $"SELECT * FROM Store";
            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            
            SqlDataReader reader = command.ExecuteReader();
            
            while(reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
            sqlConnection.Close();
        }

        private void Store_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = $"{_user.Login}: {_user.Status}";
            isAdmin();
            CreatColums();
            RefreshData(dataGridView1);

            
        }


        private void Close3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[SelectedRow];
                ID.Text = row.Cells[0].Value.ToString();
                type_of.Text = row.Cells[1].Value.ToString();
                count_of.Text = row.Cells[2].Value.ToString();
                postavka.Text = row.Cells[3].Value.ToString();
                text_price.Text = row.Cells[4].Value.ToString();

            }
        }

        private void New_entry_Click(object sender, EventArgs e)
        {
            NewEntry frmNewEntry = new NewEntry();
            frmNewEntry.Show();
        }

        


        private void Searh_TextChanged(object sender, EventArgs e)
        {

        }

        private void Searh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = tb.DefaultView;
                dv.RowFilter = string.Format("type_of like '%{0}%'", Searh.Text);
                dataGridView1.DataSource = dv.ToTable();
            }

        }


        private void Delete_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand del = new SqlCommand("DELETE [Store] WHERE ID = @Id", sqlConnection);

            del.Parameters.AddWithValue("@Id", ID.Text);

            del.ExecuteNonQuery();
            MessageBox.Show("Удалено");

            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Store", sqlConnection);

            DataSet db = new DataSet();

            dataAdapter.Fill(db);
            sqlConnection.Close();
        }

        private void UpDate()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Store"].ConnectionString);
            sqlConnection.Open();

            for(int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)
                    continue;
                if(rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var type = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var count = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var postav = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var price = dataGridView1.Rows[index].Cells[4].Value.ToString();

                    var changeQuery = $"UPDATE Store set type_of ='{type}', count_of ='{count}', postavka ='{postav}', price ='{price}' where Id = '{id}'";

                    var command = new SqlCommand(changeQuery, sqlConnection);
                    command.ExecuteNonQuery();

                }
            }
            sqlConnection.Close();
          


        }
        private void Save_Click(object sender, EventArgs e)
        {
            UpDate();
        }

        private void export_Click(object sender, EventArgs e)
        {

            Excel.Application exApp = new Excel.Application();

            exApp.Workbooks.Add();
            Excel.Worksheet wish = (Excel.Worksheet)exApp.ActiveSheet;
            int i, j;
            for (i = 0; i <= dataGridView1.RowCount - 2; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    wish.Cells[i + 1, j + 1] = dataGridView1[j, i].Value.ToString();
                }
            }

            exApp.Visible = true;
        }

        static string sKey;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sKey = text_encr.Text;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string source = openFileDialog1.FileName;
                saveFileDialog1.Filter = "des files |*.des";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string destination = saveFileDialog1.FileName;
                    EncryptFile(source, destination, sKey);
                }
            }
        }

        private void EncryptFile(string source, string destination, string sKey)
        {
            FileStream fsInput = new FileStream(source, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(destination, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            try
            {
                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                ICryptoTransform desencrypt = DES.CreateEncryptor();
                CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);
                byte[] bytearrayinput = new byte[fsInput.Length - 0];
                fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                return;
            }
            fsInput.Close();
            fsEncrypted.Close();
        }

        private void DecryptFile(string source, string destination, string sKey)
        {
            FileStream fsInput = new FileStream(source, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(destination, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            try
            {
                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                ICryptoTransform desencrypt = DES.CreateDecryptor();
                CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);
                byte[] bytearrayinput = new byte[fsInput.Length - 0];
                fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                return;
            }
            fsInput.Close();
            fsEncrypted.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            sKey = text_encr.Text;
            openFileDialog1.Filter = "des files |*.des";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string source = openFileDialog1.FileName;
                saveFileDialog1.Filter = "exel files |*.xlsx";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string destination = saveFileDialog1.FileName;
                    DecryptFile(source, destination, sKey);
                }
            }
        }
        public static ManualResetEvent connectDone = new ManualResetEvent(false);

        private void Chg()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            var id = ID.Text;
            var type = type_of.Text;
            var count = count_of.Text;
            var postav = postavka.Text;
            int price;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if(int.TryParse(text_price.Text, out price))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, type, count, postav, price);
                    dataGridView1.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Ошибка! Цена должна иметь числовой формат!");
                }
            }
        }
        private void Change_Click(object sender, EventArgs e)
        {
            Chg();
        }

        private void Update_icon_Click(object sender, EventArgs e)
        {
            RefreshData(dataGridView1);
        }

        private void Registr_Click(object sender, EventArgs e)
        {
            Registration frmRegistration = new Registration();
            this.Hide();
            frmRegistration.ShowDialog();
            this.Show();
        }
    }
}
