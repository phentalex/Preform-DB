using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preform_DB
{
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }


        //Переход между кнопками

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }

        //Вкладка личный кабинет

        private void label1_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            label2.Visible = true;
            label1.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            label1.Visible = true;
            label2.Visible = false;
        }

        //Вкладка Отгрузки
    }
}
