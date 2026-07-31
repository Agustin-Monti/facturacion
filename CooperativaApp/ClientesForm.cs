using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace CooperativaApp
{
    public partial class ClientesForm : MetroForm
    {
        string connectionString = "Data Source=cooperativa.db;Version=3;";

        public ClientesForm()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1100, 750);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            CargarClientes();
            this.Resize += ClientesForm_Resize;
        }

        private void ClientesForm_Resize(object sender, EventArgs e)
        {
            int formW = this.ClientSize.Width;
            int formH = this.ClientSize.Height;
            int grillaW = formW - 50;
            int grillaH = (int)(formH * 0.6);

            dgvClientes.Size = new System.Drawing.Size(grillaW, grillaH);
            dgvClientes.Location = new System.Drawing.Point(25, 80);

            int yCampos = dgvClientes.Bottom + 25;

            // Fila 1
            lblRazonSocial.Location = new System.Drawing.Point(30, yCampos);
            txtRazonSocial.Location = new System.Drawing.Point(155, yCampos);
            txtRazonSocial.Size = new System.Drawing.Size((formW / 2) - 250, 30);

            lblCUIT.Location = new System.Drawing.Point(formW / 2 + 30, yCampos);
            txtCUIT.Location = new System.Drawing.Point(formW / 2 + 100, yCampos);
            txtCUIT.Size = new System.Drawing.Size((formW / 2) - 150, 30);

            // Fila 2
            yCampos += 45;
            lblDireccion.Location = new System.Drawing.Point(30, yCampos);
            txtDireccion.Location = new System.Drawing.Point(155, yCampos);
            txtDireccion.Size = new System.Drawing.Size((formW / 2) - 250, 30);

            lblTelefono.Location = new System.Drawing.Point(formW / 2 + 30, yCampos);
            txtTelefono.Location = new System.Drawing.Point(formW / 2 + 100, yCampos);
            txtTelefono.Size = new System.Drawing.Size((formW / 2) - 150, 30);

            // Fila 3
            yCampos += 45;
            lblEmail.Location = new System.Drawing.Point(30, yCampos);
            txtEmail.Location = new System.Drawing.Point(155, yCampos);
            txtEmail.Size = new System.Drawing.Size((formW / 2) - 250, 30);

            lblTipo.Location = new System.Drawing.Point(formW / 2 + 30, yCampos);
            cmbTipo.Location = new System.Drawing.Point(formW / 2 + 100, yCampos);
            cmbTipo.Size = new System.Drawing.Size(280, 29);

            // Botones
            yCampos += 50;
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

        private void CargarClientes()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, RazonSocial, CUIT, Direccion, Telefono, Email, TipoResponsable FROM Clientes ORDER BY RazonSocial";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvClientes.DataSource = dt;
                if (dgvClientes.Columns["Id"] != null) dgvClientes.Columns["Id"].Visible = false;
                dgvClientes.Columns["RazonSocial"].HeaderText = "Razón Social";
                dgvClientes.Columns["CUIT"].HeaderText = "CUIT";
                dgvClientes.Columns["Direccion"].HeaderText = "Dirección";
                dgvClientes.Columns["Telefono"].HeaderText = "Teléfono";
                dgvClientes.Columns["Email"].HeaderText = "Email";
                dgvClientes.Columns["TipoResponsable"].HeaderText = "Tipo Resp.";
                conn.Close();
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvClientes.Rows[e.RowIndex];
                txtRazonSocial.Text = fila.Cells["RazonSocial"].Value?.ToString();
                txtCUIT.Text = fila.Cells["CUIT"].Value?.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value?.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value?.ToString();
                txtEmail.Text = fila.Cells["Email"].Value?.ToString();
                cmbTipo.SelectedItem = fila.Cells["TipoResponsable"].Value?.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text)) { MessageBox.Show("Razón Social obligatoria."); return; }
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Clientes (RazonSocial, CUIT, Direccion, Telefono, Email, TipoResponsable) 
                               VALUES (@r, @c, @d, @t, @em, @tr)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@r", txtRazonSocial.Text);
                cmd.Parameters.AddWithValue("@c", txtCUIT.Text);
                cmd.Parameters.AddWithValue("@d", txtDireccion.Text);
                cmd.Parameters.AddWithValue("@t", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@em", txtEmail.Text);
                cmd.Parameters.AddWithValue("@tr", cmbTipo.SelectedItem?.ToString() ?? "Consumidor Final");
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            CargarClientes();
            LimpiarCampos();
            MessageBox.Show("Cliente agregado.");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0) { MessageBox.Show("Seleccioná un cliente."); return; }
            int id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["Id"].Value);
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Clientes SET RazonSocial=@r, CUIT=@c, Direccion=@d, Telefono=@t, Email=@em, TipoResponsable=@tr WHERE Id=@id";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@r", txtRazonSocial.Text);
                cmd.Parameters.AddWithValue("@c", txtCUIT.Text);
                cmd.Parameters.AddWithValue("@d", txtDireccion.Text);
                cmd.Parameters.AddWithValue("@t", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@em", txtEmail.Text);
                cmd.Parameters.AddWithValue("@tr", cmbTipo.SelectedItem?.ToString() ?? "Consumidor Final");
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            CargarClientes();
            LimpiarCampos();
            MessageBox.Show("Cliente modificado.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0) { MessageBox.Show("Seleccioná un cliente."); return; }
            if (MessageBox.Show("¿Eliminar?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["Id"].Value);
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    new SQLiteCommand("DELETE FROM Clientes WHERE Id=" + id, conn).ExecuteNonQuery();
                    conn.Close();
                }
                CargarClientes();
                LimpiarCampos();
                MessageBox.Show("Cliente eliminado.");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) { LimpiarCampos(); }

        private void LimpiarCampos()
        {
            txtRazonSocial.Clear();
            txtCUIT.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            cmbTipo.SelectedIndex = -1;
        }
    }
}