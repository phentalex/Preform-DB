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
using MySql.Data.MySqlClient;
using System.Web;
using System.Drawing.Text;
using System.Threading;

namespace Preform_DB
{
    public partial class Form_reg : Form
    {

        public Form_reg()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        Thread th;

        private string stroka = Form1.stroka;

        MySqlConnection con = null;

        private void Form_reg_Load(object sender, EventArgs e)
        {
            textBox_pwd.PasswordChar = '*';
            pictureBox4.Visible = false;
            textBox_log.MaxLength = 50;
            textBox_pwd.MaxLength = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new MySqlConnection(stroka);

            var loginUser = textBox_log.Text;
            var pwdUser = textBox_pwd.Text;

            string querystring = $"insert into register(login_user, pwd_user) values('{loginUser}', '{pwdUser}')";

            MySqlCommand command = new MySqlCommand(querystring, con);
            con.Open();
            if (checkUserInfo())
            {
                return;
            }

            if (checkUserLogin())
            {
                return;
            }

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                        Form_auth form_Auth = new Form_auth();
                        this.Hide();
                        form_Auth.ShowDialog();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Аккант не создан!", "Ошибка!");
                    }
        }
        private Boolean checkUserInfo()
        {
            var loginUser = textBox_log.Text;
            var pwdUser = textBox_pwd.Text;

            con = new MySqlConnection(stroka);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select login_user, pwd_user from register where login_user = '{loginUser}' and pwd_user = '{pwdUser}'";
            MySqlCommand command = new MySqlCommand(querystring, con);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            } else
            {
                return false;
            }
        }

        private Boolean checkUserLogin()
        {
            var loginUser = textBox_log.Text;

            con = new MySqlConnection(stroka);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select login_user from register where login_user = '{loginUser}'";
            MySqlCommand command = new MySqlCommand(querystring, con);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Cursor = Cursors.Hand;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Cursor = Cursors.Default;
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

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Cursor = Cursors.Hand;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Cursor = Cursors.Default;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openLog);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.Cursor = Cursors.Hand;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.Cursor = Cursors.Default;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Cursor = Cursors.Default;
        }

        private void openLog(object obj)
        {
            Application.Run(new Form_auth());
        }
    }
}
