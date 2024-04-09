using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Evalucall_Desktop
{
    public partial class HistoryER : Form
    {
        private string connectionString = "Server=127.0.0.1;Database=system-database;Uid=root;Pwd=;";
        private DataTable dataTable = new DataTable();
        public HistoryER()
        {
            InitializeComponent();
        }

        private void LoadDataIntoDataGridView()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM agentcalls"; // Replace YourTableName with your actual table name
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    //DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void HistoryER_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dataTable.DefaultView;
            if (dv != null)
            {
                StringBuilder filter = new StringBuilder();
                foreach (DataColumn column in dv.Table.Columns)
                {
                    filter.Append($"CONVERT({column.ColumnName}, 'System.String') LIKE '%{txtSearch.Text}%' OR ");
                }

                if (filter.Length > 0)
                    filter.Remove(filter.Length - 4, 4);

                dv.RowFilter = filter.ToString();

                dataGridView1.DataSource = dv.ToTable();
            }
        }
    }
}
