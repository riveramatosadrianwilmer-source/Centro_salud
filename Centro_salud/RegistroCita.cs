using System;
using System.Drawing;
using System.Windows.Forms;
using Centro_salud.Data;
using Centro_salud.Helpers;
using Centro_salud.Models;

namespace Centro_salud
{
    // Formulario para registrar una nueva cita médica y crear la cuenta del paciente
    public partial class RegistroCita : Form
    {
        // Referencia al formulario de Login para volver al terminar
        private readonly Form? _formularioLogin;

        // Repositorio para guardar los datos en el archivo de texto
        private readonly PacienteRepository _repo;

        // Constructor del formulario RegistroCita
        public RegistroCita(Form? formularioLogin = null)
        {
            InitializeComponent(); // Inicializa los controles visuales de la interfaz
            _formularioLogin = formularioLogin;
            _repo = new PacienteRepository();

            // Configuración de valores iniciales por defecto
            txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            comboboxSis.SelectedIndex = 0;
            comboboxEspecialidad.SelectedIndex = 0;
        }

        // Restricción: solo letras en el nombre
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirSoloLetras(e);
        }

        // Restricción: solo letras en el apellido
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirSoloLetras(e);
        }

        // Restricción: solo números en la edad
        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirSoloNumeros(e);
        }

        // Restricción: solo números en el DNI
        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirSoloNumeros(e);
        }

        // Evento que actualiza la tarifa a pagar cuando se cambia la opción del SIS
        private void comboboxSis_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboboxSis.SelectedItem != null)
            {
                string seleccion = comboboxSis.SelectedItem.ToString() ?? "No";
                if (seleccion == "Si")
                {
                    lblAvisoPago.Text = "Tarifa actual: Cuenta con SIS. Monto a pagar: S/. 0 soles.";
                    lblAvisoPago.ForeColor = Color.FromArgb(25, 135, 84); // Verde
                }
                else
                {
                    lblAvisoPago.Text = "Tarifa actual: No cuenta con SIS. Monto a pagar: S/. 20 soles.";
                    lblAvisoPago.ForeColor = Color.FromArgb(220, 53, 69); // Rojo
                }
            }
        }

        // Evento del botón Registrar Cita
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

            // 3. Obtener los valores de los controles
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string edadStr = txtEdad.Text.Trim();
            string dni = txtDni.Text.Trim();
            string sis = comboboxSis.SelectedItem?.ToString() ?? string.Empty;
            string fecha = txtFecha.Text.Trim();
            string especialidad = comboboxEspecialidad.SelectedItem?.ToString() ?? string.Empty;
            string contraseña = txtRegistro_contraseña.Text.Trim();

            // 4. Validar que el DNI tenga exactamente 8 dígitos
            if (dni.Length != 8)
            {
                MessageBox.Show("El DNI debe contener exactamente 8 dígitos.", "DNI inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return;
            }

            // 5. Arreglo de caracteres para validar que cada dígito del DNI sea numérico con bucle for clásico
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

            // 6. Validar que la edad sea un número entero válido y razonable
            if (!int.TryParse(edadStr, out int edad) || edad <= 0 || edad > 125)
            {
                MessageBox.Show("Por favor ingrese una edad válida.", "Edad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEdad.Focus();
                return;
            }

            // 7. Crear el objeto Paciente con los datos ingresados
            var paciente = new Centro_salud.Models.Paciente
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

            // 8. Guardar el nuevo paciente en el archivo de texto a través del repositorio
            _repo.Registrar(paciente);

            // 9. Calcular el mensaje del costo de la atención según el SIS
            string mensajePago = "";
            if (sis == "Si")
            {
                mensajePago = "Cuenta con SIS: Paga 0 soles.";
            }
            else
            {
                mensajePago = "No cuenta con SIS: Paga 20 soles.";
            }

            // 10. Mensaje de confirmación exitosa
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

            // 11. Limpiar los campos para un nuevo registro
            LimpiarCampos();
        }

        // Procedimiento para limpiar los controles utilizando un arreglo y bucle for clásico
        private void LimpiarCampos()
        {
            // Arreglo de cajas de texto para la limpieza masiva
            TextBox[] cajasTexto = { txtNombre, txtApellido, txtEdad, txtDni, txtRegistro_contraseña, txtFecha };

            // Bucle for clásico para limpiar cada caja mediante su índice numérico
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

        // Evento para alternar entre ver y ocultar la contraseña con el ojito
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

        // Evento del botón Limpiar Campos
        private void botonLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Evento del botón Regresar para volver al Login
        private void botonRegresar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        // Evento al cerrar la ventana para reabrir el Login
        private void RegistroCita_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_formularioLogin != null && !_formularioLogin.IsDisposed)
            {
                _formularioLogin.Show();
            }
        }
    }
}
