using System;
using System.Windows.Forms;
using Centro_salud.Data;
using Centro_salud.Models;

namespace Centro_salud
{
    public partial class FormLogin : Form
    {
        private readonly PacienteRepository _repo;

        public FormLogin()
        {
            InitializeComponent();
            _repo = new PacienteRepository();
            comboboxUsuario.SelectedIndex = 0;
            this.FormClosing += FormLogin_FormClosing;
        }

        private void comboboxUsuario_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string seleccionado = comboboxUsuario.SelectedItem?.ToString() ?? string.Empty;

            if (seleccionado.Equals("Paciente", StringComparison.OrdinalIgnoreCase))
            {
                lblNotaCredenciales.Text = "Para Paciente: Ingrese la contraseña creada en el formulario 'Registrar Cita'.";
            }
            else
            {
                lblNotaCredenciales.Text = $"Para {seleccionado}: La contraseña de acceso es 123.";
            }

            txtContraseña.Clear();
            txtContraseña.PasswordChar = '*';
            btnVerContraseña.Text = "👁";
            txtContraseña.Focus();
        }

        private void btnVerContraseña_Click(object? sender, EventArgs e)
        {
            if (txtContraseña.PasswordChar == '*')
            {
                txtContraseña.PasswordChar = '\0';
                btnVerContraseña.Text = "🙈";
            }
            else
            {
                txtContraseña.PasswordChar = '*';
                btnVerContraseña.Text = "👁";
            }
        }

        private void botonIngresar_Click(object? sender, EventArgs e)
        {
            if (comboboxUsuario.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione un tipo de usuario (Paciente, Topico o Doctor).", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboboxUsuario.Focus();
                return;
            }

            string tipoUsuario = comboboxUsuario.SelectedItem.ToString() ?? string.Empty;
            string contraseña = txtContraseña.Text.Trim();

            if (string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Por favor ingrese su contraseña.", "Contraseña requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Focus();
                return;
            }

            if (tipoUsuario.Equals("Topico", StringComparison.OrdinalIgnoreCase))
            {
                if (contraseña == "123")
                {
                    txtContraseña.Clear();
                    this.Hide();
                    FormTopico formTopico = new FormTopico(this);
                    formTopico.Show();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta para el usuario Tópico.\nLa contraseña predeterminada es: 123", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContraseña.Focus();
                    txtContraseña.SelectAll();
                }
            }
            else if (tipoUsuario.Equals("Doctor", StringComparison.OrdinalIgnoreCase))
            {
                if (contraseña == "123")
                {
                    txtContraseña.Clear();
                    this.Hide();
                    FormDoctor formDoctor = new FormDoctor(this);
                    formDoctor.Show();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta para el usuario Doctor.\nLa contraseña predeterminada es: 123", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContraseña.Focus();
                    txtContraseña.SelectAll();
                }
            }
            else if (tipoUsuario.Equals("Paciente", StringComparison.OrdinalIgnoreCase))
            {
                if (_repo.ValidarContraseñaPaciente(contraseña, out Paciente? pacienteEncontrado))
                {
                    txtContraseña.Clear();
                    this.Hide();
                    FormPaciente formPaciente = new FormPaciente(this, pacienteEncontrado?.Dni);
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

        private void botonRegistrarCita_Click(object? sender, EventArgs e)
        {
            txtContraseña.Clear();
            this.Hide();
            FormRegistroCita formRegistro = new FormRegistroCita(this);
            formRegistro.Show();
        }

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

        private void FormLogin_FormClosing(object? sender, FormClosingEventArgs e)
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
                    e.Cancel = true;
                }
            }
        }
    }
}
