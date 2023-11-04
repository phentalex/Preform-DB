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

        private MySqlConnection con = null;

        private void Form2_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection(stroka);
            con.Open();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DataTable table_items = new DataTable();
            table_items.Clear();
            MySqlDataAdapter items = new MySqlDataAdapter("SELECT * FROM ITEMS", con);
            
            items.Fill(table_items);
            dataGridView1.DataSource = table_items;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataTable table_ka = new DataTable();
            table_ka.Clear();
            MySqlDataAdapter ka =  new MySqlDataAdapter("SELECT * FROM KA", con);

            ka.Fill(table_ka);
            dataGridView1.DataSource = table_ka;
        }
    }
}
