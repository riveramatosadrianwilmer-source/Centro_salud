namespace Centro_salud
{
    partial class RegistroCita
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblSis;
        private System.Windows.Forms.ComboBox comboboxSis;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox comboboxEspecialidad;
        private System.Windows.Forms.Label lblRegistro_contraseña;
        private System.Windows.Forms.TextBox txtRegistro_contraseña;
        private System.Windows.Forms.Button btnVerContraseña;
        private System.Windows.Forms.Button botonRegistra;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonRegresar;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label lblAvisoPago;

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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblEdad = new Label();
            txtEdad = new TextBox();
            lblDni = new Label();
            txtDni = new TextBox();
            lblSis = new Label();
            comboboxSis = new ComboBox();
            lblFecha = new Label();
            txtFecha = new TextBox();
            lblEspecialidad = new Label();
            comboboxEspecialidad = new ComboBox();
            lblRegistro_contraseña = new Label();
            txtRegistro_contraseña = new TextBox();
            btnVerContraseña = new Button();
            lblAvisoPago = new Label();
            botonRegistra = new Button();
            botonLimpiar = new Button();
            botonRegresar = new Button();
            panelContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.White;
            panelContenedor.BorderStyle = BorderStyle.FixedSingle;
            panelContenedor.Controls.Add(lblTitulo);
            panelContenedor.Controls.Add(lblNombre);
            panelContenedor.Controls.Add(txtNombre);
            panelContenedor.Controls.Add(lblApellido);
            panelContenedor.Controls.Add(txtApellido);
            panelContenedor.Controls.Add(lblEdad);
            panelContenedor.Controls.Add(txtEdad);
            panelContenedor.Controls.Add(lblDni);
            panelContenedor.Controls.Add(txtDni);
            panelContenedor.Controls.Add(lblSis);
            panelContenedor.Controls.Add(comboboxSis);
            panelContenedor.Controls.Add(lblFecha);
            panelContenedor.Controls.Add(txtFecha);
            panelContenedor.Controls.Add(lblEspecialidad);
            panelContenedor.Controls.Add(comboboxEspecialidad);
            panelContenedor.Controls.Add(lblRegistro_contraseña);
            panelContenedor.Controls.Add(txtRegistro_contraseña);
            panelContenedor.Controls.Add(btnVerContraseña);
            panelContenedor.Controls.Add(lblAvisoPago);
            panelContenedor.Controls.Add(botonRegistra);
            panelContenedor.Controls.Add(botonLimpiar);
            panelContenedor.Controls.Add(botonRegresar);
            panelContenedor.Location = new Point(35, 25);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(680, 560);
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
            lblTitulo.Size = new Size(678, 60);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRO DE CITA MÉDICA";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(33, 37, 41);
            lblNombre.Location = new Point(45, 85);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(73, 19);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombres:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtNombre.Location = new Point(45, 107);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(270, 25);
            txtNombre.TabIndex = 2;
            txtNombre.KeyPress += txtNombre_KeyPress;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblApellido.ForeColor = Color.FromArgb(33, 37, 41);
            lblApellido.Location = new Point(360, 85);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(74, 19);
            lblApellido.TabIndex = 3;
            lblApellido.Text = "Apellidos:";
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Segoe UI", 10F);
            txtApellido.Location = new Point(360, 107);
            txtApellido.MaxLength = 50;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(270, 25);
            txtApellido.TabIndex = 4;
            txtApellido.KeyPress += txtApellido_KeyPress;
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEdad.ForeColor = Color.FromArgb(33, 37, 41);
            lblEdad.Location = new Point(45, 145);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(46, 19);
            lblEdad.TabIndex = 5;
            lblEdad.Text = "Edad:";
            // 
            // txtEdad
            // 
            txtEdad.Font = new Font("Segoe UI", 10F);
            txtEdad.Location = new Point(45, 167);
            txtEdad.MaxLength = 3;
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(120, 25);
            txtEdad.TabIndex = 6;
            txtEdad.KeyPress += txtEdad_KeyPress;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDni.ForeColor = Color.FromArgb(33, 37, 41);
            lblDni.Location = new Point(195, 145);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(39, 19);
            lblDni.TabIndex = 7;
            lblDni.Text = "DNI:";
            // 
            // txtDni
            // 
            txtDni.Font = new Font("Segoe UI", 10F);
            txtDni.Location = new Point(195, 167);
            txtDni.MaxLength = 8;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(120, 25);
            txtDni.TabIndex = 8;
            txtDni.KeyPress += txtDni_KeyPress;
            // 
            // lblSis
            // 
            lblSis.AutoSize = true;
            lblSis.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSis.ForeColor = Color.FromArgb(33, 37, 41);
            lblSis.Location = new Point(360, 145);
            lblSis.Name = "lblSis";
            lblSis.Size = new Size(123, 19);
            lblSis.TabIndex = 9;
            lblSis.Text = "¿Cuenta con SIS?:";
            // 
            // comboboxSis
            // 
            comboboxSis.DropDownStyle = ComboBoxStyle.DropDownList;
            comboboxSis.Font = new Font("Segoe UI", 10F);
            comboboxSis.FormattingEnabled = true;
            comboboxSis.Items.AddRange(new object[] { "Si", "No" });
            comboboxSis.Location = new Point(360, 167);
            comboboxSis.Name = "comboboxSis";
            comboboxSis.Size = new Size(270, 25);
            comboboxSis.TabIndex = 10;
            comboboxSis.SelectedIndexChanged += comboboxSis_SelectedIndexChanged;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFecha.ForeColor = Color.FromArgb(33, 37, 41);
            lblFecha.Location = new Point(45, 205);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(102, 19);
            lblFecha.TabIndex = 11;
            lblFecha.Text = "Fecha de Cita:";
            // 
            // txtFecha
            // 
            txtFecha.Font = new Font("Segoe UI", 10F);
            txtFecha.Location = new Point(45, 227);
            txtFecha.MaxLength = 10;
            txtFecha.Name = "txtFecha";
            txtFecha.Size = new Size(270, 25);
            txtFecha.TabIndex = 12;
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEspecialidad.ForeColor = Color.FromArgb(33, 37, 41);
            lblEspecialidad.Location = new Point(360, 205);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(95, 19);
            lblEspecialidad.TabIndex = 13;
            lblEspecialidad.Text = "Especialidad:";
            // 
            // comboboxEspecialidad
            // 
            comboboxEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboboxEspecialidad.Font = new Font("Segoe UI", 10F);
            comboboxEspecialidad.FormattingEnabled = true;
            comboboxEspecialidad.Items.AddRange(new object[] {
                "Medicina General",
                "Pediatría",
                "Odontología",
                "Ginecología"
            });
            comboboxEspecialidad.Location = new Point(360, 227);
            comboboxEspecialidad.Name = "comboboxEspecialidad";
            comboboxEspecialidad.Size = new Size(270, 25);
            comboboxEspecialidad.TabIndex = 14;
            // 
            // lblRegistro_contraseña
            // 
            lblRegistro_contraseña.AutoSize = true;
            lblRegistro_contraseña.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRegistro_contraseña.ForeColor = Color.FromArgb(33, 37, 41);
            lblRegistro_contraseña.Location = new Point(45, 270);
            lblRegistro_contraseña.Name = "lblRegistro_contraseña";
            lblRegistro_contraseña.Size = new Size(187, 19);
            lblRegistro_contraseña.TabIndex = 15;
            lblRegistro_contraseña.Text = "Crear Contraseña Paciente:";
            // 
            // txtRegistro_contraseña
            // 
            txtRegistro_contraseña.Font = new Font("Segoe UI", 10F);
            txtRegistro_contraseña.Location = new Point(45, 292);
            txtRegistro_contraseña.MaxLength = 30;
            txtRegistro_contraseña.Name = "txtRegistro_contraseña";
            txtRegistro_contraseña.PasswordChar = '*';
            txtRegistro_contraseña.Size = new Size(225, 25);
            txtRegistro_contraseña.TabIndex = 16;
            // 
            // btnVerContraseña
            // 
            btnVerContraseña.BackColor = Color.FromArgb(240, 244, 248);
            btnVerContraseña.Cursor = Cursors.Hand;
            btnVerContraseña.FlatAppearance.BorderColor = Color.FromArgb(206, 212, 218);
            btnVerContraseña.FlatStyle = FlatStyle.Flat;
            btnVerContraseña.Font = new Font("Segoe UI Emoji", 9.5F);
            btnVerContraseña.Location = new Point(275, 292);
            btnVerContraseña.Name = "btnVerContraseña";
            btnVerContraseña.Size = new Size(40, 25);
            btnVerContraseña.TabIndex = 17;
            btnVerContraseña.Text = "👁";
            btnVerContraseña.UseVisualStyleBackColor = false;
            btnVerContraseña.Click += btnVerContraseña_Click;
            // 
            // lblAvisoPago
            // 
            lblAvisoPago.BackColor = Color.FromArgb(232, 244, 253);
            lblAvisoPago.BorderStyle = BorderStyle.FixedSingle;
            lblAvisoPago.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblAvisoPago.ForeColor = Color.FromArgb(10, 88, 202);
            lblAvisoPago.Location = new Point(45, 340);
            lblAvisoPago.Name = "lblAvisoPago";
            lblAvisoPago.Padding = new Padding(10);
            lblAvisoPago.Size = new Size(585, 55);
            lblAvisoPago.TabIndex = 17;
            lblAvisoPago.Text = "Información de Tarifas: Si cuenta con SIS el costo de atención es S/. 0 soles. Si no cuenta con SIS el costo es S/. 20 soles.";
            lblAvisoPago.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // botonRegistra
            // 
            botonRegistra.BackColor = Color.FromArgb(25, 135, 84);
            botonRegistra.Cursor = Cursors.Hand;
            botonRegistra.FlatAppearance.BorderSize = 0;
            botonRegistra.FlatStyle = FlatStyle.Flat;
            botonRegistra.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botonRegistra.ForeColor = Color.White;
            botonRegistra.Location = new Point(50, 420);
            botonRegistra.Name = "botonRegistra";
            botonRegistra.Size = new Size(180, 45);
            botonRegistra.TabIndex = 18;
            botonRegistra.Text = "Registrar Cita";
            botonRegistra.UseVisualStyleBackColor = false;
            botonRegistra.Click += botonRegistra_Click;
            // 
            // botonLimpiar
            // 
            botonLimpiar.BackColor = Color.FromArgb(13, 110, 253);
            botonLimpiar.Cursor = Cursors.Hand;
            botonLimpiar.FlatAppearance.BorderSize = 0;
            botonLimpiar.FlatStyle = FlatStyle.Flat;
            botonLimpiar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botonLimpiar.ForeColor = Color.White;
            botonLimpiar.Location = new Point(250, 420);
            botonLimpiar.Name = "botonLimpiar";
            botonLimpiar.Size = new Size(170, 45);
            botonLimpiar.TabIndex = 19;
            botonLimpiar.Text = "Limpiar Campos";
            botonLimpiar.UseVisualStyleBackColor = false;
            botonLimpiar.Click += botonLimpiar_Click;
            // 
            // botonRegresar
            // 
            botonRegresar.BackColor = Color.FromArgb(108, 117, 125);
            botonRegresar.Cursor = Cursors.Hand;
            botonRegresar.FlatAppearance.BorderSize = 0;
            botonRegresar.FlatStyle = FlatStyle.Flat;
            botonRegresar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botonRegresar.ForeColor = Color.White;
            botonRegresar.Location = new Point(440, 420);
            botonRegresar.Name = "botonRegresar";
            botonRegresar.Size = new Size(190, 45);
            botonRegresar.TabIndex = 20;
            botonRegresar.Text = "Regresar al Login";
            botonRegresar.UseVisualStyleBackColor = false;
            botonRegresar.Click += botonRegresar_Click;
            // 
            // FormRegistroCita
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(750, 610);
            Controls.Add(panelContenedor);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegistroCita";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Centro de Salud - Registro de Cita";
            FormClosing += RegistroCita_FormClosing;
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
        }
    }
}
