using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Data.SqlClient;

namespace Preform_DB
{
    public partial class Form1 : Form
    {
        Thread th;
        public Form1()
        {
            InitializeComponent();
        }

        public static string stroka = "Server=localhost,3006;Database=preform;Uid=root;pwd=3128";

        Form2 f2 = new Form2();

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(stroka))
            {
                try
                {
                    con.Open();
                    MessageBox.Show("DB CONNECTED");
                    this.Close();
                    th = new Thread(open);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                    con.Close();
                }
                catch
                {
                    MessageBox.Show("CONNECTION FAILED");
                }
            }
        }
        public void open(object obj)
        {
            Application.Run(new Form2());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
