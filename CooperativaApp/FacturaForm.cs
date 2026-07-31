using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CooperativaApp
{
    public partial class FacturaForm : MetroForm
    {
        string connectionString = "Data Source=cooperativa.db;Version=3;";
        DataTable detalleFactura = new DataTable();

        // Lista temporal de facturas en sesión
        DataTable facturasPendientes = new DataTable();
        List<DataTable> detallesPendientes = new List<DataTable>();

        public FacturaForm()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(950, 750);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            CargarCombos();
            ConfigurarGrillas();
            this.Resize += FacturaForm_Resize;
        }

        private void FacturaForm_Resize(object sender, EventArgs e)
        {
            int formW = this.ClientSize.Width;
            int mitad = formW / 2;

            cmbCliente.Size = new System.Drawing.Size(mitad - 40, 35);
            cmbEmpleado.Location = new System.Drawing.Point(mitad + 10, 55);
            cmbEmpleado.Size = new System.Drawing.Size(mitad - 40, 35);

            cmbProducto.Size = new System.Drawing.Size(formW - 360, 35);
            txtCantidad.Location = new System.Drawing.Point(cmbProducto.Right + 10, 10);
            btnAgregarProducto.Location = new System.Drawing.Point(txtCantidad.Right + 10, 10);
            btnQuitarProducto.Location = new System.Drawing.Point(btnAgregarProducto.Right + 15, 10);

            dgvDetalle.Height = (int)(this.ClientSize.Height * 0.35);

            btnVistaPrevia.Location = new System.Drawing.Point(20, 10);
            btnAgregarALista.Location = new System.Drawing.Point(formW / 2 - 100, 10);
            btnGuardarTodas.Location = new System.Drawing.Point(formW - 220, 10);
        }

        private void CargarCombos()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DataTable dtClientes = new DataTable();
                new SQLiteDataAdapter("SELECT Id, RazonSocial FROM Clientes ORDER BY RazonSocial", conn).Fill(dtClientes);
                cmbCliente.DataSource = dtClientes;
                cmbCliente.DisplayMember = "RazonSocial";
                cmbCliente.ValueMember = "Id";

                DataTable dtEmpleados = new DataTable();
                new SQLiteDataAdapter("SELECT Id, Nombre || ' ' || Apellido as NombreCompleto FROM Empleados ORDER BY Apellido", conn).Fill(dtEmpleados);
                cmbEmpleado.DataSource = dtEmpleados;
                cmbEmpleado.DisplayMember = "NombreCompleto";
                cmbEmpleado.ValueMember = "Id";

                DataTable dtProductos = new DataTable();
                new SQLiteDataAdapter("SELECT Id, Descripcion || ' ($' || PrecioUnitario || ')' as Desc FROM Productos ORDER BY Descripcion", conn).Fill(dtProductos);
                cmbProducto.DataSource = dtProductos;
                cmbProducto.DisplayMember = "Desc";
                cmbProducto.ValueMember = "Id";

                conn.Close();
            }
            cmbTipoFactura.SelectedIndex = 0;
        }

        private void ConfigurarGrillas()
        {
            // Grilla de detalle actual
            detalleFactura.Columns.Add("ProductoId", typeof(int));
            detalleFactura.Columns.Add("Descripcion", typeof(string));
            detalleFactura.Columns.Add("Cantidad", typeof(int));
            detalleFactura.Columns.Add("PrecioUnitario", typeof(decimal));
            detalleFactura.Columns.Add("IVA", typeof(string));
            detalleFactura.Columns.Add("Subtotal", typeof(decimal));
            dgvDetalle.DataSource = detalleFactura;
            dgvDetalle.Columns["ProductoId"].Visible = false;

            // Grilla de facturas pendientes
            facturasPendientes.Columns.Add("Numero");
            facturasPendientes.Columns.Add("Cliente");
            facturasPendientes.Columns.Add("Empleado");
            facturasPendientes.Columns.Add("Total");
            facturasPendientes.Columns.Add("Index"); // oculto
            dgvFacturasPendientes.DataSource = facturasPendientes;
            dgvFacturasPendientes.Columns["Index"].Visible = false;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedValue == null) return;

            int prodId = Convert.ToInt32(cmbProducto.SelectedValue);
            int cantidad = Convert.ToInt32(string.IsNullOrWhiteSpace(txtCantidad.Text) ? "1" : txtCantidad.Text);

            string desc = "";
            decimal precio = 0;
            string iva = "21";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteDataReader reader = new SQLiteCommand("SELECT Descripcion, PrecioUnitario, TipoIVA FROM Productos WHERE Id=" + prodId, conn).ExecuteReader())
                {
                    if (reader.Read())
                    {
                        desc = reader["Descripcion"].ToString();
                        precio = Convert.ToDecimal(reader["PrecioUnitario"]);
                        iva = reader["TipoIVA"].ToString();
                    }
                }
                conn.Close();
            }

            detalleFactura.Rows.Add(prodId, desc, cantidad, precio, iva, precio * cantidad);
            txtCantidad.Text = "1";
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count > 0)
                dgvDetalle.Rows.Remove(dgvDetalle.SelectedRows[0]);
        }

        private void btnAgregarALista_Click(object sender, EventArgs e)
        {
            if (detalleFactura.Rows.Count == 0)
            {
                MessageBox.Show("Agregá al menos un producto.");
                return;
            }

            decimal total = 0;
            foreach (DataRow row in detalleFactura.Rows)
                total += Convert.ToDecimal(row["Subtotal"]);

            // Agregar a pendientes
            facturasPendientes.Rows.Add(
                txtNumeroFactura.Text,
                cmbCliente.Text,
                cmbEmpleado.Text,
                total.ToString("0.00"),
                detallesPendientes.Count
            );

            // Guardar copia del detalle
            detallesPendientes.Add(detalleFactura.Copy());

            // Limpiar para nueva factura
            detalleFactura.Rows.Clear();
            txtNumeroFactura.Text = (Convert.ToInt32(txtNumeroFactura.Text) + 1).ToString("00000000");
            txtCantidad.Text = "1";

            MessageBox.Show("Factura agregada a pendientes.");
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            if (dgvFacturasPendientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná una factura de la lista de pendientes.");
                return;
            }

            int index = Convert.ToInt32(dgvFacturasPendientes.SelectedRows[0].Cells["Index"].Value);
            var row = facturasPendientes.Rows[index];
            var detalle = detallesPendientes[index];

            string tipoFactura = cmbTipoFactura.SelectedItem.ToString();
            string letra = tipoFactura.Contains("A") ? "A" : "C";
            string numero = row["Numero"].ToString();
            string fecha = DateTime.Now.ToString("dd/MM/yyyy");
            string cliente = row["Cliente"].ToString();
            string empleado = row["Empleado"].ToString();

            decimal subtotal = 0;
            foreach (DataRow dr in detalle.Rows)
                subtotal += Convert.ToDecimal(dr["Subtotal"]);
            decimal iva21 = subtotal * 0.21m;
            decimal total = subtotal + iva21;

            // Construir factura con formato simple
            string factura = "";
            factura += "══════════════════════════════════════════\r\n";
            factura += "  COOPERATIVA DE TRABAJO LTDA.\r\n";
            factura += "  CUIT: 30-12345678-9\r\n";
            factura += "  Ing. Brutos: 901-123456-7\r\n";
            factura += "  Inicio Act.: 01/01/2010\r\n";
            factura += "══════════════════════════════════════════\r\n";
            factura += "\r\n";
            factura += "  FACTURA " + letra + "  Nº 0001-" + numero + "\r\n";
            factura += "  Fecha: " + fecha + "\r\n";
            factura += "\r\n";
            factura += "──────────────────────────────────────────\r\n";
            factura += "  CLIENTE: " + cliente + "\r\n";
            factura += "  CUIT: 00-00000000-0\r\n";
            factura += "  Cond. IVA: Consumidor Final\r\n";
            factura += "──────────────────────────────────────────\r\n";
            factura += "\r\n";
            factura += "  Cant  Descripción              Precio   Subtotal\r\n";
            factura += "  ──────────────────────────────────────────\r\n";

            foreach (DataRow dr in detalle.Rows)
            {
                string cant = dr["Cantidad"].ToString().PadLeft(4);
                string desc = dr["Descripcion"].ToString().PadRight(24);
                string prec = "$" + Convert.ToDecimal(dr["PrecioUnitario"]).ToString("0.00").PadLeft(8);
                string subt = "$" + Convert.ToDecimal(dr["Subtotal"]).ToString("0.00").PadLeft(9);
                factura += "  " + cant + "  " + desc + " " + prec + " " + subt + "\r\n";
            }

            factura += "\r\n";
            factura += "  ──────────────────────────────────────────\r\n";
            factura += "  SUBTOTAL:                         $" + subtotal.ToString("0.00").PadLeft(9) + "\r\n";
            factura += "  IVA 21%:                          $" + iva21.ToString("0.00").PadLeft(9) + "\r\n";
            factura += "  ──────────────────────────────────────────\r\n";
            factura += "  TOTAL:                            $" + total.ToString("0.00").PadLeft(9) + "\r\n";
            factura += "══════════════════════════════════════════\r\n";
            factura += "  CAE: 12345678901234\r\n";
            factura += "  Vto. CAE: " + DateTime.Now.AddDays(10).ToString("dd/MM/yyyy") + "\r\n";
            factura += "══════════════════════════════════════════\r\n";
            factura += "\r\n";
            factura += "  Atendido por: " + empleado + "\r\n";
            factura += "  Gracias por su compra!\r\n";

            MostrarFacturaPreview(factura, "Factura " + letra + " Nº 0001-" + numero);
        }

        private void MostrarFacturaPreview(string texto, string titulo)
        {
            Form previewForm = new Form();
            previewForm.Text = titulo;
            previewForm.Size = new System.Drawing.Size(500, 650);
            previewForm.StartPosition = FormStartPosition.CenterParent;
            previewForm.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);

            // Panel blanco que simula el papel
            Panel panelPapel = new Panel();
            panelPapel.BackColor = System.Drawing.Color.White;
            panelPapel.Location = new System.Drawing.Point(30, 20);
            panelPapel.Size = new System.Drawing.Size(430, 540);
            panelPapel.Padding = new System.Windows.Forms.Padding(15);

            Label lblFactura = new Label();
            lblFactura.Text = texto;
            lblFactura.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular);
            lblFactura.ForeColor = System.Drawing.Color.Black;
            lblFactura.BackColor = System.Drawing.Color.White;
            lblFactura.AutoSize = true;
            lblFactura.Location = new System.Drawing.Point(15, 15);

            panelPapel.Controls.Add(lblFactura);

            // Botón cerrar
            Button btnCerrar = new Button();
            btnCerrar.Text = "CERRAR";
            btnCerrar.Size = new System.Drawing.Size(200, 40);
            btnCerrar.Location = new System.Drawing.Point(150, 575);
            btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrar.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnCerrar.ForeColor = System.Drawing.Color.White;
            btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCerrar.Click += (s, ev) => previewForm.Close();

            previewForm.Controls.Add(panelPapel);
            previewForm.Controls.Add(btnCerrar);
            previewForm.ShowDialog();
        }

        private void btnGuardarTodas_Click(object sender, EventArgs e)
        {
            if (facturasPendientes.Rows.Count == 0)
            {
                MessageBox.Show("No hay facturas pendientes.");
                return;
            }

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                for (int i = 0; i < facturasPendientes.Rows.Count; i++)
                {
                    var row = facturasPendientes.Rows[i];
                    var detalle = detallesPendientes[i];

                    string tipo = cmbTipoFactura.SelectedItem.ToString();
                    string pv = "0001"; // Punto de venta fijo

                    // Buscar IDs
                    int clienteId = 1, empleadoId = 1;
                    var cmdCli = new SQLiteCommand("SELECT Id FROM Clientes WHERE RazonSocial=@r LIMIT 1", conn);
                    cmdCli.Parameters.AddWithValue("@r", row["Cliente"].ToString());
                    var resCli = cmdCli.ExecuteScalar();
                    if (resCli != null) clienteId = Convert.ToInt32(resCli);

                    var cmdEmp = new SQLiteCommand("SELECT Id FROM Empleados WHERE Nombre || ' ' || Apellido=@n LIMIT 1", conn);
                    cmdEmp.Parameters.AddWithValue("@n", row["Empleado"].ToString());
                    var resEmp = cmdEmp.ExecuteScalar();
                    if (resEmp != null) empleadoId = Convert.ToInt32(resEmp);

                    decimal total = Convert.ToDecimal(row["Total"]);

                    var cmdFact = new SQLiteCommand(@"INSERT INTO Facturas (Tipo, PuntoVenta, NumeroFactura, Fecha, ClienteId, EmpleadoId, Subtotal, IVA21, IVA105, Total) 
                                                       VALUES (@t, @pv, @nf, @f, @ci, @ei, @s, 0, 0, @tot)", conn);
                    cmdFact.Parameters.AddWithValue("@t", tipo);
                    cmdFact.Parameters.AddWithValue("@pv", pv);
                    cmdFact.Parameters.AddWithValue("@nf", row["Numero"]);
                    cmdFact.Parameters.AddWithValue("@f", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmdFact.Parameters.AddWithValue("@ci", clienteId);
                    cmdFact.Parameters.AddWithValue("@ei", empleadoId);
                    cmdFact.Parameters.AddWithValue("@s", total);
                    cmdFact.Parameters.AddWithValue("@tot", total);
                    cmdFact.ExecuteNonQuery();

                    int facturaId = Convert.ToInt32(new SQLiteCommand("SELECT last_insert_rowid()", conn).ExecuteScalar());

                    foreach (DataRow dr in detalle.Rows)
                    {
                        var cmdDet = new SQLiteCommand(@"INSERT INTO DetalleFactura (FacturaId, ProductoId, Cantidad, PrecioUnitario, Subtotal) 
                                                         VALUES (@fi, @pi, @c, @pu, @s)", conn);
                        cmdDet.Parameters.AddWithValue("@fi", facturaId);
                        cmdDet.Parameters.AddWithValue("@pi", dr["ProductoId"]);
                        cmdDet.Parameters.AddWithValue("@c", dr["Cantidad"]);
                        cmdDet.Parameters.AddWithValue("@pu", dr["PrecioUnitario"]);
                        cmdDet.Parameters.AddWithValue("@s", dr["Subtotal"]);
                        cmdDet.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }

            MessageBox.Show(facturasPendientes.Rows.Count + " facturas guardadas exitosamente.");
            facturasPendientes.Rows.Clear();
            detallesPendientes.Clear();
        }
    }
}