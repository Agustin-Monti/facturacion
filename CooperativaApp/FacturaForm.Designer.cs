namespace CooperativaApp
{
    partial class FacturaForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbCliente = new MetroFramework.Controls.MetroComboBox();
            this.cmbEmpleado = new MetroFramework.Controls.MetroComboBox();
            this.cmbTipoFactura = new MetroFramework.Controls.MetroComboBox();
            this.txtNumeroFactura = new MetroFramework.Controls.MetroTextBox();
            this.dgvDetalle = new MetroFramework.Controls.MetroGrid();
            this.btnAgregarProducto = new MetroFramework.Controls.MetroButton();
            this.cmbProducto = new MetroFramework.Controls.MetroComboBox();
            this.txtCantidad = new MetroFramework.Controls.MetroTextBox();
            this.btnQuitarProducto = new MetroFramework.Controls.MetroButton();
            this.btnAgregarALista = new MetroFramework.Controls.MetroButton();
            this.btnVistaPrevia = new MetroFramework.Controls.MetroButton();
            this.btnGuardarTodas = new MetroFramework.Controls.MetroButton();
            this.dgvFacturasPendientes = new MetroFramework.Controls.MetroGrid();
            this.lblTitulo = new MetroFramework.Controls.MetroLabel();
            this.lblPendientes = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCliente
            // 
            this.cmbCliente.FontSize = MetroFramework.MetroComboBoxSize.Medium;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(25, 70);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(420, 35);
            this.cmbCliente.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.FontSize = MetroFramework.MetroComboBoxSize.Medium;
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(470, 70);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(400, 35);
            this.cmbEmpleado.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // cmbTipoFactura
            // 
            this.cmbTipoFactura.FormattingEnabled = true;
            this.cmbTipoFactura.Items.AddRange(new object[] { "A", "C" });
            this.cmbTipoFactura.Location = new System.Drawing.Point(25, 120);
            this.cmbTipoFactura.Name = "cmbTipoFactura";
            this.cmbTipoFactura.Size = new System.Drawing.Size(150, 29);
            this.cmbTipoFactura.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtNumeroFactura.Location = new System.Drawing.Point(200, 120);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(150, 30);
            this.txtNumeroFactura.Text = "00000001";
            this.txtNumeroFactura.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.Location = new System.Drawing.Point(25, 210);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.RowTemplate.Height = 30;
            this.dgvDetalle.Size = new System.Drawing.Size(845, 250);
            this.dgvDetalle.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnAgregarProducto.Location = new System.Drawing.Point(610, 170);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(120, 30);
            this.btnAgregarProducto.Style = MetroFramework.MetroColorStyle.Green;
            this.btnAgregarProducto.Text = "+ AGREGAR";
            this.btnAgregarProducto.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // cmbProducto
            // 
            this.cmbProducto.FontSize = MetroFramework.MetroComboBoxSize.Medium;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(25, 170);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(480, 35);
            this.cmbProducto.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtCantidad
            // 
            this.txtCantidad.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtCantidad.Location = new System.Drawing.Point(520, 170);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(70, 30);
            this.txtCantidad.Text = "1";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidad.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btnQuitarProducto
            // 
            this.btnQuitarProducto.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnQuitarProducto.Location = new System.Drawing.Point(745, 170);
            this.btnQuitarProducto.Name = "btnQuitarProducto";
            this.btnQuitarProducto.Size = new System.Drawing.Size(100, 30);
            this.btnQuitarProducto.Style = MetroFramework.MetroColorStyle.Red;
            this.btnQuitarProducto.Text = "- QUITAR";
            this.btnQuitarProducto.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnQuitarProducto.Click += new System.EventHandler(this.btnQuitarProducto_Click);
            // 
            // btnAgregarALista
            // 
            this.btnAgregarALista.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnAgregarALista.FontWeight = MetroFramework.MetroButtonWeight.Bold;
            this.btnAgregarALista.Location = new System.Drawing.Point(340, 475);
            this.btnAgregarALista.Name = "btnAgregarALista";
            this.btnAgregarALista.Size = new System.Drawing.Size(220, 45);
            this.btnAgregarALista.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnAgregarALista.Text = "AGREGAR A LISTA";
            this.btnAgregarALista.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnAgregarALista.Click += new System.EventHandler(this.btnAgregarALista_Click);
            // 
            // btnVistaPrevia
            // 
            this.btnVistaPrevia.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnVistaPrevia.Location = new System.Drawing.Point(25, 475);
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.Size = new System.Drawing.Size(180, 45);
            this.btnVistaPrevia.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnVistaPrevia.Text = "VISTA PREVIA";
            this.btnVistaPrevia.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnVistaPrevia.Click += new System.EventHandler(this.btnVistaPrevia_Click);
            // 
            // btnGuardarTodas
            // 
            this.btnGuardarTodas.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnGuardarTodas.FontWeight = MetroFramework.MetroButtonWeight.Bold;
            this.btnGuardarTodas.Location = new System.Drawing.Point(600, 475);
            this.btnGuardarTodas.Name = "btnGuardarTodas";
            this.btnGuardarTodas.Size = new System.Drawing.Size(250, 45);
            this.btnGuardarTodas.Style = MetroFramework.MetroColorStyle.Green;
            this.btnGuardarTodas.Text = "GUARDAR TODAS";
            this.btnGuardarTodas.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnGuardarTodas.Click += new System.EventHandler(this.btnGuardarTodas_Click);
            // 
            // dgvFacturasPendientes
            // 
            this.dgvFacturasPendientes.AllowUserToAddRows = false;
            this.dgvFacturasPendientes.AllowUserToDeleteRows = false;
            this.dgvFacturasPendientes.Location = new System.Drawing.Point(25, 560);
            this.dgvFacturasPendientes.Name = "dgvFacturasPendientes";
            this.dgvFacturasPendientes.ReadOnly = true;
            this.dgvFacturasPendientes.RowHeadersVisible = false;
            this.dgvFacturasPendientes.RowTemplate.Height = 30;
            this.dgvFacturasPendientes.Size = new System.Drawing.Size(845, 180);
            this.dgvFacturasPendientes.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo.Location = new System.Drawing.Point(25, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "NUEVA FACTURA";
            this.lblTitulo.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblPendientes
            // 
            this.lblPendientes.AutoSize = true;
            this.lblPendientes.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblPendientes.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblPendientes.Location = new System.Drawing.Point(25, 535);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Text = "FACTURAS PENDIENTES";
            this.lblPendientes.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // FacturaForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 760);
            this.Controls.Add(this.lblPendientes);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvFacturasPendientes);
            this.Controls.Add(this.btnGuardarTodas);
            this.Controls.Add(this.btnVistaPrevia);
            this.Controls.Add(this.btnAgregarALista);
            this.Controls.Add(this.btnQuitarProducto);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.txtNumeroFactura);
            this.Controls.Add(this.cmbTipoFactura);
            this.Controls.Add(this.cmbEmpleado);
            this.Controls.Add(this.cmbCliente);
            this.Name = "FacturaForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Nueva Factura";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasPendientes)).EndInit();
            this.ResumeLayout(false);
        }

        private MetroFramework.Controls.MetroComboBox cmbCliente;
        private MetroFramework.Controls.MetroComboBox cmbEmpleado;
        private MetroFramework.Controls.MetroComboBox cmbTipoFactura;
        private MetroFramework.Controls.MetroTextBox txtNumeroFactura;
        private MetroFramework.Controls.MetroGrid dgvDetalle;
        private MetroFramework.Controls.MetroButton btnAgregarProducto;
        private MetroFramework.Controls.MetroComboBox cmbProducto;
        private MetroFramework.Controls.MetroTextBox txtCantidad;
        private MetroFramework.Controls.MetroButton btnQuitarProducto;
        private MetroFramework.Controls.MetroButton btnAgregarALista;
        private MetroFramework.Controls.MetroButton btnVistaPrevia;
        private MetroFramework.Controls.MetroButton btnGuardarTodas;
        private MetroFramework.Controls.MetroGrid dgvFacturasPendientes;
        private MetroFramework.Controls.MetroLabel lblTitulo;
        private MetroFramework.Controls.MetroLabel lblPendientes;
    }
}