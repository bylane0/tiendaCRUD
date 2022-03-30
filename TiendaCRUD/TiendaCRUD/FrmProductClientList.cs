using MisDTO.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIENDACRUD.BLL;

namespace TiendaCRUD
{
    public partial class FrmProductClientList : Form
    {
        public FrmProductClientList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //PRODUCTO - CLIENTE N a N 
        ProductClientBLL bll = new ProductClientBLL();
        ProductClientDTO dto = new ProductClientDTO();
        ProductClientDetailDTO detail = new ProductClientDetailDTO();

        //CLIENTE 
        ClientDTO dtoclient = new ClientDTO();
        ClientBLL bllclient = new ClientBLL();
        ClientDetailDTO detailclient = new ClientDetailDTO();

        //PRODUCTO
        ProductDTO dtoproduct = new ProductDTO();
        ProductBLL bllproduct = new ProductBLL();
        ProductDetailDTO detailproduct = new ProductDetailDTO();

        private void FrmProductClientList_Load(object sender, EventArgs e)
        {
            FillAllData();

        }

        private void FillAllData()
        {
            //DATA GRID VIEW PRINCIPAL
            dto = bll.Select();
            dataGridView1.DataSource = dto.productsclient;
            dataGridView1.Columns[0].Visible = false; //ID Cliente
            dataGridView1.Columns[1].Visible = false; //ID Producto
            dataGridView1.Columns[2].HeaderText = "Cliente";
            dataGridView1.Columns[3].HeaderText = "Producto";
            dataGridView1.Columns[4].HeaderText = "Cantidad";

            //Cmb cliente -> filtrar por cliente
            dtoclient = bllclient.Select();
            cmbOrderClient.DataSource = dtoclient.Clientes;
            cmbOrderClient.DisplayMember = "NombreCliente";
            cmbOrderClient.ValueMember = "IdCliente";
            cmbOrderClient.SelectedIndex = -1;

            //Cmb producto -> filtrar por producto
            dtoproduct = bllproduct.Select();
            cmbOrderProduct.DataSource = dtoproduct.Productos;
            cmbOrderProduct.DisplayMember = "Descripcion";
            cmbOrderProduct.ValueMember = "IdProducto";
            cmbOrderProduct.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmProductClient frm = new FrmProductClient();
            //frm.dto = dto; Para editar
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            CleanFilters();
            FillAllData();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ProductClientDetailDTO> list = dto.productsclient;
            if (cmbOrderClient.SelectedIndex != -1)
                list = list.Where(x => x.IdCliente == Convert.ToInt32(cmbOrderClient.SelectedValue)).ToList();

            if (cmbOrderProduct.SelectedIndex != -1)
                list = list.Where(x => x.IdProducto == Convert.ToInt32(cmbOrderProduct.SelectedValue)).ToList();

            dataGridView1.DataSource = list;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanFilters();
            dataGridView1.DataSource = dto.productsclient;

        }

        private void CleanFilters()
        {
            cmbOrderClient.SelectedIndex = -1;
            cmbOrderProduct.SelectedIndex = -1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmProductClient frm = new FrmProductClient();
            frm.detailprodcli = detail;
            frm.isUpdate = true;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            CleanFilters();
            FillAllData();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new ProductClientDetailDTO();
            detail.IdCliente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.IdProducto = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detail.NombreCliente = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.NombreProducto = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.Cantidad = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);

        }
    }
}