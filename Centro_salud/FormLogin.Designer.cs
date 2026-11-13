namespace Centro_salud
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTarjeta;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSubheader;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox comboboxUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Button botonIngresar;
        private System.Windows.Forms.Button botonRegistrarCita;
        private System.Windows.Forms.Button botonSalir;
        private System.Windows.Forms.Label lblNotaCredenciales;

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
            panelTarjeta = new Panel();
            lblHeader = new Label();
            lblSubheader = new Label();
            lblUsuario = new Label();
            comboboxUsuario = new ComboBox();
            lblContraseña = new Label();
            txtContraseña = new TextBox();
            lblNotaCredenciales = new Label();
            botonIngresar = new Button();
            botonRegistrarCita = new Button();
            botonSalir = new Button();
            panelTarjeta.SuspendLayout();
            SuspendLayout();
            // 
            // panelTarjeta
            // 
            panelTarjeta.BackColor = Color.White;
            panelTarjeta.BorderStyle = BorderStyle.FixedSingle;
            panelTarjeta.Controls.Add(lblHeader);
            panelTarjeta.Controls.Add(lblSubheader);
            panelTarjeta.Controls.Add(lblUsuario);
            panelTarjeta.Controls.Add(comboboxUsuario);
            panelTarjeta.Controls.Add(lblContraseña);
            panelTarjeta.Controls.Add(txtContraseña);
            panelTarjeta.Controls.Add(lblNotaCredenciales);
            panelTarjeta.Controls.Add(botonIngresar);
            panelTarjeta.Controls.Add(botonRegistrarCita);
            panelTarjeta.Controls.Add(botonSalir);
            panelTarjeta.Location = new Point(50, 40);
            panelTarjeta.Name = "panelTarjeta";
            panelTarjeta.Size = new Size(480, 520);
            panelTarjeta.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.BackColor = Color.FromArgb(13, 110, 253);
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(478, 60);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "CENTRO DE SALUD";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubheader
            // 
            lblSubheader.Font = new Font("Segoe UI", 10.5F);
            lblSubheader.ForeColor = Color.FromArgb(108, 117, 125);
            lblSubheader.Location = new Point(30, 75);
            lblSubheader.Name = "lblSubheader";
            lblSubheader.Size = new Size(420, 25);
            lblSubheader.TabIndex = 1;
            lblSubheader.Text = "Ingrese con su perfil correspondiente";
            lblSubheader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(33, 37, 41);
            lblUsuario.Location = new Point(50, 115);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(65, 19);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario:";
            // 
            // comboboxUsuario
            // 
            comboboxUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            comboboxUsuario.Font = new Font("Segoe UI", 11F);
            comboboxUsuario.FormattingEnabled = true;
            comboboxUsuario.Items.AddRange(new object[] { "Paciente", "Topico", "Doctor" });
            comboboxUsuario.Location = new Point(50, 140);
            comboboxUsuario.Name = "comboboxUsuario";
            comboboxUsuario.Size = new Size(380, 28);
            comboboxUsuario.TabIndex = 3;
            comboboxUsuario.SelectedIndexChanged += comboboxUsuario_SelectedIndexChanged;
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblContraseña.ForeColor = Color.FromArgb(33, 37, 41);
            lblContraseña.Location = new Point(50, 190);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(88, 19);
            lblContraseña.TabIndex = 4;
            lblContraseña.Text = "Contraseña:";
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new Font("Segoe UI", 11F);
            txtContraseña.Location = new Point(50, 215);
            txtContraseña.MaxLength = 30;
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.PlaceholderText = "Ingrese su contraseña";
            txtContraseña.Size = new Size(380, 27);
            txtContraseña.TabIndex = 5;
            // 
            // lblNotaCredenciales
            // 
            lblNotaCredenciales.BackColor = Color.FromArgb(248, 249, 250);
            lblNotaCredenciales.BorderStyle = BorderStyle.FixedSingle;
            lblNotaCredenciales.Font = new Font("Segoe UI", 8.5F);
            lblNotaCredenciales.ForeColor = Color.FromArgb(108, 117, 125);
            lblNotaCredenciales.Location = new Point(50, 260);
            lblNotaCredenciales.Name = "lblNotaCredenciales";
            lblNotaCredenciales.Padding = new Padding(8);
            lblNotaCredenciales.Size = new Size(380, 48);
            lblNotaCredenciales.TabIndex = 6;
            lblNotaCredenciales.Text = "Contraseñas por defecto: Tópico y Doctor (123). Paciente ingresa con la contraseña creada al Registrar Cita.";
            lblNotaCredenciales.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // botonIngresar
            // 
            botonIngresar.BackColor = Color.FromArgb(13, 110, 253);
            botonIngresar.Cursor = Cursors.Hand;
            botonIngresar.FlatAppearance.BorderSize = 0;
            botonIngresar.FlatStyle = FlatStyle.Flat;
            botonIngresar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botonIngresar.ForeColor = Color.White;
            botonIngresar.Location = new Point(50, 325);
            botonIngresar.Name = "botonIngresar";
            botonIngresar.Size = new Size(380, 42);
            botonIngresar.TabIndex = 7;
            botonIngresar.Text = "Ingresar";
            botonIngresar.UseVisualStyleBackColor = false;
            botonIngresar.Click += botonIngresar_Click;
            // 
            // botonRegistrarCita
            // 
            botonRegistrarCita.BackColor = Color.FromArgb(25, 135, 84);
            botonRegistrarCita.Cursor = Cursors.Hand;
            botonRegistrarCita.FlatAppearance.BorderSize = 0;
            botonRegistrarCita.FlatStyle = FlatStyle.Flat;
            botonRegistrarCita.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botonRegistrarCita.ForeColor = Color.White;
            botonRegistrarCita.Location = new Point(50, 380);
            botonRegistrarCita.Name = "botonRegistrarCita";
            botonRegistrarCita.Size = new Size(380, 42);
            botonRegistrarCita.TabIndex = 8;
            botonRegistrarCita.Text = "Registrar Cita";
            botonRegistrarCita.UseVisualStyleBackColor = false;
            botonRegistrarCita.Click += botonRegistrarCita_Click;
            // 
            // botonSalir
            // 
            botonSalir.BackColor = Color.FromArgb(108, 117, 125);
            botonSalir.Cursor = Cursors.Hand;
            botonSalir.FlatAppearance.BorderSize = 0;
            botonSalir.FlatStyle = FlatStyle.Flat;
            botonSalir.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            botonSalir.ForeColor = Color.White;
            botonSalir.Location = new Point(50, 435);
            botonSalir.Name = "botonSalir";
            botonSalir.Size = new Size(380, 40);
            botonSalir.TabIndex = 9;
            botonSalir.Text = "Salir";
            botonSalir.UseVisualStyleBackColor = false;
            botonSalir.Click += botonSalir_Click;
            // 
            // FormLogin
            // 
            AcceptButton = botonIngresar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(580, 600);
            Controls.Add(panelTarjeta);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Centro de Salud - Iniciar Sesión";
            panelTarjeta.ResumeLayout(false);
            panelTarjeta.PerformLayout();
            ResumeLayout(false);
        }
    }
}
