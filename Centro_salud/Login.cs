using System;
using System.Windows.Forms;
using Centro_salud.Data;
using Centro_salud.Models;

namespace Centro_salud
{
    // Formulario principal de Login para autenticar a Paciente, Topico y Doctor
    public partial class Login : Form
    {
        // Instancia del repositorio para consultar los datos de los pacientes
        private readonly PacienteRepository _repo;

        // Constructor del formulario Login
        public Login()
        {
            InitializeComponent(); // Inicializa los componentes visuales de la interfaz
            _repo = new PacienteRepository(); // Inicializa el acceso a datos
            comboboxUsuario.SelectedIndex = 0; // Selecciona la primera opción por defecto
            this.FormClosing += Login_FormClosing; // Asigna el evento de cierre de ventana
        }

        // Evento que se ejecuta al cambiar la selección en el ComboBox de usuarios
        private void comboboxUsuario_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string seleccionado = comboboxUsuario.SelectedItem?.ToString() ?? string.Empty;

            // Actualiza el texto de ayuda según el rol seleccionado
            if (seleccionado == "Paciente")
            {
                lblNotaCredenciales.Text = "Para Paciente: Ingrese la contraseña creada en el formulario 'Registrar Cita'.";
            }
            else
            {
                lblNotaCredenciales.Text = $"Para {seleccionado}: La contraseña de acceso es 123.";
            }

            // Limpia y restablece la caja de contraseña
            txtContraseña.Clear();
            txtContraseña.PasswordChar = '*';
            btnVerContraseña.Text = "👁";
            txtContraseña.Focus();
        }

        // Evento para alternar entre mostrar u ocultar la contraseña con el ojito
        private void btnVerContraseña_Click(object? sender, EventArgs e)
        {
            // Si la contraseña está oculta con asterisco, la mostramos en texto claro
            if (txtContraseña.PasswordChar == '*')
            {
                txtContraseña.PasswordChar = '\0';
                btnVerContraseña.Text = "🙈";
            }
            else
            {
                // Si está visible, volvemos a ocultarla con asterisco
                txtContraseña.PasswordChar = '*';
                btnVerContraseña.Text = "👁";
            }
        }

        // Evento del botón Ingresar para autenticar las credenciales según el tipo de usuario
        private void botonIngresar_Click(object? sender, EventArgs e)
        {
            // 1. Validar que se haya seleccionado un tipo de usuario
            if (comboboxUsuario.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione un tipo de usuario (Paciente, Topico o Doctor).",
                                "Selección requerida",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboboxUsuario.Focus();
                return;
            }

            string tipoUsuario = comboboxUsuario.SelectedItem.ToString() ?? string.Empty;
            string contraseña = txtContraseña.Text.Trim();

            // 2. Validar que la contraseña no esté vacía
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Por favor ingrese su contraseña.",
                                "Contraseña requerida",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Focus();
                return;
            }

            // 3. Caso de usuario Tópico
            if (tipoUsuario == "Topico")
            {
                if (contraseña == "123")
                {
                    txtContraseña.Clear();
                    this.Hide();
                    Topico formTopico = new Topico(this);
                    formTopico.Show(); // Abre el formulario de Tópico/Triaje
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta para el usuario Tópico.\nLa contraseña predeterminada es: 123",
                                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContraseña.Focus();
                    txtContraseña.SelectAll();
                }
            }
            // 4. Caso de usuario Doctor
            else if (tipoUsuario == "Doctor")
            {
                if (contraseña == "123")
                {
                    txtContraseña.Clear();
                    this.Hide();
                    Doctor formDoctor = new Doctor(this);
                    formDoctor.Show(); // Abre el formulario de Doctor
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta para el usuario Doctor.\nLa contraseña predeterminada es: 123",
                                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContraseña.Focus();
                    txtContraseña.SelectAll();
                }
            }
            // 5. Caso de usuario Paciente
            else if (tipoUsuario == "Paciente")
            {
                // Búsqueda en arreglo de pacientes utilizando bucle for clásico (sin foreach)
                Centro_salud.Models.Paciente[] pacientes = _repo.ObtenerTodos();
                Centro_salud.Models.Paciente? pacienteEncontrado = null;

                // Bucle for clásico para buscar la contraseña en el arreglo
                for (int i = 0; i < pacientes.Length; i++)
                {
                    if (pacientes[i].Contraseña == contraseña)
                    {
                        pacienteEncontrado = pacientes[i];
                        break; // Se encontró al paciente, salimos del bucle
                    }
                }

                // Si se encontró el paciente, abrimos su formulario de consulta
                if (pacienteEncontrado != null)
                {
                    txtContraseña.Clear();
                    this.Hide();
                    Paciente formPaciente = new Paciente(this, pacienteEncontrado.Dni);
                    formPaciente.Show();
                }
                else
                {
                    MessageBox.Show(
                        "Contraseña de paciente no encontrada o incorrecta.\n" +
                        "Si aún no tiene una cuenta registrada, haga clic en 'Registrar Cita' para registrarse y crear su contraseña.",
                        "Acceso denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtContraseña.Focus();
                    txtContraseña.SelectAll();
                }
            }
        }

        // Evento para abrir el formulario de Registrar Cita
        private void botonRegistrarCita_Click(object? sender, EventArgs e)
        {
            txtContraseña.Clear();
            this.Hide();
            RegistroCita formRegistro = new RegistroCita(this);
            formRegistro.Show();
        }

        // Evento del botón Salir para cerrar la aplicación con confirmación
        private void botonSalir_Click(object? sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show(
                "¿Está seguro de que desea salir del sistema Centro de Salud?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Evento que se ejecuta al presionar la 'X' para cerrar la ventana
        private void Login_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var confirmacion = MessageBox.Show(
                    "¿Está seguro de que desea salir del sistema Centro de Salud?",
                    "Confirmar Salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.No)
                {
                    e.Cancel = true; // Cancela el cierre de la ventana
                }
            }
        }
    }
}
