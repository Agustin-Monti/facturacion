using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace CooperativaApp
{
    public partial class Form1 : MetroForm
    {
        string connectionString = "Data Source=cooperativa.db;Version=3;";

        public Form1()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            CrearBaseDeDatos();
            InsertarDatosDePrueba();
            CrearMenuPrincipal();
        }

        private void CrearMenuPrincipal()
        {
            // Título
            MetroLabel lblTitulo = new MetroLabel();
            lblTitulo.Text = "COOPERATIVA - SISTEMA DE GESTIÓN";
            lblTitulo.FontSize = MetroLabelSize.Tall;
            lblTitulo.FontWeight = MetroLabelWeight.Bold;
            lblTitulo.AutoSize = true;
            lblTitulo.Theme = MetroThemeStyle.Dark;
            this.Controls.Add(lblTitulo);

            // Subtítulo
            MetroLabel lblSubtitulo = new MetroLabel();
            lblSubtitulo.Text = "Seleccione una opción para comenzar";
            lblSubtitulo.FontSize = MetroLabelSize.Medium;
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Theme = MetroThemeStyle.Dark;
            this.Controls.Add(lblSubtitulo);

            // Tiles
            int tileW = 340;
            int tileH = 140;
            int espacio = 30;

            MetroTile tileClientes = CrearTile("CLIENTES", tileW, tileH, MetroColorStyle.Blue);
            tileClientes.Click += (s, e) => new ClientesForm().ShowDialog();
            this.Controls.Add(tileClientes);

            MetroTile tileEmpleados = CrearTile("EMPLEADOS", tileW, tileH, MetroColorStyle.Teal);
            tileEmpleados.Click += (s, e) => new EmpleadosForm().ShowDialog();
            this.Controls.Add(tileEmpleados);

            MetroTile tileProductos = CrearTile("PRODUCTOS", tileW, tileH, MetroColorStyle.Purple);
            tileProductos.Click += (s, e) => new ProductosForm().ShowDialog();
            this.Controls.Add(tileProductos);

            MetroTile tileFacturar = CrearTile("NUEVA FACTURA", tileW, tileH, MetroColorStyle.Green);
            tileFacturar.Click += (s, e) => new FacturaForm().ShowDialog();
            this.Controls.Add(tileFacturar);

            MetroTile tileVerFacturas = CrearTile("VER FACTURAS", tileW, tileH, MetroColorStyle.Orange);
            tileVerFacturas.Click += (s, e) => new FacturasGuardadasForm().ShowDialog();
            this.Controls.Add(tileVerFacturas);

            MetroTile tileReportes = CrearTile("REPORTES", tileW, tileH, MetroColorStyle.Red);
            tileReportes.Click += (s, e) => MessageBox.Show("Reportes - Próximamente");
            this.Controls.Add(tileReportes);

            // Centrar todo cuando el formulario se redimensiona
            this.Resize += (s, e) => CentrarControles(lblTitulo, lblSubtitulo, tileClientes, tileEmpleados,
                                                       tileProductos, tileFacturar, tileVerFacturas, tileReportes,
                                                       tileW, tileH, espacio);

            // Forzar centrado inicial
            this.Shown += (s, e) => CentrarControles(lblTitulo, lblSubtitulo, tileClientes, tileEmpleados,
                                                      tileProductos, tileFacturar, tileVerFacturas, tileReportes,
                                                      tileW, tileH, espacio);
        }

        private MetroTile CrearTile(string texto, int w, int h, MetroColorStyle color)
        {
            MetroTile tile = new MetroTile();
            tile.Text = texto;
            tile.Size = new System.Drawing.Size(w, h);
            tile.Style = color;
            tile.Theme = MetroThemeStyle.Dark;
            tile.TileTextFontSize = MetroTileTextSize.Tall;
            tile.TileTextFontWeight = MetroTileTextWeight.Bold;
            return tile;
        }

        private void CentrarControles(MetroLabel titulo, MetroLabel subtitulo,
                                       MetroTile t1, MetroTile t2, MetroTile t3,
                                       MetroTile t4, MetroTile t5, MetroTile t6,
                                       int tileW, int tileH, int espacio)
        {
            int formW = this.ClientSize.Width;
            int formH = this.ClientSize.Height;

            // Título centrado arriba
            titulo.Location = new System.Drawing.Point((formW - titulo.Width) / 2, formH / 20);
            subtitulo.Location = new System.Drawing.Point((formW - subtitulo.Width) / 2, titulo.Bottom + 15);

            // Grid de 3 columnas x 2 filas
            int totalW = tileW * 3 + espacio * 2;
            int totalH = tileH * 2 + espacio;
            int startX = (formW - totalW) / 2;
            int startY = subtitulo.Bottom + 40;

            if (startY + totalH > formH) startY = subtitulo.Bottom + 20;

            // Fila 1
            t1.Location = new System.Drawing.Point(startX, startY);
            t2.Location = new System.Drawing.Point(startX + tileW + espacio, startY);
            t3.Location = new System.Drawing.Point(startX + (tileW + espacio) * 2, startY);

            // Fila 2
            t4.Location = new System.Drawing.Point(startX, startY + tileH + espacio);
            t5.Location = new System.Drawing.Point(startX + tileW + espacio, startY + tileH + espacio);
            t6.Location = new System.Drawing.Point(startX + (tileW + espacio) * 2, startY + tileH + espacio);
        }

        private void CrearBaseDeDatos()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    CREATE TABLE IF NOT EXISTS Empleados (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nombre TEXT, Apellido TEXT, Legajo TEXT,
                        Cargo TEXT, FechaIngreso TEXT
                    );
                    CREATE TABLE IF NOT EXISTS Clientes (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        RazonSocial TEXT, CUIT TEXT, Direccion TEXT,
                        Telefono TEXT, Email TEXT, TipoResponsable TEXT
                    );
                    CREATE TABLE IF NOT EXISTS Productos (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Codigo TEXT, Descripcion TEXT,
                        PrecioUnitario REAL, TipoIVA TEXT
                    );
                    CREATE TABLE IF NOT EXISTS Facturas (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Tipo TEXT, PuntoVenta TEXT, NumeroFactura TEXT,
                        Fecha TEXT, ClienteId INTEGER, EmpleadoId INTEGER,
                        Subtotal REAL, IVA21 REAL, IVA105 REAL, Total REAL,
                        CAE TEXT, VencimientoCAE TEXT
                    );
                    CREATE TABLE IF NOT EXISTS DetalleFactura (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FacturaId INTEGER, ProductoId INTEGER,
                        Cantidad INTEGER, PrecioUnitario REAL, Subtotal REAL
                    );
                ";
                new SQLiteCommand(sql, conn).ExecuteNonQuery();
                conn.Close();
            }
        }

        private void InsertarDatosDePrueba()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                if (Convert.ToInt32(new SQLiteCommand("SELECT COUNT(*) FROM Empleados", conn).ExecuteScalar()) == 0)
                {
                    string sql = @"INSERT INTO Empleados (Nombre, Apellido, Legajo, Cargo, FechaIngreso) VALUES
                        ('Carlos', 'González', 'EMP001', 'Administrativo', '2020-01-15'),
                        ('María', 'Rodríguez', 'EMP002', 'Cajera', '2021-03-10'),
                        ('Juan', 'Pérez', 'EMP003', 'Vendedor', '2022-06-01'),
                        ('Ana', 'Martínez', 'EMP004', 'Contadora', '2019-11-20'),
                        ('Pedro', 'López', 'EMP005', 'Supervisor', '2018-05-05');";
                    new SQLiteCommand(sql, conn).ExecuteNonQuery();
                }

                if (Convert.ToInt32(new SQLiteCommand("SELECT COUNT(*) FROM Clientes", conn).ExecuteScalar()) == 0)
                {
                    string sql = @"INSERT INTO Clientes (RazonSocial, CUIT, Direccion, Telefono, Email, TipoResponsable) VALUES
                        ('Cooperativa Agropecuaria Norte', '30-71234567-8', 'Av. del Campo 1234', '351-4567890', 'coopnorte@email.com', 'Inscripto'),
                        ('Distribuidora El Sol SRL', '33-70876543-2', 'Calle Comercio 567', '011-43215678', 'ventas@elsol.com', 'Inscripto'),
                        ('Juan Carlos Romero', '20-25123456-7', 'Pasaje Los Olivos 45', '351-3778899', 'jcromero@email.com', 'Monotributo'),
                        ('Construcciones Modernas SA', '30-70987654-3', 'Ruta 9 Km 45', '351-4998877', 'obra@constmodernas.com', 'Inscripto'),
                        ('María Laura Fernández', '27-30234567-8', 'Bv. San Martín 2345', '011-45678901', 'mlfernandez@email.com', 'Consumidor Final');";
                    new SQLiteCommand(sql, conn).ExecuteNonQuery();
                }

                if (Convert.ToInt32(new SQLiteCommand("SELECT COUNT(*) FROM Productos", conn).ExecuteScalar()) == 0)
                {
                    string sql = @"INSERT INTO Productos (Codigo, Descripcion, PrecioUnitario, TipoIVA) VALUES
                        ('SERV001', 'Consultoría Técnica', 15000, '21'),
                        ('SERV002', 'Mantenimiento de Equipos', 8500, '21'),
                        ('SERV003', 'Transporte de Carga', 25000, '10.5'),
                        ('PROD001', 'Herramientas Manuales', 3500, '21'),
                        ('PROD002', 'Insumos de Limpieza', 1200, '21'),
                        ('PROD003', 'Alimentos No Perecederos', 800, '10.5');";
                    new SQLiteCommand(sql, conn).ExecuteNonQuery();
                }

                conn.Close();
            }
        }
    }
}