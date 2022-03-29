using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaCRUD
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            FrmClientList frm = new FrmClientList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnProductClient_Click(object sender, EventArgs e)
        {
            FrmProductClient frm = new FrmProductClient();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
