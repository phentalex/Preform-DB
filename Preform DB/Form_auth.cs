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

        private string stroka = Form1.stroka;

        private MySqlConnection con = null;

        private void Form_auth_Load(object sender, EventArgs e)
        {
            textBox_pwd.PasswordChar = '*';
            pictureBox4.Visible = false;
            textBox_log.MaxLength = 50;
            textBox_pwd.MaxLength = 50;

            con = new MySqlConnection(stroka);
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_log.Text;
            var pwdUser = textBox_pwd.Text;

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
                th = new Thread(open);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                con.Close();
            } else
            {
                MessageBox.Show("Такого аккаунта не существует", "Ошибка входа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void open(object obj)
        {
            Application.Run(new Form2());
        }

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
            Form_reg form_reg = new Form_reg();
            this.Hide();
            form_reg.ShowDialog();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = SystemColors.ControlDark;
            label4.Cursor = Cursors.Hand;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = SystemColors.ControlText;
            label4.Cursor = DefaultCursor;
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
