namespace CooperativaApp
{
    partial class EmpleadosForm
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
            this.dgvEmpleados = new MetroFramework.Controls.MetroGrid();
            this.txtNombre = new MetroFramework.Controls.MetroTextBox();
            this.txtApellido = new MetroFramework.Controls.MetroTextBox();
            this.txtLegajo = new MetroFramework.Controls.MetroTextBox();
            this.txtCargo = new MetroFramework.Controls.MetroTextBox();
            this.txtFechaIngreso = new MetroFramework.Controls.MetroTextBox();
            this.btnAgregar = new MetroFramework.Controls.MetroButton();
            this.btnModificar = new MetroFramework.Controls.MetroButton();
            this.btnEliminar = new MetroFramework.Controls.MetroButton();
            this.btnLimpiar = new MetroFramework.Controls.MetroButton();
            this.lblTitulo = new MetroFramework.Controls.MetroLabel();
            this.lblNombre = new MetroFramework.Controls.MetroLabel();
            this.lblApellido = new MetroFramework.Controls.MetroLabel();
            this.lblLegajo = new MetroFramework.Controls.MetroLabel();
            this.lblCargo = new MetroFramework.Controls.MetroLabel();
            this.lblFechaIngreso = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.AllowUserToAddRows = false;
            this.dgvEmpleados.AllowUserToDeleteRows = false;
            this.dgvEmpleados.AllowUserToResizeRows = false;
            this.dgvEmpleados.Location = new System.Drawing.Point(23, 70);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.ReadOnly = true;
            this.dgvEmpleados.RowHeadersVisible = false;
            this.dgvEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpleados.Size = new System.Drawing.Size(700, 260);
            this.dgvEmpleados.TabIndex = 0;
            this.dgvEmpleados.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.dgvEmpleados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpleados_CellClick);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(120, 350);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(220, 25);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(460, 350);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(260, 25);
            this.txtApellido.TabIndex = 2;
            this.txtApellido.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(120, 385);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(220, 25);
            this.txtLegajo.TabIndex = 3;
            this.txtLegajo.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(460, 385);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(260, 25);
            this.txtCargo.TabIndex = 4;
            this.txtCargo.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtFechaIngreso
            // 
            this.txtFechaIngreso.Location = new System.Drawing.Point(120, 420);
            this.txtFechaIngreso.Name = "txtFechaIngreso";
            this.txtFechaIngreso.Size = new System.Drawing.Size(220, 25);
            this.txtFechaIngreso.TabIndex = 5;
            this.txtFechaIngreso.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(100, 470);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(130, 35);
            this.btnAgregar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnAgregar.TabIndex = 6;
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
            this.btnModificar.TabIndex = 7;
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
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(550, 470);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(130, 35);
            this.btnLimpiar.TabIndex = 9;
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
            this.lblTitulo.Size = new System.Drawing.Size(113, 25);
            this.lblTitulo.TabIndex = 10;
            this.lblTitulo.Text = "EMPLEADOS";
            this.lblTitulo.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(45, 353);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(62, 19);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(385, 353);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(63, 19);
            this.lblApellido.TabIndex = 12;
            this.lblApellido.Text = "Apellido:";
            this.lblApellido.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.Location = new System.Drawing.Point(55, 388);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(50, 19);
            this.lblLegajo.TabIndex = 13;
            this.lblLegajo.Text = "Legajo:";
            this.lblLegajo.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(395, 388);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(46, 19);
            this.lblCargo.TabIndex = 14;
            this.lblCargo.Text = "Cargo:";
            this.lblCargo.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Location = new System.Drawing.Point(10, 423);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(97, 19);
            this.lblFechaIngreso.TabIndex = 15;
            this.lblFechaIngreso.Text = "Fecha Ingreso:";
            this.lblFechaIngreso.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // EmpleadosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 530);
            this.Controls.Add(this.lblFechaIngreso);
            this.Controls.Add(this.lblCargo);
            this.Controls.Add(this.lblLegajo);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtFechaIngreso);
            this.Controls.Add(this.txtCargo);
            this.Controls.Add(this.txtLegajo);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.dgvEmpleados);
            this.Name = "EmpleadosForm";
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Text = "Gestión de Empleados";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MetroFramework.Controls.MetroGrid dgvEmpleados;
        private MetroFramework.Controls.MetroTextBox txtNombre;
        private MetroFramework.Controls.MetroTextBox txtApellido;
        private MetroFramework.Controls.MetroTextBox txtLegajo;
        private MetroFramework.Controls.MetroTextBox txtCargo;
        private MetroFramework.Controls.MetroTextBox txtFechaIngreso;
        private MetroFramework.Controls.MetroButton btnAgregar;
        private MetroFramework.Controls.MetroButton btnModificar;
        private MetroFramework.Controls.MetroButton btnEliminar;
        private MetroFramework.Controls.MetroButton btnLimpiar;
        private MetroFramework.Controls.MetroLabel lblTitulo;
        private MetroFramework.Controls.MetroLabel lblNombre;
        private MetroFramework.Controls.MetroLabel lblApellido;
        private MetroFramework.Controls.MetroLabel lblLegajo;
        private MetroFramework.Controls.MetroLabel lblCargo;
        private MetroFramework.Controls.MetroLabel lblFechaIngreso;
    }
}