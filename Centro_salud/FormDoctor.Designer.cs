namespace Centro_salud
{
    partial class FormDoctor
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbBuscar;
        private System.Windows.Forms.Label lblBuscar_paciente;
        private System.Windows.Forms.TextBox txtBuscar_paciente;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.GroupBox gbTriaje;
        private System.Windows.Forms.DataGridView dgvDatosPaciente;
        private System.Windows.Forms.GroupBox gbAtencion;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label lblReceta;
        private System.Windows.Forms.TextBox txtReceta;
        private System.Windows.Forms.Button botonGuardar;
        private System.Windows.Forms.Button botonRegresar;

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
            lblBuscar_paciente = new Label();
            txtBuscar_paciente = new TextBox();
            botonBuscar = new Button();
            gbTriaje = new GroupBox();
            dgvDatosPaciente = new DataGridView();
            gbAtencion = new GroupBox();
            lblDiagnostico = new Label();
            txtDiagnostico = new TextBox();
            lblReceta = new Label();
            txtReceta = new TextBox();
            botonGuardar = new Button();
            botonRegresar = new Button();
            panelContenedor.SuspendLayout();
            gbBuscar.SuspendLayout();
            gbTriaje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatosPaciente).BeginInit();
            gbAtencion.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.White;
            panelContenedor.BorderStyle = BorderStyle.FixedSingle;
            panelContenedor.Controls.Add(lblTitulo);
            panelContenedor.Controls.Add(gbBuscar);
            panelContenedor.Controls.Add(gbTriaje);
            panelContenedor.Controls.Add(gbAtencion);
            panelContenedor.Controls.Add(botonGuardar);
            panelContenedor.Controls.Add(botonRegresar);
            panelContenedor.Location = new Point(25, 20);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(890, 680);
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
            lblTitulo.Size = new Size(888, 60);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "ATENCIÓN MÉDICA - CONSULTORIO";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbBuscar
            // 
            gbBuscar.Controls.Add(lblBuscar_paciente);
            gbBuscar.Controls.Add(txtBuscar_paciente);
            gbBuscar.Controls.Add(botonBuscar);
            gbBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbBuscar.ForeColor = Color.FromArgb(33, 37, 41);
            gbBuscar.Location = new Point(25, 75);
            gbBuscar.Name = "gbBuscar";
            gbBuscar.Size = new Size(835, 75);
            gbBuscar.TabIndex = 1;
            gbBuscar.TabStop = false;
            gbBuscar.Text = "Búsqueda del Paciente";
            // 
            // lblBuscar_paciente
            // 
            lblBuscar_paciente.AutoSize = true;
            lblBuscar_paciente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBuscar_paciente.Location = new Point(20, 32);
            lblBuscar_paciente.Name = "lblBuscar_paciente";
            lblBuscar_paciente.Size = new Size(122, 19);
            lblBuscar_paciente.TabIndex = 0;
            lblBuscar_paciente.Text = "DNI del Paciente:";
            // 
            // txtBuscar_paciente
            // 
            txtBuscar_paciente.Font = new Font("Segoe UI", 10F);
            txtBuscar_paciente.Location = new Point(155, 29);
            txtBuscar_paciente.MaxLength = 8;
            txtBuscar_paciente.Name = "txtBuscar_paciente";
            txtBuscar_paciente.PlaceholderText = "Ingrese 8 dígitos de DNI";
            txtBuscar_paciente.Size = new Size(260, 25);
            txtBuscar_paciente.TabIndex = 1;
            txtBuscar_paciente.KeyPress += txtBuscar_paciente_KeyPress;
            // 
            // botonBuscar
            // 
            botonBuscar.BackColor = Color.FromArgb(13, 110, 253);
            botonBuscar.Cursor = Cursors.Hand;
            botonBuscar.FlatAppearance.BorderSize = 0;
            botonBuscar.FlatStyle = FlatStyle.Flat;
            botonBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            botonBuscar.ForeColor = Color.White;
            botonBuscar.Location = new Point(440, 25);
            botonBuscar.Name = "botonBuscar";
            botonBuscar.Size = new Size(180, 32);
            botonBuscar.TabIndex = 2;
            botonBuscar.Text = "Buscar Paciente";
            botonBuscar.UseVisualStyleBackColor = false;
            botonBuscar.Click += botonBuscar_Click;
            // 
            // gbTriaje
            // 
            gbTriaje.Controls.Add(dgvDatosPaciente);
            gbTriaje.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbTriaje.ForeColor = Color.FromArgb(33, 37, 41);
            gbTriaje.Location = new Point(25, 160);
            gbTriaje.Name = "gbTriaje";
            gbTriaje.Size = new Size(835, 165);
            gbTriaje.TabIndex = 2;
            gbTriaje.TabStop = false;
            gbTriaje.Text = "Datos Generales y Triaje del Paciente";
            // 
            // dgvDatosPaciente
            // 
            dgvDatosPaciente.AllowUserToAddRows = false;
            dgvDatosPaciente.AllowUserToDeleteRows = false;
            dgvDatosPaciente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDatosPaciente.BackgroundColor = Color.FromArgb(248, 249, 250);
            dgvDatosPaciente.BorderStyle = BorderStyle.None;
            dgvDatosPaciente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatosPaciente.Dock = DockStyle.Fill;
            dgvDatosPaciente.Location = new Point(3, 21);
            dgvDatosPaciente.MultiSelect = false;
            dgvDatosPaciente.Name = "dgvDatosPaciente";
            dgvDatosPaciente.ReadOnly = true;
            dgvDatosPaciente.RowHeadersVisible = false;
            dgvDatosPaciente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatosPaciente.Size = new Size(829, 141);
            dgvDatosPaciente.TabIndex = 0;
            // 
            // gbAtencion
            // 
            gbAtencion.Controls.Add(lblDiagnostico);
            gbAtencion.Controls.Add(txtDiagnostico);
            gbAtencion.Controls.Add(lblReceta);
            gbAtencion.Controls.Add(txtReceta);
            gbAtencion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbAtencion.ForeColor = Color.FromArgb(33, 37, 41);
            gbAtencion.Location = new Point(25, 335);
            gbAtencion.Name = "gbAtencion";
            gbAtencion.Size = new Size(835, 260);
            gbAtencion.TabIndex = 3;
            gbAtencion.TabStop = false;
            gbAtencion.Text = "Evaluación y Tratamiento";
            // 
            // lblDiagnostico
            // 
            lblDiagnostico.AutoSize = true;
            lblDiagnostico.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDiagnostico.Location = new Point(20, 28);
            lblDiagnostico.Name = "lblDiagnostico";
            lblDiagnostico.Size = new Size(92, 19);
            lblDiagnostico.TabIndex = 0;
            lblDiagnostico.Text = "Diagnóstico:";
            // 
            // txtDiagnostico
            // 
            txtDiagnostico.Font = new Font("Segoe UI", 10F);
            txtDiagnostico.Location = new Point(20, 52);
            txtDiagnostico.MaxLength = 500;
            txtDiagnostico.Multiline = true;
            txtDiagnostico.Name = "txtDiagnostico";
            txtDiagnostico.ScrollBars = ScrollBars.Vertical;
            txtDiagnostico.Size = new Size(795, 75);
            txtDiagnostico.TabIndex = 1;
            // 
            // lblReceta
            // 
            lblReceta.AutoSize = true;
            lblReceta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblReceta.Location = new Point(20, 138);
            lblReceta.Name = "lblReceta";
            lblReceta.Size = new Size(139, 19);
            lblReceta.TabIndex = 2;
            lblReceta.Text = "Receta / Indicación:";
            // 
            // txtReceta
            // 
            txtReceta.Font = new Font("Segoe UI", 10F);
            txtReceta.Location = new Point(20, 162);
            txtReceta.MaxLength = 500;
            txtReceta.Multiline = true;
            txtReceta.Name = "txtReceta";
            txtReceta.ScrollBars = ScrollBars.Vertical;
            txtReceta.Size = new Size(795, 80);
            txtReceta.TabIndex = 3;
            // 
            // botonGuardar
            // 
            botonGuardar.BackColor = Color.FromArgb(25, 135, 84);
            botonGuardar.Cursor = Cursors.Hand;
            botonGuardar.FlatAppearance.BorderSize = 0;
            botonGuardar.FlatStyle = FlatStyle.Flat;
            botonGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botonGuardar.ForeColor = Color.White;
            botonGuardar.Location = new Point(230, 610);
            botonGuardar.Name = "botonGuardar";
            botonGuardar.Size = new Size(200, 45);
            botonGuardar.TabIndex = 4;
            botonGuardar.Text = "Guardar Consulta";
            botonGuardar.UseVisualStyleBackColor = false;
            botonGuardar.Click += botonGuardar_Click;
            // 
            // botonRegresar
            // 
            botonRegresar.BackColor = Color.FromArgb(108, 117, 125);
            botonRegresar.Cursor = Cursors.Hand;
            botonRegresar.FlatAppearance.BorderSize = 0;
            botonRegresar.FlatStyle = FlatStyle.Flat;
            botonRegresar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botonRegresar.ForeColor = Color.White;
            botonRegresar.Location = new Point(470, 610);
            botonRegresar.Name = "botonRegresar";
            botonRegresar.Size = new Size(190, 45);
            botonRegresar.TabIndex = 5;
            botonRegresar.Text = "Regresar al Login";
            botonRegresar.UseVisualStyleBackColor = false;
            botonRegresar.Click += botonRegresar_Click;
            // 
            // FormDoctor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(940, 720);
            Controls.Add(panelContenedor);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormDoctor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Centro de Salud - Módulo de Doctor";
            FormClosing += FormDoctor_FormClosing;
            panelContenedor.ResumeLayout(false);
            gbBuscar.ResumeLayout(false);
            gbBuscar.PerformLayout();
            gbTriaje.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatosPaciente).EndInit();
            gbAtencion.ResumeLayout(false);
            gbAtencion.PerformLayout();
            ResumeLayout(false);
        }
    }
}
