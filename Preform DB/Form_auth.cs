using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace Preform_DB
{
    public partial class Form_auth : Form
    {
        Thread th;
        public Form_auth()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public static string myport = "server = 31.31.198.106,3306; database = u2327525_preform; uid = u2327525_admin; password = admin123; connection timeout = 180";
        
        public static MySqlConnection con = new MySqlConnection(myport);
        public static bool ConnectionCheck()
        {
            try
            {
                con.Open();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        

        private void Form_auth_Load(object sender, EventArgs e)
        {
            textBox_pwd.PasswordChar = '*';
            pictureBox4.Visible = false;
            textBox_log.MaxLength = 50;
            textBox_pwd.MaxLength = 50;
            if (ConnectionCheck() == true)
            {
                MessageBox.Show("Соединение с базой: Установлено!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Соединение с базой: Не установлено!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_log.Text;
            var pwdUser = textBox_pwd.Text;

            con.Open();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select login_user, pwd_user from register where login_user = '{loginUser}' and pwd_user = '{pwdUser}'";

            MySqlCommand command = new MySqlCommand(querystring, con);
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                th = new Thread(openMain);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                con.Close();
            } else
            {
                MessageBox.Show("Такого аккаунта не существует", "Ошибка входа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void openMain(object obj)
        {
            Application.Run(new Form_main());
        }

        //***
        public void openReg(object obj)
        {
            Application.Run(new Form_reg());
        }
        //***
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;

            textBox_pwd.PasswordChar = '\0';
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
            pictureBox3.Visible = true;

            textBox_pwd.PasswordChar = '*';
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openReg);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Cursor = Cursors.Hand;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Cursor = Cursors.Default;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Cursor = Cursors.Hand;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Cursor = Cursors.Default;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Cursor = Cursors.Default;
        }
    }
}
