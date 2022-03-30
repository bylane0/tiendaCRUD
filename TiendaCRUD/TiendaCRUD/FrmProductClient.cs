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
        ProductDTO dtoproduct = new ProductDTO();
        ProductBLL bllproduct = new ProductBLL();
        ProductDetailDTO detailproduct = new ProductDetailDTO();


        //PRODUCTO - CLIENTE N a N 
        public ProductClientBLL bllprodcli = new ProductClientBLL();
        public ProductClientDetailDTO detailprodcli = new ProductClientDetailDTO();
        public ProductClientDTO dtoprocli = new ProductClientDTO();
        public bool isUpdate = false;
        private void FrmProductClient_Load(object sender, EventArgs e)
        {
            if (!isUpdate)
                FillAllData();
            else
            {
                panel1.Hide();
                txtProductName.Text = detailprodcli.NombreProducto;
                txtClientName.Text = detailprodcli.NombreCliente;
                txtAmount.Text = detailprodcli.Cantidad.ToString();

            }
        }

        private void FillAllData()
        {
            //CLIENTES
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

            //PRODUCTO
            dtoproduct = bllproduct.Select();
            gridProduct.DataSource = dtoproduct.Productos;
            gridProduct.Columns[0].Visible = false; //ID producto
            gridProduct.Columns[1].HeaderText = "Producto";


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
        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            List<ProductDetailDTO> list = dtoproduct.Productos;
            list = list.Where(x => x.Descripcion.Contains(txtProductSearch.Text)).ToList();
            gridProduct.DataSource = list;
        }

        private void gridProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detailproduct = new ProductDetailDTO();
            detailproduct.IdProducto = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[0].Value);
            detailproduct.Descripcion = gridProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtProductName.Text = detailproduct.Descripcion;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string message = ValidateForm();
            if (!string.IsNullOrEmpty(message))
                MessageBox.Show(message);
            else
            {
                if (!isUpdate) // Añadir
                {
                    detailprodcli.Cantidad = Convert.ToInt32(txtAmount.Text);
                    detailprodcli.IdCliente = Convert.ToInt32(detailclient.IdCliente);
                    detailprodcli.IdProducto = Convert.ToInt32(detailproduct.IdProducto);
                    if (bllprodcli.Insert(detailprodcli))
                    {
                        MessageBox.Show("La relación producto-cliente se añadió correctamente.");
                        txtAmount.Clear();
                        txtClientName.Clear();
                        txtProductName.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Ya se encuentra la relación cliente-producto.");
                    }
                }
                else // Editar
                {
                    if (detailprodcli.Cantidad == Convert.ToInt32(txtAmount.Text))
                        MessageBox.Show("No existe ningún cambio.");

                    detailprodcli.Cantidad = Convert.ToInt32(txtAmount.Text);
                    if (bllprodcli.Update(detailprodcli))
                    {
                        MessageBox.Show("La relación se actualizó correctamente.");
                        this.Close();
                    }
                }


            }
        }

        private string ValidateForm()
        {
            string message = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtProductName.Text))
                    message += "Seleccione un producto de la lista" + Environment.NewLine;
                if (string.IsNullOrEmpty(txtClientName.Text))
                    message += "Seleccione un cliente de la lista" + Environment.NewLine;
                if (string.IsNullOrEmpty(txtAmount.Text))
                    message += "El campo cantidad está vacío" + Environment.NewLine;
                else if (Convert.ToInt32(txtAmount.Text) < 1)
                    message += "La cantidad solicitada debe ser mayor a 1" + Environment.NewLine;
            }
            catch (System.OverflowException)
            {
                message += "La cantidad debe ser menor" + Environment.NewLine;
            }

            return message;


        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }
    }
}
