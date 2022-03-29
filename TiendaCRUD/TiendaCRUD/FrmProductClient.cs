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
    public partial class FrmProductClient : Form
    {
        public FrmProductClient()
        {
            InitializeComponent();
        }
        //CLIENTE 
        ClientDTO dtoclient = new ClientDTO();
        ClientBLL bllclient = new ClientBLL();
        ClientDetailDTO detailclient = new ClientDetailDTO();

        //PRODUCTO 
        
        private void FrmProductClient_Load(object sender, EventArgs e)
        {
            FillAllData();
        }

        private void FillAllData()
        {
            dtoclient = bllclient.Select();
            gridClient.DataSource = dtoclient.Clientes;
            gridClient.Columns[0].Visible = false; //ID Cliente
            gridClient.Columns[1].HeaderText = "Cliente";
            gridClient.Columns[2].HeaderText = "Direccion";
            gridClient.Columns[3].Visible = false; // ID provincia
            gridClient.Columns[4].HeaderText = "Provincia";
            gridClient.Columns[5].Visible = false; // ID tipoDoc
            gridClient.Columns[6].Visible = false; // Nombre de tipo Doc
            gridClient.Columns[7].Visible = false; // Nro dni
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridClient_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detailclient = new ClientDetailDTO();
            detailclient.IdCliente = Convert.ToInt32(gridClient.Rows[e.RowIndex].Cells[0].Value);
            detailclient.NombreCliente = gridClient.Rows[e.RowIndex].Cells[1].Value.ToString();
            detailclient.Direccion = gridClient.Rows[e.RowIndex].Cells[2].Value.ToString();
            detailclient.Provincia = Convert.ToInt32(gridClient.Rows[e.RowIndex].Cells[3].Value);
            detailclient.NombreProvincia = gridClient.Rows[e.RowIndex].Cells[4].Value.ToString();
            detailclient.TipoDoc = Convert.ToInt32(gridClient.Rows[e.RowIndex].Cells[5].Value);
            detailclient.NombreTipoDoc = gridClient.Rows[e.RowIndex].Cells[6].Value.ToString();
            detailclient.NroDoc = gridClient.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtClientName.Text = detailclient.NombreCliente;
        }

        private void txtClientSearch_TextChanged(object sender, EventArgs e)
        {
            List<ClientDetailDTO> list = dtoclient.Clientes;
            list = list.Where(x => x.NombreCliente.Contains(txtClientSearch.Text)).ToList();
            gridClient.DataSource = list;
        }
    }
}
