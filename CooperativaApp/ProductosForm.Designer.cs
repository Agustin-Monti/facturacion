namespace CooperativaApp
{
    partial class ProductosForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvProductos = new MetroFramework.Controls.MetroGrid();
            this.txtCodigo = new MetroFramework.Controls.MetroTextBox();
            this.txtDescripcion = new MetroFramework.Controls.MetroTextBox();
            this.txtPrecio = new MetroFramework.Controls.MetroTextBox();
            this.cmbIVA = new MetroFramework.Controls.MetroComboBox();
            this.btnAgregar = new MetroFramework.Controls.MetroButton();
            this.btnModificar = new MetroFramework.Controls.MetroButton();
            this.btnEliminar = new MetroFramework.Controls.MetroButton();
            this.btnLimpiar = new MetroFramework.Controls.MetroButton();
            this.lblTitulo = new MetroFramework.Controls.MetroLabel();
            this.lblCodigo = new MetroFramework.Controls.MetroLabel();
            this.lblDescripcion = new MetroFramework.Controls.MetroLabel();
            this.lblPrecio = new MetroFramework.Controls.MetroLabel();
            this.lblIVA = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            this.dgvProductos.Location = new System.Drawing.Point(23, 70);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(700, 260);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(150, 350);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(170, 25);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(150, 385);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(570, 25);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(150, 420);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(170, 25);
            this.txtPrecio.TabIndex = 3;
            this.txtPrecio.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // cmbIVA
            // 
            this.cmbIVA.FormattingEnabled = true;
            this.cmbIVA.ItemHeight = 23;
            this.cmbIVA.Items.AddRange(new object[] {
            "21",
            "10.5",
            "27",
            "0"});
            this.cmbIVA.Location = new System.Drawing.Point(450, 420);
            this.cmbIVA.Name = "cmbIVA";
            this.cmbIVA.Size = new System.Drawing.Size(100, 29);
            this.cmbIVA.TabIndex = 4;
            this.cmbIVA.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(100, 470);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(130, 35);
            this.btnAgregar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(250, 470);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(130, 35);
            this.btnModificar.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(400, 470);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 35);
            this.btnEliminar.Style = MetroFramework.MetroColorStyle.Red;
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(550, 470);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(130, 35);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo.Location = new System.Drawing.Point(23, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(117, 25);
            this.lblTitulo.TabIndex = 9;
            this.lblTitulo.Text = "PRODUCTOS";
            this.lblTitulo.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(80, 353);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(53, 19);
            this.lblCodigo.TabIndex = 10;
            this.lblCodigo.Text = "Código:";
            this.lblCodigo.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(55, 388);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(84, 19);
            this.lblDescripcion.TabIndex = 11;
            this.lblDescripcion.Text = "Descripción:";
            this.lblDescripcion.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(55, 423);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(85, 19);
            this.lblPrecio.TabIndex = 12;
            this.lblPrecio.Text = "Precio Unit.:";
            this.lblPrecio.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblIVA
            // 
            this.lblIVA.AutoSize = true;
            this.lblIVA.Location = new System.Drawing.Point(400, 425);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(33, 19);
            this.lblIVA.TabIndex = 13;
            this.lblIVA.Text = "IVA:";
            this.lblIVA.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // ProductosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 530);
            this.Controls.Add(this.lblIVA);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cmbIVA);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.dgvProductos);
            this.Name = "ProductosForm";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Gestión de Productos";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MetroFramework.Controls.MetroGrid dgvProductos;
        private MetroFramework.Controls.MetroTextBox txtCodigo;
        private MetroFramework.Controls.MetroTextBox txtDescripcion;
        private MetroFramework.Controls.MetroTextBox txtPrecio;
        private MetroFramework.Controls.MetroComboBox cmbIVA;
        private MetroFramework.Controls.MetroButton btnAgregar;
        private MetroFramework.Controls.MetroButton btnModificar;
        private MetroFramework.Controls.MetroButton btnEliminar;
        private MetroFramework.Controls.MetroButton btnLimpiar;
        private MetroFramework.Controls.MetroLabel lblTitulo;
        private MetroFramework.Controls.MetroLabel lblCodigo;
        private MetroFramework.Controls.MetroLabel lblDescripcion;
        private MetroFramework.Controls.MetroLabel lblPrecio;
        private MetroFramework.Controls.MetroLabel lblIVA;
    }
}