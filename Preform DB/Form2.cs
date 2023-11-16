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
            StartPosition = FormStartPosition.CenterScreen;
        }

        private string stroka = Form1.myport;

        private MySqlConnection con = null;

        private void Form2_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection(stroka);
            con.Open();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DataTable table_product = new DataTable();
            table_product.Clear();
            MySqlDataAdapter items = new MySqlDataAdapter("SELECT * FROM products", con);
            
            items.Fill(table_product);
            dataGridView1.DataSource = table_product;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataTable table_customer = new DataTable();
            table_customer.Clear();
            MySqlDataAdapter ka =  new MySqlDataAdapter("SELECT * FROM customers", con);

            ka.Fill(table_customer);
            dataGridView1.DataSource = table_customer;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DataTable table_shipping = new DataTable();
            table_shipping.Clear();
            MySqlDataAdapter sales = new MySqlDataAdapter("SELECT * FROM shippings", con);

            sales.Fill(table_shipping);
            dataGridView1.DataSource = table_shipping;
        }
    }
}
