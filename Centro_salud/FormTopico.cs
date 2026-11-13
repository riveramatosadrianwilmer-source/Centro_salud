using System;
using System.Windows.Forms;
using Centro_salud.Data;
using Centro_salud.Helpers;
using Centro_salud.Models;

namespace Centro_salud
{
    public partial class FormTopico : Form
    {
        private readonly Form? _formularioLogin;
        private readonly PacienteRepository _repo;
        private Paciente? _pacienteActual;

        public FormTopico(Form? formularioLogin = null)
        {
            InitializeComponent();
            _formularioLogin = formularioLogin;
            _repo = new PacienteRepository();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirSoloNumeros(e);
        }

        private void txtTemperatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirDecimales(e, txtTemperatura);
        }

        private void txtTalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirDecimales(e, txtTalla);
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirDecimales(e, txtPeso);
        }

        private void txtPresion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirPresion(e, txtPresion);
        }

        private void botonBuscar_Click(object? sender, EventArgs e)
        {
            string dni = txtBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show("Por favor ingrese el número de DNI a buscar.", "DNI requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscar.Focus();
                return;
            }

            _pacienteActual = _repo.BuscarPorDni(dni);

            if (_pacienteActual == null)
            {
                MessageBox.Show($"No se encontró ningún paciente registrado con el DNI: {dni}", "Paciente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario(mantenerDni: true);
                return;
            }

            txtNombre.Text = $"{_pacienteActual.Nombre} {_pacienteActual.Apellido}";
            txtespecialidad.Text = _pacienteActual.Especialidad;
            txtTemperatura.Text = _pacienteActual.Temperatura;
            txtTalla.Text = _pacienteActual.Talla;
            txtPeso.Text = _pacienteActual.Peso;
            txtPresion.Text = _pacienteActual.Presion;

            txtTemperatura.Focus();
        }

        private void botonGuardar_Click(object? sender, EventArgs e)
        {
            if (_pacienteActual == null)
            {
                MessageBox.Show("Primero debe buscar y seleccionar un paciente registrado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscar.Focus();
                return;
            }

            string temp = txtTemperatura.Text.Trim();
            string talla = txtTalla.Text.Trim();
            string peso = txtPeso.Text.Trim();
            string presion = txtPresion.Text.Trim();

            if (string.IsNullOrWhiteSpace(temp) ||
                string.IsNullOrWhiteSpace(talla) ||
                string.IsNullOrWhiteSpace(peso) ||
                string.IsNullOrWhiteSpace(presion))
            {
                MessageBox.Show("Por favor complete todos los datos de signos vitales (Temperatura, Talla, Peso y Presión).", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool exito = _repo.ActualizarTopico(_pacienteActual.Dni, temp, talla, peso, presion);

            if (exito)
            {
                MessageBox.Show(
                    $"Datos de triaje guardados con éxito para el paciente:\n" +
                    $"DNI: {_pacienteActual.Dni}\n" +
                    $"Paciente: {_pacienteActual.Nombre} {_pacienteActual.Apellido}\n" +
                    $"Temperatura: {temp} °C | Talla: {talla} m | Peso: {peso} kg | Presión: {presion}",
                    "Triaje Guardado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarFormulario(mantenerDni: false);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la información en el archivo de texto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario(bool mantenerDni)
        {
            if (!mantenerDni)
            {
                txtBuscar.Clear();
                _pacienteActual = null;
            }
            txtNombre.Clear();
            txtespecialidad.Clear();
            txtTemperatura.Clear();
            txtTalla.Clear();
            txtPeso.Clear();
            txtPresion.Clear();
        }

        private void botonRegresar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTopico_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_formularioLogin != null && !_formularioLogin.IsDisposed)
            {
                _formularioLogin.Show();
            }
        }
    }
}
