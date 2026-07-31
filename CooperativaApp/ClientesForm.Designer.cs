namespace CooperativaApp
{
    partial class ClientesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvClientes = new MetroFramework.Controls.MetroGrid();
            this.txtRazonSocial = new MetroFramework.Controls.MetroTextBox();
            this.txtCUIT = new MetroFramework.Controls.MetroTextBox();
            this.txtDireccion = new MetroFramework.Controls.MetroTextBox();
            this.txtTelefono = new MetroFramework.Controls.MetroTextBox();
            this.txtEmail = new MetroFramework.Controls.MetroTextBox();
            this.cmbTipo = new MetroFramework.Controls.MetroComboBox();
            this.btnAgregar = new MetroFramework.Controls.MetroButton();
            this.btnModificar = new MetroFramework.Controls.MetroButton();
            this.btnEliminar = new MetroFramework.Controls.MetroButton();
            this.btnLimpiar = new MetroFramework.Controls.MetroButton();
            this.lblTitulo = new MetroFramework.Controls.MetroLabel();
            this.lblRazonSocial = new MetroFramework.Controls.MetroLabel();
            this.lblCUIT = new MetroFramework.Controls.MetroLabel();
            this.lblDireccion = new MetroFramework.Controls.MetroLabel();
            this.lblTelefono = new MetroFramework.Controls.MetroLabel();
            this.lblEmail = new MetroFramework.Controls.MetroLabel();
            this.lblTipo = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AllowUserToResizeRows = false;
            this.dgvClientes.Location = new System.Drawing.Point(25, 80);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.RowTemplate.Height = 32;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(1050, 450);
            this.dgvClientes.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellClick);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtRazonSocial.Location = new System.Drawing.Point(150, 550);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(350, 30);
            this.txtRazonSocial.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtCUIT
            // 
            this.txtCUIT.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtCUIT.Location = new System.Drawing.Point(620, 550);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(350, 30);
            this.txtCUIT.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtDireccion
            // 
            this.txtDireccion.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtDireccion.Location = new System.Drawing.Point(150, 595);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(350, 30);
            this.txtDireccion.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtTelefono
            // 
            this.txtTelefono.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtTelefono.Location = new System.Drawing.Point(620, 595);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(350, 30);
            this.txtTelefono.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtEmail
            // 
            this.txtEmail.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtEmail.Location = new System.Drawing.Point(150, 640);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(350, 30);
            this.txtEmail.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // cmbTipo
            // 
            this.cmbTipo.FontSize = MetroFramework.MetroComboBoxSize.Medium;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.ItemHeight = 23;
            this.cmbTipo.Items.AddRange(new object[] { "Inscripto", "Monotributo", "Consumidor Final" });
            this.cmbTipo.Location = new System.Drawing.Point(620, 640);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(280, 29);
            this.cmbTipo.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btnAgregar
            // 
            this.btnAgregar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnAgregar.Location = new System.Drawing.Point(150, 690);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(160, 40);
            this.btnAgregar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnModificar.Location = new System.Drawing.Point(330, 690);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(160, 40);
            this.btnModificar.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnEliminar.Location = new System.Drawing.Point(510, 690);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(160, 40);
            this.btnEliminar.Style = MetroFramework.MetroColorStyle.Red;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnLimpiar.Location = new System.Drawing.Point(690, 690);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(160, 40);
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo.Location = new System.Drawing.Point(25, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(86, 25);
            this.lblTitulo.Text = "CLIENTES";
            this.lblTitulo.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblRazonSocial.Location = new System.Drawing.Point(25, 555);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(119, 20);
            this.lblRazonSocial.Text = "Razón Social:";
            this.lblRazonSocial.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblCUIT
            // 
            this.lblCUIT.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblCUIT.Location = new System.Drawing.Point(530, 555);
            this.lblCUIT.Name = "lblCUIT";
            this.lblCUIT.Size = new System.Drawing.Size(84, 20);
            this.lblCUIT.Text = "CUIT:";
            this.lblCUIT.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblDireccion
            // 
            this.lblDireccion.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblDireccion.Location = new System.Drawing.Point(25, 600);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(119, 20);
            this.lblDireccion.Text = "Dirección:";
            this.lblDireccion.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblTelefono
            // 
            this.lblTelefono.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblTelefono.Location = new System.Drawing.Point(530, 600);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(84, 20);
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblEmail
            // 
            this.lblEmail.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblEmail.Location = new System.Drawing.Point(25, 645);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(119, 20);
            this.lblEmail.Text = "Email:";
            this.lblEmail.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblTipo
            // 
            this.lblTipo.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblTipo.Location = new System.Drawing.Point(530, 645);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(84, 20);
            this.lblTipo.Text = "Tipo de IVA:";
            this.lblTipo.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // ClientesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 750);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblCUIT);
            this.Controls.Add(this.lblRazonSocial);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtCUIT);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.dgvClientes);
            this.Name = "ClientesForm";
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "Gestión de Clientes";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
        }

        private MetroFramework.Controls.MetroGrid dgvClientes;
        private MetroFramework.Controls.MetroTextBox txtRazonSocial;
        private MetroFramework.Controls.MetroTextBox txtCUIT;
        private MetroFramework.Controls.MetroTextBox txtDireccion;
        private MetroFramework.Controls.MetroTextBox txtTelefono;
        private MetroFramework.Controls.MetroTextBox txtEmail;
        private MetroFramework.Controls.MetroComboBox cmbTipo;
        private MetroFramework.Controls.MetroButton btnAgregar;
        private MetroFramework.Controls.MetroButton btnModificar;
        private MetroFramework.Controls.MetroButton btnEliminar;
        private MetroFramework.Controls.MetroButton btnLimpiar;
        private MetroFramework.Controls.MetroLabel lblTitulo;
        private MetroFramework.Controls.MetroLabel lblRazonSocial;
        private MetroFramework.Controls.MetroLabel lblCUIT;
        private MetroFramework.Controls.MetroLabel lblDireccion;
        private MetroFramework.Controls.MetroLabel lblTelefono;
        private MetroFramework.Controls.MetroLabel lblEmail;
        private MetroFramework.Controls.MetroLabel lblTipo;
    }
}