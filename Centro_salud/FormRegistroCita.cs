using System;
using System.Drawing;
using System.Windows.Forms;
using Centro_salud.Data;
using Centro_salud.Helpers;
using Centro_salud.Models;

namespace Centro_salud
{
    public partial class FormRegistroCita : Form
    {
        private readonly Form? _formularioLogin;
        private readonly PacienteRepository _repo;

        public FormRegistroCita(Form? formularioLogin = null)
        {
            InitializeComponent();
            _formularioLogin = formularioLogin;
            _repo = new PacienteRepository();

            txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            comboboxSis.SelectedIndex = 0;
            comboboxEspecialidad.SelectedIndex = 0;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirSoloLetras(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirSoloLetras(e);
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirSoloNumeros(e);
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirSoloNumeros(e);
        }

        private void comboboxSis_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboboxSis.SelectedItem != null)
            {
                string seleccion = comboboxSis.SelectedItem.ToString() ?? "No";
                if (seleccion.Equals("Si", StringComparison.OrdinalIgnoreCase))
                {
                    lblAvisoPago.Text = "Tarifa actual: Cuenta con SIS. Monto a pagar: S/. 0 soles.";
                    lblAvisoPago.ForeColor = Color.FromArgb(25, 135, 84);
                }
                else
                {
                    lblAvisoPago.Text = "Tarifa actual: No cuenta con SIS. Monto a pagar: S/. 20 soles.";
                    lblAvisoPago.ForeColor = Color.FromArgb(220, 53, 69);
                }
            }
        }

        private void botonRegistra_Click(object? sender, EventArgs e)
        {
            // 1. ARREGLOS DE CONTROLES Y CADENAS DE CARACTERES PARA LOS NOMBRES
            TextBox[] cajasTexto = { txtNombre, txtApellido, txtEdad, txtDni, txtFecha, txtRegistro_contraseña };
            string[] nombresCampos = { "Nombre", "Apellido", "Edad", "DNI", "Fecha", "Contraseña" };

            // 2. BUCLE FOR CLÁSICO para recorrer los arreglos y validar campos vacíos
            for (int i = 0; i < cajasTexto.Length; i++)
            {
                string valorTexto = cajasTexto[i].Text.Trim();

                if (string.IsNullOrWhiteSpace(valorTexto))
                {
                    MessageBox.Show($"El campo '{nombresCampos[i]}' es obligatorio. Por favor complételo.",
                                    "Campo requerido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    cajasTexto[i].Focus();
                    return;
                }
            }

            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string edadStr = txtEdad.Text.Trim();
            string dni = txtDni.Text.Trim();
            string sis = comboboxSis.SelectedItem?.ToString() ?? string.Empty;
            string fecha = txtFecha.Text.Trim();
            string especialidad = comboboxEspecialidad.SelectedItem?.ToString() ?? string.Empty;
            string contraseña = txtRegistro_contraseña.Text.Trim();

            if (dni.Length != 8)
            {
                MessageBox.Show("El DNI debe contener exactamente 8 dígitos.", "DNI inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return;
            }

            // Arreglo de caracteres para validar que cada dígito del DNI sea numérico con bucle for clásico
            char[] caracteresDni = dni.ToCharArray();
            for (int i = 0; i < caracteresDni.Length; i++)
            {
                if (!char.IsDigit(caracteresDni[i]))
                {
                    MessageBox.Show("El DNI solo debe contener caracteres numéricos.", "DNI inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDni.Focus();
                    return;
                }
            }

            if (!int.TryParse(edadStr, out int edad) || edad <= 0 || edad > 125)
            {
                MessageBox.Show("Por favor ingrese una edad válida.", "Edad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEdad.Focus();
                return;
            }

            var paciente = new Paciente
            {
                Dni = dni,
                Nombre = nombre,
                Apellido = apellido,
                Edad = edad,
                Sis = sis,
                Fecha = fecha,
                Especialidad = especialidad,
                Contraseña = contraseña
            };

            _repo.Registrar(paciente);

            bool cuentaConSis = sis.Equals("Si", StringComparison.OrdinalIgnoreCase);
            string mensajePago = cuentaConSis
                ? "Cuenta con SIS: Paga 0 soles."
                : "No cuenta con SIS: Paga 20 soles.";

            MessageBox.Show(
                $"Registrado con éxito.\n\n" +
                $"Paciente: {nombre} {apellido}\n" +
                $"DNI: {dni}\n" +
                $"Especialidad: {especialidad}\n" +
                $"Costo de atención: {mensajePago}\n" +
                $"Contraseña registrada para inicio de sesión de paciente.",
                "Registro de Cita Exitoso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            // Arreglo de cajas de texto para la limpieza
            TextBox[] cajasTexto = { txtNombre, txtApellido, txtEdad, txtDni, txtRegistro_contraseña, txtFecha };

            // BUCLE FOR CLÁSICO para limpiar cada caja mediante su índice numérico (i)
            for (int i = 0; i < cajasTexto.Length; i++)
            {
                cajasTexto[i].Clear();
            }

            txtRegistro_contraseña.PasswordChar = '*';
            btnVerContraseña.Text = "👁";
            comboboxSis.SelectedIndex = 0;
            comboboxEspecialidad.SelectedIndex = 0;
            txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            txtNombre.Focus();
        }

        private void btnVerContraseña_Click(object? sender, EventArgs e)
        {
            if (txtRegistro_contraseña.PasswordChar == '*')
            {
                txtRegistro_contraseña.PasswordChar = '\0';
                btnVerContraseña.Text = "🙈";
            }
            else
            {
                txtRegistro_contraseña.PasswordChar = '*';
                btnVerContraseña.Text = "👁";
            }
        }

        private void botonLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void botonRegresar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void FormRegistroCita_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_formularioLogin != null && !_formularioLogin.IsDisposed)
            {
                _formularioLogin.Show();
            }
        }
    }
}