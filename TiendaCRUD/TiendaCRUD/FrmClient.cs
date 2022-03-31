
using MisDTO.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIENDACRUD.BLL;

namespace TiendaCRUD
{
    public partial class FrmClient : Form
    {
        public FrmClient()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ClientBLL bll = new ClientBLL();

        //Globales
        public ClientDetailDTO detail = new ClientDetailDTO();
        public ClientDTO dto = new ClientDTO();
        public bool isUpdate = false;
        private void btnSave_Click(object sender, EventArgs e)
        {
            string message = ValidateForm();
            if (!string.IsNullOrEmpty(message))
                MessageBox.Show(message);
            else
            {
                if (!isUpdate) // Agregar cliente
                {
                    detail.NombreCliente = txtClientName.Text;
                    detail.Direccion = txtAddress.Text;
                    detail.Provincia = Convert.ToInt32(cmbProvince.SelectedValue);
                    detail.TipoDoc = Convert.ToInt32(cmbTypeDocument.SelectedValue);
                    detail.NroDoc = txtDocumentNumber.Text;
                    if (bll.Insert(detail))
                    {
                        MessageBox.Show("El cliente se añadió correctamente.");
                        CleanFilters();
                        FillAllData();
                    }
                }
                else // Editar cliente
                {
                    if (detail.NombreCliente == txtClientName.Text &&
                     detail.Provincia == Convert.ToInt32(cmbProvince.SelectedValue) &&
                     detail.TipoDoc == Convert.ToInt32(cmbTypeDocument.SelectedValue) &&
                     detail.Direccion == txtAddress.Text
                     && detail.NroDoc == txtDocumentNumber.Text)
                    {
                        MessageBox.Show("No existe ningún cambio!");
                    }
                    else
                    {
                        detail.NombreCliente = txtClientName.Text;
                        detail.Direccion = txtAddress.Text;
                        detail.Provincia = Convert.ToInt32(cmbProvince.SelectedValue);
                        detail.TipoDoc = Convert.ToInt32(cmbTypeDocument.SelectedValue);
                        detail.NroDoc = txtDocumentNumber.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("El cliente se actualizó correctamente.");
                            CleanFilters();
                            this.Close();
                        }
                    }
                }
            }
        }
        private void FillAllData()
        {
            bll.Select();
            //CMB Tipo de doc
            cmbTypeDocument.DataSource = dto.TipoDocs;
            cmbTypeDocument.DisplayMember = "NombreTipoDoc";
            cmbTypeDocument.ValueMember = "IdTipoDoc";
            cmbTypeDocument.SelectedIndex = -1;
            //CMB Provincias
            cmbProvince.DataSource = dto.Provincias;
            cmbProvince.DisplayMember = "Descripcion";
            cmbProvince.ValueMember = "IdProvincia";
            cmbProvince.SelectedIndex = -1;
            if (isUpdate)
            {
                cmbTypeDocument.SelectedValue = detail.TipoDoc;
                cmbProvince.SelectedValue = detail.Provincia;
                txtClientName.Text = detail.NombreCliente;
                txtAddress.Text = detail.Direccion;
                txtDocumentNumber.Text = detail.NroDoc;
            }
        }
        private void CleanFilters()
        {
            txtClientName.Clear();
            txtAddress.Clear();
            cmbProvince.SelectedIndex = -1;
            cmbTypeDocument.SelectedIndex = -1;
            txtDocumentNumber.Clear();
        }

        private string ValidateForm()
        {
            string message = string.Empty;
            if (string.IsNullOrEmpty(txtClientName.Text))
                message += "El campo 'Nombre de cliente' está vacío" + Environment.NewLine;
            if (string.IsNullOrEmpty(txtAddress.Text))
                message += "El campo 'Dirección' está vacío" + Environment.NewLine;
            if (cmbProvince.SelectedIndex == -1)
                message += "Seleccione un tipo de provincia" + Environment.NewLine;
            if (cmbTypeDocument.SelectedIndex == -1)
                message += "Seleccione un tipo de documento" + Environment.NewLine;
            if (string.IsNullOrEmpty(txtDocumentNumber.Text))
                message += "El campo 'Número de documento' está vacío" + Environment.NewLine;
            else if (!ValidateDocument(txtDocumentNumber.Text))
                message += "El número de documento ingresado es incorrecto" + Environment.NewLine;
            return message;

        }

        private bool ValidateDocument(string nroDoc)
        {
            var regexDoc = @"^[\d]{1,3}\.?[\d]{3,3}\.?[\d]{3,3}$"; //Minimo un millon (7 digitos), maximo 999 millones (9 digitos), pero debe permitir puntos de mil opcionalmente
            var temp = Regex.IsMatch(nroDoc, regexDoc);
            return temp; // Si coincide return true, sino false.
        }


        private void txtDocumentNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }


        private void FrmClient_Load(object sender, EventArgs e)
        {
            FillAllData();
        }
    }
}
