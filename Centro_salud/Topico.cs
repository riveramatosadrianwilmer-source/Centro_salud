using System;
using System.Windows.Forms;
using Centro_salud.Data;
using Centro_salud.Helpers;
using Centro_salud.Models;
namespace Centro_salud
{
    public partial class Topico : Form
    {
        private readonly Form? _formularioLogin;
        private readonly PacienteRepository _repo;
        private Centro_salud.Models.Paciente? _pacienteActual;

        public Topico(Form? formularioLogin = null)
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

            // Búsqueda del paciente utilizando arreglo y ciclo for clásico (sin foreach)
            Centro_salud.Models.Paciente[] pacientes = _repo.ObtenerTodos();
            _pacienteActual = null;

            for (int i = 0; i < pacientes.Length; i++)
            {
                if (pacientes[i].Dni.Equals(dni, StringComparison.OrdinalIgnoreCase))
                {
                    _pacienteActual = pacientes[i];
                    break;
                }
            }

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

            ActualizarCalculoImc();

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

            // Arreglos de cajas de texto y nombres de los signos vitales
            TextBox[] cajasSignos = { txtTemperatura, txtTalla, txtPeso, txtPresion };
            string[] nombresSignos = { "Temperatura", "Talla", "Peso", "Presión" };

            // Bucle for clásico para validar que no haya campos vacíos
            for (int i = 0; i < cajasSignos.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(cajasSignos[i].Text.Trim()))
                {
                    MessageBox.Show($"Por favor complete el campo de {nombresSignos[i]}.", "Dato incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cajasSignos[i].Focus();
                    return;
                }
            }

            string temp = txtTemperatura.Text.Trim();
            string talla = txtTalla.Text.Trim();
            string peso = txtPeso.Text.Trim();
            string presion = txtPresion.Text.Trim();

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

            // Arreglo de cajas de texto para limpieza con bucle for clásico
            TextBox[] cajasLimpiar = { txtNombre, txtespecialidad, txtTemperatura, txtTalla, txtPeso, txtPresion };
            for (int i = 0; i < cajasLimpiar.Length; i++)
            {
                cajasLimpiar[i].Clear();
            }

            lblImcResultado.Text = "Esperando peso y talla...";
            lblImcResultado.ForeColor = Color.FromArgb(108, 117, 125);
        }

        private void txtTalla_TextChanged(object? sender, EventArgs e)
        {
            ActualizarCalculoImc();
        }

        private void txtPeso_TextChanged(object? sender, EventArgs e)
        {
            ActualizarCalculoImc();
        }

        private void ActualizarCalculoImc()
        {
            string tallaStr = txtTalla.Text.Trim().Replace(',', '.');
            string pesoStr = txtPeso.Text.Trim().Replace(',', '.');

            if (double.TryParse(tallaStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double talla) &&
                double.TryParse(pesoStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double peso) &&
                talla > 0 && peso > 0)
            {
                if (talla > 3.0)
                {
                    talla /= 100.0;
                }

                double imc = peso / (talla * talla);
                string clasificacion;
                Color colorTexto;

                if (imc < 18.5)
                {
                    clasificacion = "Bajo peso";
                    colorTexto = Color.FromArgb(255, 140, 0);
                }
                else if (imc < 25.0)
                {
                    clasificacion = "Normal";
                    colorTexto = Color.FromArgb(25, 135, 84);
                }
                else if (imc < 30.0)
                {
                    clasificacion = "Sobrepeso";
                    colorTexto = Color.FromArgb(255, 140, 0);
                }
                else
                {
                    clasificacion = "Obesidad";
                    colorTexto = Color.FromArgb(220, 53, 69);
                }

                lblImcResultado.Text = $"{imc:F2} - Estado: {clasificacion}";
                lblImcResultado.ForeColor = colorTexto;
            }
            else
            {
                lblImcResultado.Text = "Esperando peso y talla...";
                lblImcResultado.ForeColor = Color.FromArgb(108, 117, 125);
            }
        }

        private void botonLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarFormulario(mantenerDni: false);
            txtBuscar.Focus();
        }

        private void botonRegresar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void Topico_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_formularioLogin != null && !_formularioLogin.IsDisposed)
            {
                _formularioLogin.Show();
            }
        }
    }
}
