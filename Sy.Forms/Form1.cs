using Sy.Core.ComplexTypes;
using Sy.Core.Enums;
using Sy.Forms.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Sy.Forms
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            
            groupBox1.Visible = true;
            label1.Visible = false;
            menuStrip1.Visible = false;
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            frm.ShowDialog();
            if (StockSettings.UserInfo == null)
            {
                groupBox1.Visible = true;
                label1.Visible = false;
            }
            else
            {
                groupBox1.Visible = false;
                label1.Visible = true;
                label1.Text = StockSettings.UserInfo.Display;
                menuStrip1.Visible = true;
                if(StockSettings.UserInfo.ApplicationRole == ApplicationRole.Customer)
                {
                    ürünlerToolStripMenuItem.Visible = false;
                    müşterilerToolStripMenuItem.Visible = false;
                }

            }
        }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            RegisterForm frm = new RegisterForm();
            frm.ShowDialog();
            
        }

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
            frm.Show();
        }
    }
}
