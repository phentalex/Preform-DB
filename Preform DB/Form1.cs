using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace Preform_DB
{
    public partial class Form1 : Form
    {
        Thread th;
        public Form1()
        {
            InitializeComponent();
        }

        Form2 f2 = new Form2();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "Server=localhost;Database=preform;port=3306;Uid=root;pwd=3128";
                MySqlConnection mycon = new MySqlConnection(path);
                mycon.Open();
                MessageBox.Show("DB CONNECTED");
                this.Close();
                th = new Thread(open);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                f2.LabelConn.Text = path;
            }
            catch
            {
                MessageBox.Show("CONNECTION FAILED");
            }
        }
        public void open(object obj)
        {
            Application.Run(new Form2());
        }
    }
}
