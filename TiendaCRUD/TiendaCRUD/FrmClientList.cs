
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MisDTO.DTO;
using TIENDACRUD.BLL;

namespace TiendaCRUD
{
    public partial class FrmClientList : Form
    {
        public FrmClientList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ClientDTO dto = new ClientDTO();
        ClientBLL bll = new ClientBLL();


        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmClient frm = new FrmClient();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
           
            
        }
        private void FrmClientList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
        }
    }
}
