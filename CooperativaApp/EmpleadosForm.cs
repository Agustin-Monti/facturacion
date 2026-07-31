using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CooperativaApp
{
    public partial class EmpleadosForm : MetroForm
    {
        string connectionString = "Data Source=cooperativa.db;Version=3;";

        public EmpleadosForm()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1100, 750);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            CargarEmpleados();
            this.Resize += EmpleadosForm_Resize;
        }

        private void EmpleadosForm_Resize(object sender, EventArgs e)
        {
            int formW = this.ClientSize.Width;
            int grillaW = formW - 50;
            int grillaH = (int)(this.ClientSize.Height * 0.6);

            dgvEmpleados.Size = new System.Drawing.Size(grillaW, grillaH);
            dgvEmpleados.Location = new System.Drawing.Point(25, 80);

            int yCampos = dgvEmpleados.Bottom + 25;
            int mitad = formW / 2;

            // Fila 1
            lblNombre.Location = new System.Drawing.Point(30, yCampos);
            txtNombre.Location = new System.Drawing.Point(155, yCampos);
            txtNombre.Size = new System.Drawing.Size(mitad - 250, 30);

            lblApellido.Location = new System.Drawing.Point(mitad + 30, yCampos);
            txtApellido.Location = new System.Drawing.Point(mitad + 100, yCampos);
            txtApellido.Size = new System.Drawing.Size(mitad - 150, 30);

            // Fila 2
            yCampos += 45;
            lblLegajo.Location = new System.Drawing.Point(30, yCampos);
            txtLegajo.Location = new System.Drawing.Point(155, yCampos);
            txtLegajo.Size = new System.Drawing.Size(mitad - 250, 30);

            lblCargo.Location = new System.Drawing.Point(mitad + 30, yCampos);
            txtCargo.Location = new System.Drawing.Point(mitad + 100, yCampos);
            txtCargo.Size = new System.Drawing.Size(mitad - 150, 30);

            // Fila 3
            yCampos += 45;
            lblFechaIngreso.Location = new System.Drawing.Point(30, yCampos);
            txtFechaIngreso.Location = new System.Drawing.Point(155, yCampos);
            txtFechaIngreso.Size = new System.Drawing.Size(mitad - 250, 30);

            // Botones
            yCampos += 60;
            int btnW = (formW - 100) / 4;
            btnAgregar.Location = new System.Drawing.Point(30, yCampos);
            btnAgregar.Size = new System.Drawing.Size(btnW - 10, 40);
            btnModificar.Location = new System.Drawing.Point(30 + btnW, yCampos);
            btnModificar.Size = new System.Drawing.Size(btnW - 10, 40);
            btnEliminar.Location = new System.Drawing.Point(30 + btnW * 2, yCampos);
            btnEliminar.Size = new System.Drawing.Size(btnW - 10, 40);
            btnLimpiar.Location = new System.Drawing.Point(30 + btnW * 3, yCampos);
            btnLimpiar.Size = new System.Drawing.Size(btnW - 10, 40);
        }

        private void CargarEmpleados()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nombre, Apellido, Legajo, Cargo, FechaIngreso FROM Empleados ORDER BY Apellido";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvEmpleados.DataSource = dt;
                if (dgvEmpleados.Columns["Id"] != null) dgvEmpleados.Columns["Id"].Visible = false;
                dgvEmpleados.Columns["Nombre"].HeaderText = "Nombre";
                dgvEmpleados.Columns["Apellido"].HeaderText = "Apellido";
                dgvEmpleados.Columns["Legajo"].HeaderText = "Legajo";
                dgvEmpleados.Columns["Cargo"].HeaderText = "Cargo";
                dgvEmpleados.Columns["FechaIngreso"].HeaderText = "Fecha Ingreso";
                conn.Close();
            }
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvEmpleados.Rows[e.RowIndex];
                txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
                txtApellido.Text = fila.Cells["Apellido"].Value?.ToString();
                txtLegajo.Text = fila.Cells["Legajo"].Value?.ToString();
                txtCargo.Text = fila.Cells["Cargo"].Value?.ToString();
                txtFechaIngreso.Text = fila.Cells["FechaIngreso"].Value?.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { MessageBox.Show("Nombre obligatorio."); return; }
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Empleados (Nombre, Apellido, Legajo, Cargo, FechaIngreso) 
                               VALUES (@n, @a, @l, @c, @f)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                cmd.Parameters.AddWithValue("@a", txtApellido.Text);
                cmd.Parameters.AddWithValue("@l", txtLegajo.Text);
                cmd.Parameters.AddWithValue("@c", txtCargo.Text);
                cmd.Parameters.AddWithValue("@f", txtFechaIngreso.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            CargarEmpleados();
            LimpiarCampos();
            MessageBox.Show("Empleado agregado.");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count == 0) { MessageBox.Show("Seleccioná un empleado."); return; }
            int id = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["Id"].Value);
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Empleados SET Nombre=@n, Apellido=@a, Legajo=@l, Cargo=@c, FechaIngreso=@f WHERE Id=@id";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                cmd.Parameters.AddWithValue("@a", txtApellido.Text);
                cmd.Parameters.AddWithValue("@l", txtLegajo.Text);
                cmd.Parameters.AddWithValue("@c", txtCargo.Text);
                cmd.Parameters.AddWithValue("@f", txtFechaIngreso.Text);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            CargarEmpleados();
            LimpiarCampos();
            MessageBox.Show("Empleado modificado.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count == 0) { MessageBox.Show("Seleccioná un empleado."); return; }
            if (MessageBox.Show("¿Eliminar?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["Id"].Value);
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    new SQLiteCommand("DELETE FROM Empleados WHERE Id=" + id, conn).ExecuteNonQuery();
                    conn.Close();
                }
                CargarEmpleados();
                LimpiarCampos();
                MessageBox.Show("Empleado eliminado.");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) { LimpiarCampos(); }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtLegajo.Clear();
            txtCargo.Clear();
            txtFechaIngreso.Clear();
        }
    }
}