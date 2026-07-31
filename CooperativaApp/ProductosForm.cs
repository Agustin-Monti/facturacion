using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CooperativaApp
{
    public partial class ProductosForm : MetroForm
    {
        string connectionString = "Data Source=cooperativa.db;Version=3;";

        public ProductosForm()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1100, 750);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            CargarProductos();
            this.Resize += ProductosForm_Resize;
        }

        private void ProductosForm_Resize(object sender, EventArgs e)
        {
            int formW = this.ClientSize.Width;
            int grillaW = formW - 50;
            int grillaH = (int)(this.ClientSize.Height * 0.6);

            dgvProductos.Size = new System.Drawing.Size(grillaW, grillaH);
            dgvProductos.Location = new System.Drawing.Point(25, 80);

            int yCampos = dgvProductos.Bottom + 25;

            // Fila 1 - Código y Precio
            lblCodigo.Location = new System.Drawing.Point(30, yCampos);
            txtCodigo.Location = new System.Drawing.Point(155, yCampos);
            txtCodigo.Size = new System.Drawing.Size(200, 30);

            lblPrecio.Location = new System.Drawing.Point(400, yCampos);
            txtPrecio.Location = new System.Drawing.Point(530, yCampos);
            txtPrecio.Size = new System.Drawing.Size(200, 30);

            lblIVA.Location = new System.Drawing.Point(750, yCampos);
            cmbIVA.Location = new System.Drawing.Point(830, yCampos);
            cmbIVA.Size = new System.Drawing.Size(100, 29);

            // Fila 2 - Descripción
            yCampos += 45;
            lblDescripcion.Location = new System.Drawing.Point(30, yCampos);
            txtDescripcion.Location = new System.Drawing.Point(155, yCampos);
            txtDescripcion.Size = new System.Drawing.Size(formW - 200, 30);

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

        private void CargarProductos()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Codigo, Descripcion, PrecioUnitario, TipoIVA FROM Productos ORDER BY Descripcion";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvProductos.DataSource = dt;
                if (dgvProductos.Columns["Id"] != null) dgvProductos.Columns["Id"].Visible = false;
                dgvProductos.Columns["Codigo"].HeaderText = "Código";
                dgvProductos.Columns["Descripcion"].HeaderText = "Descripción";
                dgvProductos.Columns["PrecioUnitario"].HeaderText = "Precio Unit.";
                dgvProductos.Columns["TipoIVA"].HeaderText = "IVA %";
                conn.Close();
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvProductos.Rows[e.RowIndex];
                txtCodigo.Text = fila.Cells["Codigo"].Value?.ToString();
                txtDescripcion.Text = fila.Cells["Descripcion"].Value?.ToString();
                txtPrecio.Text = fila.Cells["PrecioUnitario"].Value?.ToString();
                cmbIVA.SelectedItem = fila.Cells["TipoIVA"].Value?.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text)) { MessageBox.Show("Descripción obligatoria."); return; }
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Productos (Codigo, Descripcion, PrecioUnitario, TipoIVA) 
                               VALUES (@c, @d, @p, @i)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@c", txtCodigo.Text);
                cmd.Parameters.AddWithValue("@d", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@p", txtPrecio.Text);
                cmd.Parameters.AddWithValue("@i", cmbIVA.SelectedItem?.ToString() ?? "21");
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            CargarProductos();
            LimpiarCampos();
            MessageBox.Show("Producto agregado.");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0) { MessageBox.Show("Seleccioná un producto."); return; }
            int id = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["Id"].Value);
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Productos SET Codigo=@c, Descripcion=@d, PrecioUnitario=@p, TipoIVA=@i WHERE Id=@id";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@c", txtCodigo.Text);
                cmd.Parameters.AddWithValue("@d", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@p", txtPrecio.Text);
                cmd.Parameters.AddWithValue("@i", cmbIVA.SelectedItem?.ToString() ?? "21");
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            CargarProductos();
            LimpiarCampos();
            MessageBox.Show("Producto modificado.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0) { MessageBox.Show("Seleccioná un producto."); return; }
            if (MessageBox.Show("¿Eliminar?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["Id"].Value);
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    new SQLiteCommand("DELETE FROM Productos WHERE Id=" + id, conn).ExecuteNonQuery();
                    conn.Close();
                }
                CargarProductos();
                LimpiarCampos();
                MessageBox.Show("Producto eliminado.");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) { LimpiarCampos(); }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            cmbIVA.SelectedIndex = -1;
        }
    }
}