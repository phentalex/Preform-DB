using MySql.Data.MySqlClient;
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

namespace Preform_DB
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private DataTable table;

        private SqlDataAdapter adapter = new SqlDataAdapter();


        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            table.Clear();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        Form1 f1 = new Form1();

        private void Form2_Load(object sender, EventArgs e)
        {
            
            adapter = new SqlDataAdapter("SELECT * FROM KA", );
            
            table = new DataTable();
            
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
