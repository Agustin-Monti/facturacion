using iTextSharp.text;
using iTextSharp.text.pdf;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CooperativaApp
{
    public partial class FacturasGuardadasForm : MetroForm
    {
        string connectionString = "Data Source=cooperativa.db;Version=3;";
        int facturaSeleccionadaId = 0;

        public FacturasGuardadasForm()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1300, 900);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Text = "Facturas Guardadas";
            CrearControles();
            CargarFacturas();
            this.Resize += FacturasGuardadasForm_Resize;
        }

        private void CrearControles()
        {
            // Título
            MetroLabel lblTitulo = new MetroLabel();
            lblTitulo.Text = "FACTURAS GUARDADAS";
            lblTitulo.FontSize = MetroLabelSize.Tall;
            lblTitulo.FontWeight = MetroLabelWeight.Bold;
            lblTitulo.Location = new System.Drawing.Point(25, 20);
            lblTitulo.Theme = MetroThemeStyle.Dark;
            this.Controls.Add(lblTitulo);

            // Grilla de facturas (izquierda)
            MetroGrid dgvFacturas = new MetroGrid();
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.Location = new System.Drawing.Point(25, 60);
            dgvFacturas.Size = new System.Drawing.Size(550, 750);
            dgvFacturas.Theme = MetroThemeStyle.Dark;
            dgvFacturas.BackgroundColor = Color.FromArgb(17, 17, 17);
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.ReadOnly = true;
            dgvFacturas.RowHeadersVisible = false;
            dgvFacturas.RowTemplate.Height = 35;
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturas.CellClick += dgvFacturas_CellClick;
            this.Controls.Add(dgvFacturas);

            // WebBrowser para vista previa (derecha)
            WebBrowser webPreview = new WebBrowser();
            webPreview.Name = "webPreview";
            webPreview.Location = new System.Drawing.Point(600, 60);
            webPreview.Size = new System.Drawing.Size(670, 750);
            this.Controls.Add(webPreview);

            // Botón Exportar PDF
            MetroButton btnPDF = new MetroButton();
            btnPDF.Text = "EXPORTAR PDF";
            btnPDF.Location = new System.Drawing.Point(600, 820);
            btnPDF.Size = new System.Drawing.Size(200, 40);
            btnPDF.Style = MetroColorStyle.Red;
            btnPDF.Theme = MetroThemeStyle.Dark;
            btnPDF.FontWeight = MetroButtonWeight.Bold;
            btnPDF.Click += btnPDF_Click;
            this.Controls.Add(btnPDF);

            // Botón Exportar Excel
            MetroButton btnExcel = new MetroButton();
            btnExcel.Text = "EXPORTAR EXCEL";
            btnExcel.Location = new System.Drawing.Point(820, 820);
            btnExcel.Size = new System.Drawing.Size(200, 40);
            btnExcel.Style = MetroColorStyle.Green;
            btnExcel.Theme = MetroThemeStyle.Dark;
            btnExcel.FontWeight = MetroButtonWeight.Bold;
            btnExcel.Click += btnExcel_Click;
            this.Controls.Add(btnExcel);

            // Botón Refrescar
            MetroButton btnRefrescar = new MetroButton();
            btnRefrescar.Text = "REFRESCAR";
            btnRefrescar.Location = new System.Drawing.Point(1040, 820);
            btnRefrescar.Size = new System.Drawing.Size(200, 40);
            btnRefrescar.Style = MetroColorStyle.Blue;
            btnRefrescar.Theme = MetroThemeStyle.Dark;
            btnRefrescar.Click += (s, e) => CargarFacturas();
            this.Controls.Add(btnRefrescar);
        }

        private void FacturasGuardadasForm_Resize(object sender, EventArgs e)
        {
            int formW = this.ClientSize.Width;
            int formH = this.ClientSize.Height;

            var dgv = this.Controls.Find("dgvFacturas", true)[0] as MetroGrid;
            var web = this.Controls.Find("webPreview", true)[0] as WebBrowser;

            dgv.Size = new System.Drawing.Size((int)(formW * 0.42), formH - 160);
            web.Location = new System.Drawing.Point(dgv.Right + 20, 60);
            web.Size = new System.Drawing.Size(formW - dgv.Width - 70, formH - 160);
        }

        private void CargarFacturas()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT f.Id, f.Tipo, f.PuntoVenta || '-' || f.NumeroFactura as Numero, 
                           f.Fecha, c.RazonSocial as Cliente,
                           e.Nombre || ' ' || e.Apellido as Empleado, f.Total
                    FROM Facturas f
                    JOIN Clientes c ON f.ClienteId = c.Id
                    JOIN Empleados e ON f.EmpleadoId = e.Id
                    ORDER BY f.Id DESC LIMIT 100";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                var dgv = this.Controls.Find("dgvFacturas", true)[0] as MetroGrid;
                dgv.DataSource = dt;
                dgv.Columns["Id"].Visible = false;
                dgv.Columns["Tipo"].HeaderText = "Tipo";
                dgv.Columns["Tipo"].Width = 50;
                dgv.Columns["Numero"].HeaderText = "Número";
                dgv.Columns["Numero"].Width = 100;
                dgv.Columns["Fecha"].HeaderText = "Fecha";
                dgv.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yy HH:mm";
                dgv.Columns["Cliente"].HeaderText = "Cliente";
                dgv.Columns["Cliente"].Width = 150;
                dgv.Columns["Empleado"].HeaderText = "Empleado";
                dgv.Columns["Total"].HeaderText = "Total";
                dgv.Columns["Total"].DefaultCellStyle.Format = "$#,##0.00";

                conn.Close();
            }
        }

        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dgv = this.Controls.Find("dgvFacturas", true)[0] as MetroGrid;
                facturaSeleccionadaId = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Id"].Value);
                MostrarVistaPrevia(facturaSeleccionadaId);
            }
        }

        private void MostrarVistaPrevia(int facturaId)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string tipo = "", numero = "", fecha = "", cliente = "", cuit = "", direccion = "", empleado = "";
                decimal subtotal = 0, iva = 0, total = 0;
                string filasProductos = "";

                string sqlFact = @"
                    SELECT f.*, c.RazonSocial, c.CUIT, c.Direccion,
                           e.Nombre || ' ' || e.Apellido as Empleado
                    FROM Facturas f
                    JOIN Clientes c ON f.ClienteId = c.Id
                    JOIN Empleados e ON f.EmpleadoId = e.Id
                    WHERE f.Id = " + facturaId;

                using (SQLiteDataReader r = new SQLiteCommand(sqlFact, conn).ExecuteReader())
                {
                    if (r.Read())
                    {
                        tipo = r["Tipo"].ToString();
                        numero = r["PuntoVenta"] + "-" + r["NumeroFactura"];
                        fecha = Convert.ToDateTime(r["Fecha"]).ToString("dd/MM/yyyy HH:mm");
                        cliente = r["RazonSocial"].ToString();
                        cuit = r["CUIT"]?.ToString() ?? "00-00000000-0";
                        direccion = r["Direccion"]?.ToString() ?? "-";
                        empleado = r["Empleado"].ToString();
                        subtotal = Convert.ToDecimal(r["Subtotal"]);
                        iva = Convert.ToDecimal(r["IVA21"]) + Convert.ToDecimal(r["IVA105"]);
                        total = Convert.ToDecimal(r["Total"]);
                    }
                }

                string sqlDet = @"SELECT p.Descripcion, df.Cantidad, df.PrecioUnitario, df.Subtotal
                                  FROM DetalleFactura df JOIN Productos p ON df.ProductoId = p.Id
                                  WHERE df.FacturaId = " + facturaId;

                using (SQLiteDataReader r = new SQLiteCommand(sqlDet, conn).ExecuteReader())
                {
                    while (r.Read())
                    {
                        filasProductos += "<tr>" +
                            "<td style='text-align:center'>" + r["Cantidad"] + "</td>" +
                            "<td>" + r["Descripcion"] + "</td>" +
                            "<td style='text-align:right'>$ " + Convert.ToDecimal(r["PrecioUnitario"]).ToString("0.00") + "</td>" +
                            "<td style='text-align:right'>$ " + Convert.ToDecimal(r["Subtotal"]).ToString("0.00") + "</td>" +
                            "</tr>";
                    }
                }

                string html = $@"
<!DOCTYPE html>
<html><head><meta charset='utf-8'>
<style>
    body {{ font-family: 'Segoe UI', Arial, sans-serif; background: #f0f0f0; margin: 0; padding: 20px; }}
    .factura {{ max-width: 700px; margin: auto; background: white; padding: 30px; 
                box-shadow: 0 4px 20px rgba(0,0,0,0.2); border-radius: 4px; }}
    .header {{ text-align: center; border-bottom: 3px solid #1a5276; padding-bottom: 15px; margin-bottom: 20px; }}
    .header h1 {{ color: #1a5276; margin: 0; font-size: 24px; }}
    .header p {{ color: #555; margin: 2px 0; font-size: 12px; }}
    .factura-info {{ background: #eaf2f8; padding: 15px; margin-bottom: 20px; border-radius: 4px; }}
    .factura-info h2 {{ color: #1a5276; margin: 0 0 10px 0; font-size: 18px; }}
    .factura-info p {{ margin: 3px 0; font-size: 13px; }}
    .cliente-info {{ border: 1px solid #ddd; padding: 15px; margin-bottom: 20px; border-radius: 4px; }}
    .cliente-info h3 {{ color: #333; margin: 0 0 10px 0; }}
    table {{ width: 100%; border-collapse: collapse; margin-bottom: 20px; }}
    th {{ background: #1a5276; color: white; padding: 10px; font-size: 12px; text-align: left; }}
    td {{ padding: 8px; border-bottom: 1px solid #eee; font-size: 12px; }}
    .totales {{ text-align: right; }}
    .totales p {{ margin: 5px 0; font-size: 14px; }}
    .totales .total {{ font-size: 18px; font-weight: bold; color: #1a5276; border-top: 2px solid #1a5276; padding-top: 10px; }}
    .cae {{ background: #f9f9f9; padding: 10px; border-radius: 4px; font-size: 11px; color: #666; margin-bottom: 15px; }}
    .footer {{ text-align: center; color: #888; font-size: 12px; margin-top: 20px; border-top: 1px solid #ddd; padding-top: 15px; }}
</style></head><body>
<div class='factura'>
    <div class='header'>
        <h1>COOPERATIVA DE TRABAJO LTDA.</h1>
        <p>CUIT: 30-12345678-9 | IIBB: 901-123456-7</p>
        <p>Inicio de Actividades: 01/01/2010</p>
    </div>
    <div class='factura-info'>
        <h2>FACTURA {tipo} - Nº {numero}</h2>
        <p><strong>Fecha:</strong> {fecha}</p>
    </div>
    <div class='cliente-info'>
        <h3>DATOS DEL CLIENTE</h3>
        <p><strong>Razón Social:</strong> {cliente}</p>
        <p><strong>CUIT:</strong> {cuit}</p>
        <p><strong>Dirección:</strong> {direccion}</p>
    </div>
    <table>
        <tr><th>Cant</th><th>Descripción</th><th>Precio Unit.</th><th>Subtotal</th></tr>
        {filasProductos}
    </table>
    <div class='totales'>
        <p>Subtotal: $ {subtotal.ToString("0.00")}</p>
        <p>IVA: $ {iva.ToString("0.00")}</p>
        <p class='total'>TOTAL: $ {total.ToString("0.00")}</p>
    </div>
    <div class='cae'>
        <p><strong>CAE:</strong> 12345678901234 | <strong>Vto. CAE:</strong> {DateTime.Now.AddDays(10).ToString("dd/MM/yyyy")}</p>
    </div>
    <div class='footer'>
        <p>Atendido por: {empleado}</p>
        <p>Gracias por su compra</p>
    </div>
</div>
</body></html>";

                var web = this.Controls.Find("webPreview", true)[0] as WebBrowser;
                web.DocumentText = html;

                conn.Close();
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (facturaSeleccionadaId == 0)
            {
                MessageBox.Show("Seleccioná una factura primero.");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF (*.pdf)|*.pdf";
            saveDialog.FileName = "Factura_" + facturaSeleccionadaId + ".pdf";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                GenerarPDF(saveDialog.FileName);
                MessageBox.Show("PDF generado correctamente.");
            }
        }

        private void GenerarPDF(string ruta)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string tipo = "", numero = "", fecha = "", cliente = "", cuit = "", direccion = "", empleado = "";
                decimal subtotal = 0, iva = 0, total = 0;

                string sqlFact = @"
                    SELECT f.*, c.RazonSocial, c.CUIT, c.Direccion,
                           e.Nombre || ' ' || e.Apellido as Empleado
                    FROM Facturas f
                    JOIN Clientes c ON f.ClienteId = c.Id
                    JOIN Empleados e ON f.EmpleadoId = e.Id
                    WHERE f.Id = " + facturaSeleccionadaId;

                using (SQLiteDataReader r = new SQLiteCommand(sqlFact, conn).ExecuteReader())
                {
                    if (r.Read())
                    {
                        tipo = r["Tipo"].ToString();
                        numero = r["PuntoVenta"] + "-" + r["NumeroFactura"];
                        fecha = Convert.ToDateTime(r["Fecha"]).ToString("dd/MM/yyyy HH:mm");
                        cliente = r["RazonSocial"].ToString();
                        cuit = r["CUIT"]?.ToString() ?? "00-00000000-0";
                        direccion = r["Direccion"]?.ToString() ?? "-";
                        empleado = r["Empleado"].ToString();
                        subtotal = Convert.ToDecimal(r["Subtotal"]);
                        iva = Convert.ToDecimal(r["IVA21"]) + Convert.ToDecimal(r["IVA105"]);
                        total = Convert.ToDecimal(r["Total"]);
                    }
                }

                Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                doc.Open();

                var fontTitulo = FontFactory.GetFont("Helvetica", 16, iTextSharp.text.Font.BOLD, new BaseColor(26, 82, 118));
                var fontNormal = FontFactory.GetFont("Helvetica", 10, iTextSharp.text.Font.NORMAL);
                var fontNegrita = FontFactory.GetFont("Helvetica", 10, iTextSharp.text.Font.BOLD);
                var fontChico = FontFactory.GetFont("Helvetica", 8, iTextSharp.text.Font.NORMAL, BaseColor.GRAY);

                doc.Add(new Paragraph("COOPERATIVA DE TRABAJO LTDA.", fontTitulo) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("CUIT: 30-12345678-9 - IIBB: 901-123456-7", fontChico) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("FACTURA " + tipo + " - Nº " + numero, fontNegrita) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("Fecha: " + fecha, fontNormal) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("CLIENTE: " + cliente, fontNegrita));
                doc.Add(new Paragraph("CUIT: " + cuit, fontNormal));
                doc.Add(new Paragraph("\n"));

                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 1, 4, 2, 2 });
                table.AddCell(new PdfPCell(new Phrase("Cant", fontNegrita)) { BackgroundColor = new BaseColor(26, 82, 118) });
                table.AddCell(new PdfPCell(new Phrase("Descripción", fontNegrita)) { BackgroundColor = new BaseColor(26, 82, 118) });
                table.AddCell(new PdfPCell(new Phrase("Precio", fontNegrita)) { BackgroundColor = new BaseColor(26, 82, 118) });
                table.AddCell(new PdfPCell(new Phrase("Subtotal", fontNegrita)) { BackgroundColor = new BaseColor(26, 82, 118) });

                string sqlDet = @"SELECT p.Descripcion, df.Cantidad, df.PrecioUnitario, df.Subtotal 
                  FROM DetalleFactura df 
                  JOIN Productos p ON df.ProductoId = p.Id 
                  WHERE df.FacturaId = " + facturaSeleccionadaId;
                using (SQLiteDataReader r = new SQLiteCommand(sqlDet, conn).ExecuteReader())
                {
                    while (r.Read())
                    {
                        table.AddCell(new PdfPCell(new Phrase(r["Cantidad"].ToString(), fontNormal)));
                        table.AddCell(new PdfPCell(new Phrase(r["Descripcion"].ToString(), fontNormal)));
                        table.AddCell(new PdfPCell(new Phrase("$" + Convert.ToDecimal(r["PrecioUnitario"]).ToString("0.00"), fontNormal)));
                        table.AddCell(new PdfPCell(new Phrase("$" + Convert.ToDecimal(r["Subtotal"]).ToString("0.00"), fontNormal)));
                    }
                }
                doc.Add(table);
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("Subtotal: $" + subtotal.ToString("0.00"), fontNormal) { Alignment = Element.ALIGN_RIGHT });
                doc.Add(new Paragraph("IVA: $" + iva.ToString("0.00"), fontNormal) { Alignment = Element.ALIGN_RIGHT });
                doc.Add(new Paragraph("TOTAL: $" + total.ToString("0.00"), fontNegrita) { Alignment = Element.ALIGN_RIGHT });
                doc.Add(new Paragraph("\nCAE: 12345678901234", fontChico));
                doc.Add(new Paragraph("Atendido por: " + empleado, fontNormal));

                doc.Close();
                conn.Close();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            var dgv = this.Controls.Find("dgvFacturas", true)[0] as MetroGrid;
            if (dgv == null || dgv.Rows.Count == 0) { MessageBox.Show("No hay datos."); return; }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "CSV (*.csv)|*.csv";
            saveDialog.FileName = "Facturas_" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveDialog.FileName))
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                        if (dgv.Columns[i].Visible) sw.Write(dgv.Columns[i].HeaderText + ";");
                    sw.WriteLine();
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        for (int i = 0; i < dgv.Columns.Count; i++)
                            if (dgv.Columns[i].Visible) sw.Write(row.Cells[i].Value?.ToString() + ";");
                        sw.WriteLine();
                    }
                }
                MessageBox.Show("Exportado a CSV.");
            }
        }
    }
}