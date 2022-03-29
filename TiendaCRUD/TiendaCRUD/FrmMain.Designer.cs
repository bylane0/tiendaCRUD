namespace TiendaCRUD
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnProductClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCustomers
            // 
            this.btnCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomers.Image = global::TiendaCRUD.Properties.Resources.Department;
            this.btnCustomers.Location = new System.Drawing.Point(12, 12);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(179, 178);
            this.btnCustomers.TabIndex = 35;
            this.btnCustomers.Text = "Clientes";
            this.btnCustomers.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::TiendaCRUD.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(12, 196);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(364, 108);
            this.btnExit.TabIndex = 34;
            this.btnExit.Text = "Salida";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnProductClient
            // 
            this.btnProductClient.BackColor = System.Drawing.Color.Transparent;
            this.btnProductClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductClient.Image = global::TiendaCRUD.Properties.Resources.Task;
            this.btnProductClient.Location = new System.Drawing.Point(197, 12);
            this.btnProductClient.Name = "btnProductClient";
            this.btnProductClient.Size = new System.Drawing.Size(179, 178);
            this.btnProductClient.TabIndex = 36;
            this.btnProductClient.Text = "Producto-Cliente";
            this.btnProductClient.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProductClient.UseVisualStyleBackColor = false;
            this.btnProductClient.Click += new System.EventHandler(this.btnProductClient_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 310);
            this.Controls.Add(this.btnProductClient);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.btnExit);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnProductClient;
    }
}

