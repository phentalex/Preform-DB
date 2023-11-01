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
using System.Web;
using System.Windows.Forms;

namespace Preform_DB
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private string stroka = Form1.stroka;

        private DataTable table;

        private MySqlConnection con = null;

        private MySqlDataAdapter adapter = null;

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            table.Clear();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection(stroka);
            con.Open();

            adapter = new MySqlDataAdapter("SELECT * FROM KA", con);
            
            table = new DataTable();
        }
    }
}
