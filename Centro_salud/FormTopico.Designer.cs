namespace Centro_salud
{
    partial class FormTopico
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label lbltopico;
        private System.Windows.Forms.GroupBox gbBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.GroupBox gbDatosPaciente;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEspecialida;
        private System.Windows.Forms.TextBox txtespecialidad;
        private System.Windows.Forms.GroupBox gbSignosVitales;
        private System.Windows.Forms.Label lblTemperatura;
        private System.Windows.Forms.TextBox txtTemperatura;
        private System.Windows.Forms.Label lblTalla;
        private System.Windows.Forms.TextBox txtTalla;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label lblPresion;
        private System.Windows.Forms.TextBox txtPresion;
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
            lbltopico = new Label();
            gbBuscar = new GroupBox();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            botonBuscar = new Button();
            gbDatosPaciente = new GroupBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblEspecialida = new Label();
            txtespecialidad = new TextBox();
            gbSignosVitales = new GroupBox();
            lblTemperatura = new Label();
            txtTemperatura = new TextBox();
            lblTalla = new Label();
            txtTalla = new TextBox();
            lblPeso = new Label();
            txtPeso = new TextBox();
            lblPresion = new Label();
            txtPresion = new TextBox();
            botonGuardar = new Button();
            botonRegresar = new Button();
            panelContenedor.SuspendLayout();
            gbBuscar.SuspendLayout();
            gbDatosPaciente.SuspendLayout();
            gbSignosVitales.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.White;
            panelContenedor.BorderStyle = BorderStyle.FixedSingle;
            panelContenedor.Controls.Add(lbltopico);
            panelContenedor.Controls.Add(gbBuscar);
            panelContenedor.Controls.Add(gbDatosPaciente);
            panelContenedor.Controls.Add(gbSignosVitales);
            panelContenedor.Controls.Add(botonGuardar);
            panelContenedor.Controls.Add(botonRegresar);
            panelContenedor.Location = new Point(30, 25);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(680, 560);
            panelContenedor.TabIndex = 0;
            // 
            // lbltopico
            // 
            lbltopico.BackColor = Color.FromArgb(13, 110, 253);
            lbltopico.Dock = DockStyle.Top;
            lbltopico.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbltopico.ForeColor = Color.White;
            lbltopico.Location = new Point(0, 0);
            lbltopico.Name = "lbltopico";
            lbltopico.Size = new Size(678, 60);
            lbltopico.TabIndex = 0;
            lbltopico.Text = "MÓDULO DE TÓPICO / TRIAJE";
            lbltopico.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbBuscar
            // 
            gbBuscar.Controls.Add(lblBuscar);
            gbBuscar.Controls.Add(txtBuscar);
            gbBuscar.Controls.Add(botonBuscar);
            gbBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbBuscar.ForeColor = Color.FromArgb(33, 37, 41);
            gbBuscar.Location = new Point(35, 75);
            gbBuscar.Name = "gbBuscar";
            gbBuscar.Size = new Size(610, 80);
            gbBuscar.TabIndex = 1;
            gbBuscar.TabStop = false;
            gbBuscar.Text = "Búsqueda de Paciente";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBuscar.Location = new Point(20, 35);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(106, 19);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "DNI Registrado:";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.Location = new Point(140, 32);
            txtBuscar.MaxLength = 8;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ingrese 8 dígitos";
            txtBuscar.Size = new Size(240, 25);
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
            botonBuscar.Location = new Point(410, 27);
            botonBuscar.Name = "botonBuscar";
            botonBuscar.Size = new Size(170, 35);
            botonBuscar.TabIndex = 2;
            botonBuscar.Text = "Buscar Paciente";
            botonBuscar.UseVisualStyleBackColor = false;
            botonBuscar.Click += botonBuscar_Click;
            // 
            // gbDatosPaciente
            // 
            gbDatosPaciente.Controls.Add(lblNombre);
            gbDatosPaciente.Controls.Add(txtNombre);
            gbDatosPaciente.Controls.Add(lblEspecialida);
            gbDatosPaciente.Controls.Add(txtespecialidad);
            gbDatosPaciente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbDatosPaciente.ForeColor = Color.FromArgb(33, 37, 41);
            gbDatosPaciente.Location = new Point(35, 170);
            gbDatosPaciente.Name = "gbDatosPaciente";
            gbDatosPaciente.Size = new Size(610, 110);
            gbDatosPaciente.TabIndex = 2;
            gbDatosPaciente.TabStop = false;
            gbDatosPaciente.Text = "Datos Generales";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombre.Location = new Point(20, 35);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(69, 19);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Paciente:";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.FromArgb(245, 247, 250);
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtNombre.Location = new Point(140, 32);
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(440, 25);
            txtNombre.TabIndex = 1;
            // 
            // lblEspecialida
            // 
            lblEspecialida.AutoSize = true;
            lblEspecialida.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEspecialida.Location = new Point(20, 72);
            lblEspecialida.Name = "lblEspecialida";
            lblEspecialida.Size = new Size(95, 19);
            lblEspecialida.TabIndex = 2;
            lblEspecialida.Text = "Especialidad:";
            // 
            // txtespecialidad
            // 
            txtespecialidad.BackColor = Color.FromArgb(245, 247, 250);
            txtespecialidad.Font = new Font("Segoe UI", 10F);
            txtespecialidad.Location = new Point(140, 69);
            txtespecialidad.Name = "txtespecialidad";
            txtespecialidad.ReadOnly = true;
            txtespecialidad.Size = new Size(440, 25);
            txtespecialidad.TabIndex = 3;
            // 
            // gbSignosVitales
            // 
            gbSignosVitales.Controls.Add(lblTemperatura);
            gbSignosVitales.Controls.Add(txtTemperatura);
            gbSignosVitales.Controls.Add(lblTalla);
            gbSignosVitales.Controls.Add(txtTalla);
            gbSignosVitales.Controls.Add(lblPeso);
            gbSignosVitales.Controls.Add(txtPeso);
            gbSignosVitales.Controls.Add(lblPresion);
            gbSignosVitales.Controls.Add(txtPresion);
            gbSignosVitales.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbSignosVitales.ForeColor = Color.FromArgb(33, 37, 41);
            gbSignosVitales.Location = new Point(35, 295);
            gbSignosVitales.Name = "gbSignosVitales";
            gbSignosVitales.Size = new Size(610, 160);
            gbSignosVitales.TabIndex = 3;
            gbSignosVitales.TabStop = false;
            gbSignosVitales.Text = "Registro de Signos Vitales";
            // 
            // lblTemperatura
            // 
            lblTemperatura.AutoSize = true;
            lblTemperatura.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTemperatura.Location = new Point(20, 40);
            lblTemperatura.Name = "lblTemperatura";
            lblTemperatura.Size = new Size(125, 19);
            lblTemperatura.TabIndex = 0;
            lblTemperatura.Text = "Temperatura (°C):";
            // 
            // txtTemperatura
            // 
            txtTemperatura.Font = new Font("Segoe UI", 10F);
            txtTemperatura.Location = new Point(155, 37);
            txtTemperatura.MaxLength = 5;
            txtTemperatura.Name = "txtTemperatura";
            txtTemperatura.PlaceholderText = "ej. 36.5";
            txtTemperatura.Size = new Size(130, 25);
            txtTemperatura.TabIndex = 1;
            txtTemperatura.KeyPress += txtTemperatura_KeyPress;
            // 
            // lblTalla
            // 
            lblTalla.AutoSize = true;
            lblTalla.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTalla.Location = new Point(330, 40);
            lblTalla.Name = "lblTalla";
            lblTalla.Size = new Size(68, 19);
            lblTalla.TabIndex = 2;
            lblTalla.Text = "Talla (m):";
            // 
            // txtTalla
            // 
            txtTalla.Font = new Font("Segoe UI", 10F);
            txtTalla.Location = new Point(440, 37);
            txtTalla.MaxLength = 5;
            txtTalla.Name = "txtTalla";
            txtTalla.PlaceholderText = "ej. 1.70";
            txtTalla.Size = new Size(140, 25);
            txtTalla.TabIndex = 3;
            txtTalla.KeyPress += txtTalla_KeyPress;
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPeso.Location = new Point(20, 100);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(74, 19);
            lblPeso.TabIndex = 4;
            lblPeso.Text = "Peso (kg):";
            // 
            // txtPeso
            // 
            txtPeso.Font = new Font("Segoe UI", 10F);
            txtPeso.Location = new Point(155, 97);
            txtPeso.MaxLength = 6;
            txtPeso.Name = "txtPeso";
            txtPeso.PlaceholderText = "ej. 70.5";
            txtPeso.Size = new Size(130, 25);
            txtPeso.TabIndex = 5;
            txtPeso.KeyPress += txtPeso_KeyPress;
            // 
            // lblPresion
            // 
            lblPresion.AutoSize = true;
            lblPresion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPresion.Location = new Point(330, 100);
            lblPresion.Name = "lblPresion";
            lblPresion.Size = new Size(62, 19);
            lblPresion.TabIndex = 6;
            lblPresion.Text = "Presión:";
            // 
            // txtPresion
            // 
            txtPresion.Font = new Font("Segoe UI", 10F);
            txtPresion.Location = new Point(440, 97);
            txtPresion.MaxLength = 7;
            txtPresion.Name = "txtPresion";
            txtPresion.PlaceholderText = "ej. 120/80";
            txtPresion.Size = new Size(140, 25);
            txtPresion.TabIndex = 7;
            txtPresion.KeyPress += txtPresion_KeyPress;
            // 
            // botonGuardar
            // 
            botonGuardar.BackColor = Color.FromArgb(25, 135, 84);
            botonGuardar.Cursor = Cursors.Hand;
            botonGuardar.FlatAppearance.BorderSize = 0;
            botonGuardar.FlatStyle = FlatStyle.Flat;
            botonGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botonGuardar.ForeColor = Color.White;
            botonGuardar.Location = new Point(140, 480);
            botonGuardar.Name = "botonGuardar";
            botonGuardar.Size = new Size(190, 45);
            botonGuardar.TabIndex = 4;
            botonGuardar.Text = "Guardar Triaje";
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
            botonRegresar.Location = new Point(360, 480);
            botonRegresar.Name = "botonRegresar";
            botonRegresar.Size = new Size(180, 45);
            botonRegresar.TabIndex = 5;
            botonRegresar.Text = "Regresar al Login";
            botonRegresar.UseVisualStyleBackColor = false;
            botonRegresar.Click += botonRegresar_Click;
            // 
            // FormTopico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(740, 610);
            Controls.Add(panelContenedor);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormTopico";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Centro de Salud - Módulo de Tópico";
            FormClosing += FormTopico_FormClosing;
            panelContenedor.ResumeLayout(false);
            gbBuscar.ResumeLayout(false);
            gbBuscar.PerformLayout();
            gbDatosPaciente.ResumeLayout(false);
            gbDatosPaciente.PerformLayout();
            gbSignosVitales.ResumeLayout(false);
            gbSignosVitales.PerformLayout();
            ResumeLayout(false);
        }
    }
}
