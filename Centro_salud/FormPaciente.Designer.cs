namespace Centro_salud
{
    partial class FormPaciente
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.GroupBox gbResultados;
        private System.Windows.Forms.DataGridView dgvPaciente;
        private System.Windows.Forms.GroupBox gbDetalles;
        private System.Windows.Forms.Label lblDetalleDiagnostico;
        private System.Windows.Forms.TextBox txtDetalleDiagnostico;
        private System.Windows.Forms.Label lblDetalleReceta;
        private System.Windows.Forms.TextBox txtDetalleReceta;
        private System.Windows.Forms.Button botonRegresar;
        private System.Windows.Forms.Button botonSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelContenedor = new Panel();
            lblTitulo = new Label();
            gbBuscar = new GroupBox();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            botonBuscar = new Button();
            gbResultados = new GroupBox();
            dgvPaciente = new DataGridView();
            gbDetalles = new GroupBox();
            lblDetalleDiagnostico = new Label();
            txtDetalleDiagnostico = new TextBox();
            lblDetalleReceta = new Label();
            txtDetalleReceta = new TextBox();
            botonRegresar = new Button();
            botonSalir = new Button();
            panelContenedor.SuspendLayout();
            gbBuscar.SuspendLayout();
            gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPaciente).BeginInit();
            gbDetalles.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.White;
            panelContenedor.BorderStyle = BorderStyle.FixedSingle;
            panelContenedor.Controls.Add(lblTitulo);
            panelContenedor.Controls.Add(gbBuscar);
            panelContenedor.Controls.Add(gbResultados);
            panelContenedor.Controls.Add(gbDetalles);
            panelContenedor.Controls.Add(botonRegresar);
            panelContenedor.Controls.Add(botonSalir);
            panelContenedor.Location = new Point(25, 20);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(930, 680);
            panelContenedor.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(13, 110, 253);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(928, 60);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "PORTAL DEL PACIENTE - CONSULTA DE CITA Y TRATAMIENTO";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbBuscar
            // 
            gbBuscar.Controls.Add(lblBuscar);
            gbBuscar.Controls.Add(txtBuscar);
            gbBuscar.Controls.Add(botonBuscar);
            gbBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbBuscar.ForeColor = Color.FromArgb(33, 37, 41);
            gbBuscar.Location = new Point(25, 75);
            gbBuscar.Name = "gbBuscar";
            gbBuscar.Size = new Size(875, 75);
            gbBuscar.TabIndex = 1;
            gbBuscar.TabStop = false;
            gbBuscar.Text = "Búsqueda por DNI";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBuscar.Location = new Point(25, 32);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(122, 19);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "DNI del Paciente:";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.Location = new Point(160, 29);
            txtBuscar.MaxLength = 8;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ingrese su DNI";
            txtBuscar.Size = new Size(260, 25);
            txtBuscar.TabIndex = 1;
            txtBuscar.KeyPress += txtBuscar_KeyPress;
            // 
            // botonBuscar
            // 
            botonBuscar.BackColor = Color.FromArgb(13, 110, 253);
            botonBuscar.Cursor = Cursors.Hand;
            botonBuscar.FlatAppearance.BorderSize = 0;
            botonBuscar.FlatStyle = FlatStyle.Flat;
            botonBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            botonBuscar.ForeColor = Color.White;
            botonBuscar.Location = new Point(445, 25);
            botonBuscar.Name = "botonBuscar";
            botonBuscar.Size = new Size(180, 32);
            botonBuscar.TabIndex = 2;
            botonBuscar.Text = "Buscar Información";
            botonBuscar.UseVisualStyleBackColor = false;
            botonBuscar.Click += botonBuscar_Click;
            // 
            // gbResultados
            // 
            gbResultados.Controls.Add(dgvPaciente);
            gbResultados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbResultados.ForeColor = Color.FromArgb(33, 37, 41);
            gbResultados.Location = new Point(25, 160);
            gbResultados.Name = "gbResultados";
            gbResultados.Size = new Size(875, 190);
            gbResultados.TabIndex = 2;
            gbResultados.TabStop = false;
            gbResultados.Text = "Información del Paciente y Cita";
            // 
            // dgvPaciente
            // 
            dgvPaciente.AllowUserToAddRows = false;
            dgvPaciente.AllowUserToDeleteRows = false;
            dgvPaciente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPaciente.BackgroundColor = Color.FromArgb(248, 249, 250);
            dgvPaciente.BorderStyle = BorderStyle.None;
            dgvPaciente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPaciente.Dock = DockStyle.Fill;
            dgvPaciente.Location = new Point(3, 21);
            dgvPaciente.MultiSelect = false;
            dgvPaciente.Name = "dgvPaciente";
            dgvPaciente.ReadOnly = true;
            dgvPaciente.RowHeadersVisible = false;
            dgvPaciente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPaciente.Size = new Size(869, 166);
            dgvPaciente.TabIndex = 0;
            dgvPaciente.SelectionChanged += dgvPaciente_SelectionChanged;
            // 
            // gbDetalles
            // 
            gbDetalles.Controls.Add(lblDetalleDiagnostico);
            gbDetalles.Controls.Add(txtDetalleDiagnostico);
            gbDetalles.Controls.Add(lblDetalleReceta);
            gbDetalles.Controls.Add(txtDetalleReceta);
            gbDetalles.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbDetalles.ForeColor = Color.FromArgb(33, 37, 41);
            gbDetalles.Location = new Point(25, 360);
            gbDetalles.Name = "gbDetalles";
            gbDetalles.Size = new Size(875, 230);
            gbDetalles.TabIndex = 3;
            gbDetalles.TabStop = false;
            gbDetalles.Text = "Detalle Ampliado de Diagnóstico y Receta";
            // 
            // lblDetalleDiagnostico
            // 
            lblDetalleDiagnostico.AutoSize = true;
            lblDetalleDiagnostico.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDetalleDiagnostico.Location = new Point(20, 25);
            lblDetalleDiagnostico.Name = "lblDetalleDiagnostico";
            lblDetalleDiagnostico.Size = new Size(84, 17);
            lblDetalleDiagnostico.TabIndex = 0;
            lblDetalleDiagnostico.Text = "Diagnóstico:";
            // 
            // txtDetalleDiagnostico
            // 
            txtDetalleDiagnostico.BackColor = Color.FromArgb(245, 247, 250);
            txtDetalleDiagnostico.Font = new Font("Segoe UI", 9.5F);
            txtDetalleDiagnostico.Location = new Point(20, 47);
            txtDetalleDiagnostico.Multiline = true;
            txtDetalleDiagnostico.Name = "txtDetalleDiagnostico";
            txtDetalleDiagnostico.ReadOnly = true;
            txtDetalleDiagnostico.ScrollBars = ScrollBars.Vertical;
            txtDetalleDiagnostico.Size = new Size(835, 65);
            txtDetalleDiagnostico.TabIndex = 1;
            // 
            // lblDetalleReceta
            // 
            lblDetalleReceta.AutoSize = true;
            lblDetalleReceta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDetalleReceta.Location = new Point(20, 122);
            lblDetalleReceta.Name = "lblDetalleReceta";
            lblDetalleReceta.Size = new Size(130, 17);
            lblDetalleReceta.TabIndex = 2;
            lblDetalleReceta.Text = "Receta Médica:";
            // 
            // txtDetalleReceta
            // 
            txtDetalleReceta.BackColor = Color.FromArgb(245, 247, 250);
            txtDetalleReceta.Font = new Font("Segoe UI", 9.5F);
            txtDetalleReceta.Location = new Point(20, 144);
            txtDetalleReceta.Multiline = true;
            txtDetalleReceta.Name = "txtDetalleReceta";
            txtDetalleReceta.ReadOnly = true;
            txtDetalleReceta.ScrollBars = ScrollBars.Vertical;
            txtDetalleReceta.Size = new Size(835, 70);
            txtDetalleReceta.TabIndex = 3;
            // 
            // botonRegresar
            // 
            botonRegresar.BackColor = Color.FromArgb(108, 117, 125);
            botonRegresar.Cursor = Cursors.Hand;
            botonRegresar.FlatAppearance.BorderSize = 0;
            botonRegresar.FlatStyle = FlatStyle.Flat;
            botonRegresar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botonRegresar.ForeColor = Color.White;
            botonRegresar.Location = new Point(280, 610);
            botonRegresar.Name = "botonRegresar";
            botonRegresar.Size = new Size(190, 45);
            botonRegresar.TabIndex = 4;
            botonRegresar.Text = "Regresar al Login";
            botonRegresar.UseVisualStyleBackColor = false;
            botonRegresar.Click += botonRegresar_Click;
            // 
            // botonSalir
            // 
            botonSalir.BackColor = Color.FromArgb(220, 53, 69);
            botonSalir.Cursor = Cursors.Hand;
            botonSalir.FlatAppearance.BorderSize = 0;
            botonSalir.FlatStyle = FlatStyle.Flat;
            botonSalir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botonSalir.ForeColor = Color.White;
            botonSalir.Location = new Point(500, 610);
            botonSalir.Name = "botonSalir";
            botonSalir.Size = new Size(170, 45);
            botonSalir.TabIndex = 5;
            botonSalir.Text = "Salir del Sistema";
            botonSalir.UseVisualStyleBackColor = false;
            botonSalir.Click += botonSalir_Click;
            // 
            // FormPaciente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(980, 720);
            Controls.Add(panelContenedor);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormPaciente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Centro de Salud - Consulta de Paciente";
            FormClosing += FormPaciente_FormClosing;
            panelContenedor.ResumeLayout(false);
            gbBuscar.ResumeLayout(false);
            gbBuscar.PerformLayout();
            gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPaciente).EndInit();
            gbDetalles.ResumeLayout(false);
            gbDetalles.PerformLayout();
            ResumeLayout(false);
        }
    }
}
