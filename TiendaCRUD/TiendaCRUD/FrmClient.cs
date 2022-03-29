using BLL.DTO;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string message = ValidateForm();
            if (!string.IsNullOrEmpty(message))
                MessageBox.Show(message);
            else
            {

            }
        }

        private string ValidateForm()
        {
            string message = string.Empty;
            if (string.IsNullOrEmpty(txtClientName.Text))
                message += "El campo 'Nombre de cliente' está vacío" + Environment.NewLine;
            if (string.IsNullOrEmpty(txtAddress.Text))
                message += "El campo 'Dirección' está vacío" + Environment.NewLine;
            if (string.IsNullOrEmpty(txtProvince.Text))
                message += "El campo 'Provincia' está vacío" + Environment.NewLine;
            if (cmbTypeDocument.SelectedIndex == -1)
                message += "Seleccione un tipo de documento" + Environment.NewLine;
            if (string.IsNullOrEmpty(txtDocumentNumber.Text))
                message += "El campo 'Número de documento' está vacío" + Environment.NewLine;
            return message;
          
        }

        private void txtDocumentNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }
        public ClientDTO dto = new ClientDTO();
        private void FrmClient_Load(object sender, EventArgs e)
        {
            cmbTypeDocument.DataSource = dto.TipoDocs;
            cmbTypeDocument.DisplayMember = "NombreTipoDoc";
            cmbTypeDocument.ValueMember = "IdTipoDoc";
            cmbTypeDocument.SelectedIndex = -1;
        }
    }
}
