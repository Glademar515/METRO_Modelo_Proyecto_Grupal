using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Modelo_Proyecto_Grupal
{
    public partial class FormPrincipal : Form
    {
        private readonly ValidadorSeguridad _validador = new ValidadorSeguridad();
        private readonly GestorCanasta _gestorCanasta = new GestorCanasta();
        private readonly ControladorPagos _controladorPagos = new ControladorPagos();
        private readonly FuncionesRecursivas _funcionesRecursivas = new FuncionesRecursivas();
        private readonly List<Producto> _historialCompras = new List<Producto>();

        public FormPrincipal()
        {
            InitializeComponent();
            ConfigurarControlesIniciales();
            ConectarEventos();
            RefrescarTodo();
        }

        private void ConfigurarControlesIniciales()
        {
            nudCantidad.Minimum = 1;
            nudCantidad.Maximum = 9999;
            nudCantidad.Value = 1;

            nudNum1.Minimum = -100000;
            nudNum1.Maximum = 100000;
            nudNum1.Value = 5;

            nudNum2.Minimum = -100;
            nudNum2.Maximum = 100;
            nudNum2.Value = 2;

            txtDocumento.MaxLength = 11;
            txtTarjeta.MaxLength = 4;
            txtComprobante.Multiline = true;
            txtComprobante.ReadOnly = true;
            txtComprobante.ScrollBars = ScrollBars.Vertical;

            rbBoleta.Checked = true;

            cmbOrdenar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrdenar.Items.Clear();
            cmbOrdenar.Items.Add("Precio Unitario (Burbuja)");
            cmbOrdenar.Items.Add("Subtotal (Selección)");
            cmbOrdenar.SelectedIndex = 0;

            dgvCatalogo.ReadOnly = true;
            dgvCatalogo.AllowUserToAddRows = false;
            dgvCatalogo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalogo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCanasta.ReadOnly = true;
            dgvCanasta.AllowUserToAddRows = false;
            dgvCanasta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCanasta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvAuditoria.ReadOnly = true;
            dgvAuditoria.AllowUserToAddRows = false;
            dgvAuditoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ConectarEventos()
        {
            // Pestaña 1: Canasta y Productos
            btnAgregar.Click += BtnAgregar_Click;
            btnBuscar.Click += BtnBuscar_Click;
            btnModificar.Click += BtnModificar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnOrdenar.Click += BtnOrdenar_Click;
            dgvCatalogo.CellClick += DgvCatalogo_CellClick;
            dgvCanasta.CellClick += DgvCanasta_CellClick;

            // Pestaña 2: Caja y Auditoría
            btnPagar.Click += BtnPagar_Click;

            // Pestaña 3: Recursividad
            btnFactorial.Click += BtnFactorial_Click;
            btnPotencia.Click += BtnPotencia_Click;
            btnSumatoria.Click += BtnSumatoria_Click;
            btnRecorrerRec.Click += BtnRecorrerRec_Click;
            btnBuscarRec.Click += BtnBuscarRec_Click;
            btnContarRec.Click += BtnContarRec_Click;
        }

        private void RefrescarTodo()
        {
            CargarCatalogo();
            CargarCanasta();
            CargarAuditoria();
        }

        private void CargarCatalogo()
        {
            dgvCatalogo.DataSource = null;
            dgvCatalogo.DataSource = _gestorCanasta.Catalogo.Select(p => new
            {
                p.Codigo,
                p.Nombre,
                Precio = Math.Round(p.PrecioUnitario, 2),
                Restriccion18 = p.RequiereEdad18 ? "Sí (+18)" : "No"
            }).ToList();
        }

        private void CargarCanasta()
        {
            dgvCanasta.DataSource = null;
            dgvCanasta.DataSource = _gestorCanasta.Canasta.Select(p => new
            {
                p.Codigo,
                p.Nombre,
                PrecioUnitario = Math.Round(p.PrecioUnitario, 2),
                p.Cantidad,
                Subtotal = Math.Round(p.Subtotal, 2)
            }).ToList();

            double totalParcial = _gestorCanasta.Canasta.Sum(p => p.Subtotal);
            lblTotalParcial.Text = $"Total Parcial: S/ {totalParcial:F2}";
        }

        private void CargarAuditoria()
        {
            dgvAuditoria.DataSource = null;
            dgvAuditoria.DataSource = _controladorPagos.Transacciones.Select(t => new
            {
                t.NumeroTicket,
                OperacionGravada = Math.Round(t.OperacionGravada, 2),
                Descuento = Math.Round(t.Descuento, 2),
                Igv = Math.Round(t.Igv, 2),
                TotalPagado = Math.Round(t.TotalPagado, 2)
            }).ToList();

            double recaudacion = _controladorPagos.Transacciones.Sum(t => t.TotalPagado);
            lblRecaudacion.Text = $"Recaudación Total: S/ {recaudacion:F2}";
        }

        private void DgvCatalogo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCatalogo.Rows[e.RowIndex].Cells["Codigo"].Value != null)
            {
                txtCodigo.Text = dgvCatalogo.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
            }
        }

        private void DgvCanasta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCanasta.Rows[e.RowIndex].Cells["Codigo"].Value != null)
            {
                txtCodigo.Text = dgvCanasta.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
            }
        }

        private bool AutorizarSupervisorSiRequiere(bool requiereEdad18)
        {
            if (!requiereEdad18)
            {
                return true;
            }

            using (Form dialogPin = new Form())
            {
                dialogPin.Text = "Autorización de Supervisor (+18)";
                dialogPin.Width = 320;
                dialogPin.Height = 150;
                dialogPin.StartPosition = FormStartPosition.CenterParent;
                dialogPin.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialogPin.MaximizeBox = false;
                dialogPin.MinimizeBox = false;

                Label lblPin = new Label() { Left = 15, Top = 15, Width = 270, Text = "Ingrese PIN del supervisor (1234):" };
                TextBox txtPin = new TextBox() { Left = 15, Top = 40, Width = 270, UseSystemPasswordChar = true };
                Button btnOk = new Button() { Text = "Aceptar", Left = 205, Top = 72, Width = 80, DialogResult = DialogResult.OK };

                dialogPin.Controls.Add(lblPin);
                dialogPin.Controls.Add(txtPin);
                dialogPin.Controls.Add(btnOk);
                dialogPin.AcceptButton = btnOk;

                if (dialogPin.ShowDialog(this) == DialogResult.OK && int.TryParse(txtPin.Text.Trim(), out int pinIngresado) && pinIngresado == 1234)
                {
                    return true;
                }
            }

            MessageBox.Show("PIN incorrecto. No se autorizó la operación.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private bool ValidarDocumento(string documento, bool esFactura, out string tipoDoc)
        {
            tipoDoc = "";
            if (string.IsNullOrWhiteSpace(documento) || !documento.All(char.IsDigit))
            {
                MessageBox.Show("Ingrese un DNI (8 dígitos) o RUC (11 dígitos) válido solo con números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (esFactura)
            {
                if (documento.Length != 11 || (!documento.StartsWith("10") && !documento.StartsWith("20")))
                {
                    MessageBox.Show("Para FACTURA ingrese un RUC válido de 11 dígitos (inicia con 10 o 20).", "Validación RUC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                tipoDoc = "RUC";
                return true;
            }

            if (documento.Length == 8)
            {
                tipoDoc = "DNI";
                return true;
            }

            if (documento.Length == 11 && (documento.StartsWith("10") || documento.StartsWith("20")))
            {
                tipoDoc = "RUC";
                return true;
            }

            MessageBox.Show("Documento inválido: use 8 dígitos para DNI o 11 dígitos para RUC.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            int cantidad = (int)nudCantidad.Value;

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Ingrese un código de producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Producto prodCatalogo = _gestorCanasta.BuscarEnCatalogo(codigo);
            if (prodCatalogo == null)
            {
                MessageBox.Show("Código no encontrado en el catálogo de Metro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!AutorizarSupervisorSiRequiere(prodCatalogo.RequiereEdad18))
            {
                return;
            }

            Producto existente = _gestorCanasta.Canasta.FirstOrDefault(p => p.Codigo.Equals(prodCatalogo.Codigo, StringComparison.OrdinalIgnoreCase));
            if (existente != null)
            {
                existente.Cantidad += cantidad;
            }
            else
            {
                _gestorCanasta.Canasta.Add(new Producto(
                    prodCatalogo.Codigo,
                    prodCatalogo.Nombre,
                    prodCatalogo.PrecioUnitario,
                    cantidad,
                    prodCatalogo.RequiereEdad18
                ));
            }

            CargarCanasta();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            Producto encontrado = _gestorCanasta.Canasta.FirstOrDefault(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));

            if (encontrado == null)
            {
                MessageBox.Show("El producto no está en la canasta.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show(
                $"Código: {encontrado.Codigo}\nProducto: {encontrado.Nombre}\nCantidad: {encontrado.Cantidad}\nSubtotal: S/ {encontrado.Subtotal:F2}",
                "Producto Encontrado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            int nuevaCantidad = (int)nudCantidad.Value;

            Producto existente = _gestorCanasta.Canasta.FirstOrDefault(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
            if (existente == null)
            {
                MessageBox.Show("Producto no encontrado en la canasta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (nuevaCantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            existente.Cantidad = nuevaCantidad;
            CargarCanasta();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            Producto existente = _gestorCanasta.Canasta.FirstOrDefault(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));

            if (existente == null)
            {
                MessageBox.Show("Producto no encontrado en la canasta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _gestorCanasta.Canasta.Remove(existente);
            CargarCanasta();
        }

        private void BtnOrdenar_Click(object sender, EventArgs e)
        {
            if (_gestorCanasta.Canasta.Count < 2)
            {
                MessageBox.Show("Necesitas al menos 2 productos en la canasta para ordenar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbOrdenar.SelectedIndex == 0)
            {
                _gestorCanasta.OrdenarBurbujaPorPrecio();
            }
            else
            {
                _gestorCanasta.OrdenarSeleccionPorSubtotal();
            }

            CargarCanasta();
        }

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            if (_gestorCanasta.Canasta.Count == 0)
            {
                MessageBox.Show("La canasta está vacía.", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool esFactura = rbFactura.Checked;
            int tipoComprobante = esFactura ? 2 : 1;
            string documento = txtDocumento.Text.Trim();
            string tarjeta = txtTarjeta.Text.Trim();

            if (!ValidarDocumento(documento, esFactura, out string tipoDoc))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(tarjeta))
            {
                tarjeta = "0000";
            }

            double totalBruto = _gestorCanasta.Canasta.Sum(p => p.Subtotal);
            double descuento = Math.Round(totalBruto > 150.0 ? totalBruto * 0.05 : 0.0, 2);
            double totalPagar = Math.Round(totalBruto - descuento, 2);
            double opGravada = Math.Round(totalPagar / (1.0 + ControladorPagos.TasaIgv), 2);
            double igv = Math.Round(totalPagar - opGravada, 2);
            int puntosBonus = (int)(totalPagar / 10.0);
            int numeroTicket = _controladorPagos.Transacciones.Count + 1;

            var transaccion = new TransaccionCaja(
                numeroTicket,
                opGravada,
                descuento,
                igv,
                totalPagar
            );

            _controladorPagos.RegistrarTransaccion(transaccion);

            foreach (Producto p in _gestorCanasta.Canasta)
            {
                Producto yaComprado = _historialCompras.FirstOrDefault(x =>
                    x.Codigo.Equals(p.Codigo, StringComparison.OrdinalIgnoreCase));

                if (yaComprado != null)
                {
                    yaComprado.Cantidad += p.Cantidad;
                }
                else
                {
                    _historialCompras.Add(new Producto(
                        p.Codigo,
                        p.Nombre,
                        p.PrecioUnitario,
                        p.Cantidad,
                        p.RequiereEdad18
                    ));
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=====================================================");
            sb.AppendLine("        SUPERMERCADOS METRO - CENCOSUD PERÚ          ");
            sb.AppendLine("          COMPROBANTE DE PAGO ELECTRÓNICO            ");
            sb.AppendLine("=====================================================");
            sb.AppendLine($"Tipo Comprobante  : {(tipoComprobante == 2 ? "FACTURA" : "BOLETA")}");
            sb.AppendLine($"{tipoDoc} Cliente      : {documento}");
            sb.AppendLine($"Medio de Pago     : Tarjeta ****{tarjeta}");
            sb.AppendLine("-----------------------------------------------------");
            sb.AppendLine($"Operación Gravada : S/ {opGravada:F2}");
            sb.AppendLine($"Descuento (5%)    : S/ {descuento:F2}");
            sb.AppendLine($"IGV (18%)         : S/ {igv:F2}");
            sb.AppendLine($"IMPORTE TOTAL     : S/ {totalPagar:F2}");
            sb.AppendLine("-----------------------------------------------------");
            sb.AppendLine($"Puntos Bonus      : {puntosBonus} pts.");
            sb.AppendLine($"Estado            : APROBADO - HASH #MTR2026T{numeroTicket}");
            sb.AppendLine("=====================================================");

            txtComprobante.Text = sb.ToString();
            _gestorCanasta.Canasta.Clear();
            txtDocumento.Clear();
            txtTarjeta.Clear();

            RefrescarTodo();
        }

        private List<Producto> ObtenerListaRecursiva()
        {
            if (_gestorCanasta.Canasta.Count > 0)
            {
                return _gestorCanasta.Canasta;
            }

            return _historialCompras;
        }

        private void BtnFactorial_Click(object sender, EventArgs e)
        {
            int n = (int)nudNum1.Value;
            if (n < 0)
            {
                lblResultado91.Text = "Factorial: no definido para negativos.";
                return;
            }

            long res = _funcionesRecursivas.Factorial(n);
            lblResultado91.Text = $"Factorial({n}) = {res}";
        }

        private void BtnPotencia_Click(object sender, EventArgs e)
        {
            double baseNum = (double)nudNum1.Value;
            int expNum = (int)nudNum2.Value;
            double res = Math.Round(_funcionesRecursivas.Potencia(baseNum, expNum), 2);
            lblResultado91.Text = $"Potencia({baseNum}, {expNum}) = {res.ToString(CultureInfo.InvariantCulture)}";
        }

        private void BtnSumatoria_Click(object sender, EventArgs e)
        {
            int n = (int)nudNum1.Value;
            int res = _funcionesRecursivas.Sumatoria(n);
            lblResultado91.Text = $"Sumatoria({n}) = {res}";
        }

        private void BtnRecorrerRec_Click(object sender, EventArgs e)
        {
            lstResultado.Items.Clear();
            List<Producto> lista = ObtenerListaRecursiva();
            if (lista.Count == 0)
            {
                lstResultado.Items.Add("La canasta está vacía.");
                return;
            }

            RecorrerEnListBox(lista, 0);
        }

        private void RecorrerEnListBox(List<Producto> canasta, int indice)
        {
            if (indice >= canasta.Count)
            {
                return;
            }

            Producto item = canasta[indice];
            lstResultado.Items.Add($"[{indice + 1}] {item.Codigo} - {item.Nombre} | Cant: {item.Cantidad} | Sub: S/ {item.Subtotal:F2}");
            RecorrerEnListBox(canasta, indice + 1);
        }

        private void BtnBuscarRec_Click(object sender, EventArgs e)
        {
            lstResultado.Items.Clear();
            string codigo = txtBuscarRec.Text.Trim();
            List<Producto> lista = ObtenerListaRecursiva();
            Producto encontrado = _funcionesRecursivas.BuscarProductoRecursivo(lista, codigo);

            if (encontrado != null)
            {
                lstResultado.Items.Add($"Encontrado: {encontrado.Nombre} | Cant: {encontrado.Cantidad} | Sub: S/ {encontrado.Subtotal:F2}");
            }
            else
            {
                lstResultado.Items.Add("Producto no encontrado en la canasta.");
            }
        }

        private void BtnContarRec_Click(object sender, EventArgs e)
        {
            lstResultado.Items.Clear();
            List<Producto> lista = ObtenerListaRecursiva();
            int totalUnidades = _funcionesRecursivas.ContarUnidadesRecursivo(lista);
            lstResultado.Items.Add($"Total de unidades (recursivo): {totalUnidades}");
        }
    }
}