namespace Modelo_Proyecto_Grupal
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCatalogo = new System.Windows.Forms.DataGridView();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabCanasta = new System.Windows.Forms.TabPage();
            this.tabCaja = new System.Windows.Forms.TabPage();
            this.tabRecursividad = new System.Windows.Forms.TabPage();
            this.dgvCanasta = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalParcial = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnOrdenar = new System.Windows.Forms.Button();
            this.cmbOrdenar = new System.Windows.Forms.ComboBox();
            this.rbBoleta = new System.Windows.Forms.RadioButton();
            this.rbFactura = new System.Windows.Forms.RadioButton();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.txtComprobante = new System.Windows.Forms.TextBox();
            this.btnPagar = new System.Windows.Forms.Button();
            this.dgvAuditoria = new System.Windows.Forms.DataGridView();
            this.lblRecaudacion = new System.Windows.Forms.Label();
            this.nudNum1 = new System.Windows.Forms.NumericUpDown();
            this.nudNum2 = new System.Windows.Forms.NumericUpDown();
            this.btnFactorial = new System.Windows.Forms.Button();
            this.btnPotencia = new System.Windows.Forms.Button();
            this.btnSumatoria = new System.Windows.Forms.Button();
            this.lblResultado91 = new System.Windows.Forms.Label();
            this.txtBuscarRec = new System.Windows.Forms.TextBox();
            this.btnRecorrerRec = new System.Windows.Forms.Button();
            this.btnBuscarRec = new System.Windows.Forms.Button();
            this.btnContarRec = new System.Windows.Forms.Button();
            this.lstResultado = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.tabCanasta.SuspendLayout();
            this.tabCaja.SuspendLayout();
            this.tabRecursividad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCatalogo
            // 
            this.dgvCatalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCatalogo.Location = new System.Drawing.Point(31, 228);
            this.dgvCatalogo.Name = "dgvCatalogo";
            this.dgvCatalogo.Size = new System.Drawing.Size(393, 175);
            this.dgvCatalogo.TabIndex = 0;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(166, 183);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabCanasta);
            this.tabPrincipal.Controls.Add(this.tabCaja);
            this.tabPrincipal.Controls.Add(this.tabRecursividad);
            this.tabPrincipal.Location = new System.Drawing.Point(23, 29);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(919, 457);
            this.tabPrincipal.TabIndex = 2;
            // 
            // tabCanasta
            // 
            this.tabCanasta.BackColor = System.Drawing.Color.AliceBlue;
            this.tabCanasta.Controls.Add(this.cmbOrdenar);
            this.tabCanasta.Controls.Add(this.btnOrdenar);
            this.tabCanasta.Controls.Add(this.btnEliminar);
            this.tabCanasta.Controls.Add(this.btnModificar);
            this.tabCanasta.Controls.Add(this.btnBuscar);
            this.tabCanasta.Controls.Add(this.btnAgregar);
            this.tabCanasta.Controls.Add(this.nudCantidad);
            this.tabCanasta.Controls.Add(this.lblTotalParcial);
            this.tabCanasta.Controls.Add(this.dgvCanasta);
            this.tabCanasta.Controls.Add(this.txtCodigo);
            this.tabCanasta.Controls.Add(this.dgvCatalogo);
            this.tabCanasta.Location = new System.Drawing.Point(4, 22);
            this.tabCanasta.Name = "tabCanasta";
            this.tabCanasta.Padding = new System.Windows.Forms.Padding(3);
            this.tabCanasta.Size = new System.Drawing.Size(911, 431);
            this.tabCanasta.TabIndex = 0;
            this.tabCanasta.Text = "Canasta y Productos";
            // 
            // tabCaja
            // 
            this.tabCaja.BackColor = System.Drawing.Color.AliceBlue;
            this.tabCaja.Controls.Add(this.label3);
            this.tabCaja.Controls.Add(this.label2);
            this.tabCaja.Controls.Add(this.lblRecaudacion);
            this.tabCaja.Controls.Add(this.dgvAuditoria);
            this.tabCaja.Controls.Add(this.btnPagar);
            this.tabCaja.Controls.Add(this.txtComprobante);
            this.tabCaja.Controls.Add(this.txtTarjeta);
            this.tabCaja.Controls.Add(this.txtDocumento);
            this.tabCaja.Controls.Add(this.rbFactura);
            this.tabCaja.Controls.Add(this.rbBoleta);
            this.tabCaja.Location = new System.Drawing.Point(4, 22);
            this.tabCaja.Name = "tabCaja";
            this.tabCaja.Padding = new System.Windows.Forms.Padding(3);
            this.tabCaja.Size = new System.Drawing.Size(911, 431);
            this.tabCaja.TabIndex = 1;
            this.tabCaja.Text = "Caja y Auditoría";
            // 
            // tabRecursividad
            // 
            this.tabRecursividad.BackColor = System.Drawing.Color.AliceBlue;
            this.tabRecursividad.Controls.Add(this.label4);
            this.tabRecursividad.Controls.Add(this.lstResultado);
            this.tabRecursividad.Controls.Add(this.btnContarRec);
            this.tabRecursividad.Controls.Add(this.btnBuscarRec);
            this.tabRecursividad.Controls.Add(this.btnRecorrerRec);
            this.tabRecursividad.Controls.Add(this.txtBuscarRec);
            this.tabRecursividad.Controls.Add(this.lblResultado91);
            this.tabRecursividad.Controls.Add(this.btnSumatoria);
            this.tabRecursividad.Controls.Add(this.btnPotencia);
            this.tabRecursividad.Controls.Add(this.btnFactorial);
            this.tabRecursividad.Controls.Add(this.nudNum2);
            this.tabRecursividad.Controls.Add(this.nudNum1);
            this.tabRecursividad.Location = new System.Drawing.Point(4, 22);
            this.tabRecursividad.Name = "tabRecursividad";
            this.tabRecursividad.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecursividad.Size = new System.Drawing.Size(911, 431);
            this.tabRecursividad.TabIndex = 2;
            this.tabRecursividad.Text = "Recursividad";
            // 
            // dgvCanasta
            // 
            this.dgvCanasta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCanasta.Location = new System.Drawing.Point(485, 228);
            this.dgvCanasta.Name = "dgvCanasta";
            this.dgvCanasta.Size = new System.Drawing.Size(393, 175);
            this.dgvCanasta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Recaudación Total: S/ 0.00";
            // 
            // lblTotalParcial
            // 
            this.lblTotalParcial.AutoSize = true;
            this.lblTotalParcial.Location = new System.Drawing.Point(36, 186);
            this.lblTotalParcial.Name = "lblTotalParcial";
            this.lblTotalParcial.Size = new System.Drawing.Size(108, 13);
            this.lblTotalParcial.TabIndex = 2;
            this.lblTotalParcial.Text = "Total Parcial: S/ 0.00";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(292, 184);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 20);
            this.nudCantidad.TabIndex = 3;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.LawnGreen;
            this.btnAgregar.Location = new System.Drawing.Point(31, 68);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(227, 62);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Yellow;
            this.btnBuscar.Location = new System.Drawing.Point(528, 68);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(101, 62);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Orange;
            this.btnModificar.Location = new System.Drawing.Point(635, 68);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(101, 62);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Location = new System.Drawing.Point(742, 68);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(101, 62);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnOrdenar
            // 
            this.btnOrdenar.BackColor = System.Drawing.Color.Bisque;
            this.btnOrdenar.Location = new System.Drawing.Point(529, 170);
            this.btnOrdenar.Name = "btnOrdenar";
            this.btnOrdenar.Size = new System.Drawing.Size(101, 43);
            this.btnOrdenar.TabIndex = 8;
            this.btnOrdenar.Text = "Ordenar";
            this.btnOrdenar.UseVisualStyleBackColor = false;
            // 
            // cmbOrdenar
            // 
            this.cmbOrdenar.FormattingEnabled = true;
            this.cmbOrdenar.Location = new System.Drawing.Point(655, 182);
            this.cmbOrdenar.Name = "cmbOrdenar";
            this.cmbOrdenar.Size = new System.Drawing.Size(188, 21);
            this.cmbOrdenar.TabIndex = 9;
            // 
            // rbBoleta
            // 
            this.rbBoleta.AutoSize = true;
            this.rbBoleta.Location = new System.Drawing.Point(28, 43);
            this.rbBoleta.Name = "rbBoleta";
            this.rbBoleta.Size = new System.Drawing.Size(55, 17);
            this.rbBoleta.TabIndex = 0;
            this.rbBoleta.TabStop = true;
            this.rbBoleta.Text = "Boleta";
            this.rbBoleta.UseVisualStyleBackColor = true;
            // 
            // rbFactura
            // 
            this.rbFactura.AutoSize = true;
            this.rbFactura.Location = new System.Drawing.Point(28, 98);
            this.rbFactura.Name = "rbFactura";
            this.rbFactura.Size = new System.Drawing.Size(61, 17);
            this.rbFactura.TabIndex = 1;
            this.rbFactura.TabStop = true;
            this.rbFactura.Text = "Factura";
            this.rbFactura.UseVisualStyleBackColor = true;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(113, 42);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(179, 20);
            this.txtDocumento.TabIndex = 2;
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Location = new System.Drawing.Point(113, 97);
            this.txtTarjeta.MaxLength = 4;
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(179, 20);
            this.txtTarjeta.TabIndex = 3;
            // 
            // txtComprobante
            // 
            this.txtComprobante.Location = new System.Drawing.Point(542, 21);
            this.txtComprobante.Multiline = true;
            this.txtComprobante.Name = "txtComprobante";
            this.txtComprobante.ReadOnly = true;
            this.txtComprobante.Size = new System.Drawing.Size(340, 393);
            this.txtComprobante.TabIndex = 4;
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.Chartreuse;
            this.btnPagar.Location = new System.Drawing.Point(235, 151);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(228, 40);
            this.btnPagar.TabIndex = 5;
            this.btnPagar.Text = "Procesar Pago";
            this.btnPagar.UseVisualStyleBackColor = false;
            // 
            // dgvAuditoria
            // 
            this.dgvAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditoria.Location = new System.Drawing.Point(20, 210);
            this.dgvAuditoria.Name = "dgvAuditoria";
            this.dgvAuditoria.Size = new System.Drawing.Size(479, 204);
            this.dgvAuditoria.TabIndex = 6;
            // 
            // lblRecaudacion
            // 
            this.lblRecaudacion.AutoSize = true;
            this.lblRecaudacion.Location = new System.Drawing.Point(51, 165);
            this.lblRecaudacion.Name = "lblRecaudacion";
            this.lblRecaudacion.Size = new System.Drawing.Size(140, 13);
            this.lblRecaudacion.TabIndex = 7;
            this.lblRecaudacion.Text = "Recaudación Total: S/ 0.00";
            // 
            // nudNum1
            // 
            this.nudNum1.Location = new System.Drawing.Point(21, 32);
            this.nudNum1.Name = "nudNum1";
            this.nudNum1.Size = new System.Drawing.Size(120, 20);
            this.nudNum1.TabIndex = 0;
            // 
            // nudNum2
            // 
            this.nudNum2.Location = new System.Drawing.Point(21, 87);
            this.nudNum2.Name = "nudNum2";
            this.nudNum2.Size = new System.Drawing.Size(120, 20);
            this.nudNum2.TabIndex = 1;
            // 
            // btnFactorial
            // 
            this.btnFactorial.BackColor = System.Drawing.Color.Bisque;
            this.btnFactorial.Location = new System.Drawing.Point(180, 16);
            this.btnFactorial.Name = "btnFactorial";
            this.btnFactorial.Size = new System.Drawing.Size(103, 48);
            this.btnFactorial.TabIndex = 2;
            this.btnFactorial.Text = "Factorial";
            this.btnFactorial.UseVisualStyleBackColor = false;
            // 
            // btnPotencia
            // 
            this.btnPotencia.BackColor = System.Drawing.Color.Bisque;
            this.btnPotencia.Location = new System.Drawing.Point(418, 16);
            this.btnPotencia.Name = "btnPotencia";
            this.btnPotencia.Size = new System.Drawing.Size(103, 48);
            this.btnPotencia.TabIndex = 3;
            this.btnPotencia.Text = "Potencia";
            this.btnPotencia.UseVisualStyleBackColor = false;
            // 
            // btnSumatoria
            // 
            this.btnSumatoria.BackColor = System.Drawing.Color.Bisque;
            this.btnSumatoria.Location = new System.Drawing.Point(299, 16);
            this.btnSumatoria.Name = "btnSumatoria";
            this.btnSumatoria.Size = new System.Drawing.Size(103, 48);
            this.btnSumatoria.TabIndex = 4;
            this.btnSumatoria.Text = "Sumatoria";
            this.btnSumatoria.UseVisualStyleBackColor = false;
            // 
            // lblResultado91
            // 
            this.lblResultado91.AutoSize = true;
            this.lblResultado91.Location = new System.Drawing.Point(177, 89);
            this.lblResultado91.Name = "lblResultado91";
            this.lblResultado91.Size = new System.Drawing.Size(64, 13);
            this.lblResultado91.TabIndex = 5;
            this.lblResultado91.Text = "Resultado: -";
            // 
            // txtBuscarRec
            // 
            this.txtBuscarRec.Location = new System.Drawing.Point(381, 188);
            this.txtBuscarRec.Name = "txtBuscarRec";
            this.txtBuscarRec.Size = new System.Drawing.Size(193, 20);
            this.txtBuscarRec.TabIndex = 6;
            // 
            // btnRecorrerRec
            // 
            this.btnRecorrerRec.BackColor = System.Drawing.Color.YellowGreen;
            this.btnRecorrerRec.Location = new System.Drawing.Point(63, 272);
            this.btnRecorrerRec.Name = "btnRecorrerRec";
            this.btnRecorrerRec.Size = new System.Drawing.Size(196, 100);
            this.btnRecorrerRec.TabIndex = 7;
            this.btnRecorrerRec.Text = "Recorrer";
            this.btnRecorrerRec.UseVisualStyleBackColor = false;
            // 
            // btnBuscarRec
            // 
            this.btnBuscarRec.BackColor = System.Drawing.Color.Yellow;
            this.btnBuscarRec.Location = new System.Drawing.Point(63, 158);
            this.btnBuscarRec.Name = "btnBuscarRec";
            this.btnBuscarRec.Size = new System.Drawing.Size(196, 78);
            this.btnBuscarRec.TabIndex = 8;
            this.btnBuscarRec.Text = "Buscar";
            this.btnBuscarRec.UseVisualStyleBackColor = false;
            // 
            // btnContarRec
            // 
            this.btnContarRec.BackColor = System.Drawing.Color.Orange;
            this.btnContarRec.Location = new System.Drawing.Point(723, 142);
            this.btnContarRec.Name = "btnContarRec";
            this.btnContarRec.Size = new System.Drawing.Size(125, 66);
            this.btnContarRec.TabIndex = 9;
            this.btnContarRec.Text = "Contar";
            this.btnContarRec.UseVisualStyleBackColor = false;
            // 
            // lstResultado
            // 
            this.lstResultado.FormattingEnabled = true;
            this.lstResultado.Location = new System.Drawing.Point(307, 223);
            this.lstResultado.Name = "lstResultado";
            this.lstResultado.Size = new System.Drawing.Size(541, 173);
            this.lstResultado.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(314, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ingresar: RUC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(314, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ingresar: DNI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(275, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ingresar Codigo:";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(969, 502);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabPrincipal);
            this.Name = "FormPrincipal";
            this.Text = "FormPrincipal";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).EndInit();
            this.tabPrincipal.ResumeLayout(false);
            this.tabCanasta.ResumeLayout(false);
            this.tabCanasta.PerformLayout();
            this.tabCaja.ResumeLayout(false);
            this.tabCaja.PerformLayout();
            this.tabRecursividad.ResumeLayout(false);
            this.tabRecursividad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCatalogo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabCanasta;
        private System.Windows.Forms.TabPage tabCaja;
        private System.Windows.Forms.DataGridView dgvCanasta;
        private System.Windows.Forms.TabPage tabRecursividad;
        private System.Windows.Forms.ComboBox cmbOrdenar;
        private System.Windows.Forms.Button btnOrdenar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblTotalParcial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbFactura;
        private System.Windows.Forms.RadioButton rbBoleta;
        private System.Windows.Forms.Label lblRecaudacion;
        private System.Windows.Forms.DataGridView dgvAuditoria;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.TextBox txtComprobante;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Button btnSumatoria;
        private System.Windows.Forms.Button btnPotencia;
        private System.Windows.Forms.Button btnFactorial;
        private System.Windows.Forms.NumericUpDown nudNum2;
        private System.Windows.Forms.NumericUpDown nudNum1;
        private System.Windows.Forms.ListBox lstResultado;
        private System.Windows.Forms.Button btnContarRec;
        private System.Windows.Forms.Button btnBuscarRec;
        private System.Windows.Forms.Button btnRecorrerRec;
        private System.Windows.Forms.TextBox txtBuscarRec;
        private System.Windows.Forms.Label lblResultado91;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}