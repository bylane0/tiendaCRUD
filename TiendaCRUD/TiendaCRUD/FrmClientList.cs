
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
        ClientDetailDTO detail = new ClientDetailDTO();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmClient frm = new FrmClient();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            FillAllData();
            
        }
        private void FrmClientList_Load(object sender, EventArgs e)
        {
            FillAllData();
        }

        private void FillAllData()
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Clientes;
            dataGridView1.Columns[0].Visible = false; //ID Cliente
            dataGridView1.Columns[1].HeaderText = "Cliente";
            dataGridView1.Columns[2].HeaderText = "Direccion";
            dataGridView1.Columns[3].Visible = false; // ID provincia
            dataGridView1.Columns[4].HeaderText = "Provincia";
            dataGridView1.Columns[5].Visible = false; // ID tipoDoc
            dataGridView1.Columns[6].HeaderText = "Tipo Doc";
            dataGridView1.Columns[7].HeaderText = "Nro. Doc";
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            List<ClientDetailDTO> list = dto.Clientes;
            list = list.Where(x => x.NombreCliente.Contains(txtClientSearch.Text)).ToList();
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new ClientDetailDTO();
            detail.IdCliente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.NombreCliente = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            detail.Direccion = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.Provincia = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            detail.NombreProvincia = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            detail.TipoDoc = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            detail.NombreTipoDoc = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            detail.NroDoc = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.IdCliente == 0)
                MessageBox.Show("Seleccione un cliente de la tabla!");
            else
            {
                FrmClient frm = new FrmClient();
                frm.detail = detail;
                frm.dto = dto;
                frm.isUpdate = true;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                bll = new ClientBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Clientes;
                FillAllData();

            }
        }
    }
}
