﻿using System;
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
            StartPosition = FormStartPosition.CenterScreen;
        }

        public static string stroka = "Server=localhost,3006;Database=preform;Uid=root;pwd=3128";


        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(stroka))
            {
                try
                {
                    con.Open();
                    MessageBox.Show("БД ПОДКЛЮЧЕНА");
                    this.Close();
                    th = new Thread(open);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                    con.Close();
                }
                catch
                {
                    MessageBox.Show("СОЕДИНЕНИЕ НЕ УСТАНОВЛЕНО", "ВНИМАНИЕ!");
                }
            }
        }
        public void open(object obj)
        {
            Application.Run(new Form_auth());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Cursor = Cursors.Default;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button1.Cursor = Cursors.Hand;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button1.Cursor = Cursors.Default;
        }
    }
}
