using System;
using System.Windows.Forms;
using Centro_salud.Data;
using Centro_salud.Helpers;
using Centro_salud.Models;
namespace Centro_salud
{
    public partial class Doctor : Form
    {
        private readonly Form? _formularioLogin;
        private readonly PacienteRepository _repo;
        private Centro_salud.Models.Paciente? _pacienteActual;

        public Doctor(Form? formularioLogin = null)
        {
            InitializeComponent();
            _formularioLogin = formularioLogin;
            _repo = new PacienteRepository();
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dgvDatosPaciente.Columns.Clear();
            dgvDatosPaciente.Columns.Add("colDni", "DNI");
            dgvDatosPaciente.Columns.Add("colNombre", "NOMBRE");
            dgvDatosPaciente.Columns.Add("colApellido", "APELLIDO");
            dgvDatosPaciente.Columns.Add("colEdad", "EDAD");
            dgvDatosPaciente.Columns.Add("colTemperatura", "TEMPERATURA");
            dgvDatosPaciente.Columns.Add("colPeso", "PESO");
            dgvDatosPaciente.Columns.Add("colTalla", "TALLA");
            dgvDatosPaciente.Columns.Add("colPresion", "PRESIÓN");
            dgvDatosPaciente.Columns.Add("colEspecialidad", "ESPECIALIDAD");

            // Configuración visual amigable
            dgvDatosPaciente.EnableHeadersVisualStyles = false;
            dgvDatosPaciente.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13, 110, 253);
            dgvDatosPaciente.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDatosPaciente.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvDatosPaciente.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvDatosPaciente.RowTemplate.Height = 30;
        }

        private void txtBuscar_paciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirSoloNumeros(e);
        }

        private void botonBuscar_Click(object? sender, EventArgs e)
        {
            string dni = txtBuscar_paciente.Text.Trim();

            if (string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show("Por favor ingrese el número de DNI del paciente.", "DNI requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscar_paciente.Focus();
                return;
            }

            // Búsqueda del paciente utilizando arreglo y ciclo for clásico (sin foreach)
            Centro_salud.Models.Paciente[] listaPacientes = _repo.ObtenerTodos();
            _pacienteActual = null;

            for (int i = 0; i < listaPacientes.Length; i++)
            {
                if (listaPacientes[i].Dni.Equals(dni, StringComparison.OrdinalIgnoreCase))
                {
                    _pacienteActual = listaPacientes[i];
                    break;
                }
            }

            if (_pacienteActual == null)
            {
                MessageBox.Show($"No se encontró ningún paciente registrado con el DNI: {dni}", "Paciente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDatosPaciente.Rows.Clear();
                txtDiagnostico.Clear();
                txtReceta.Clear();
                return;
            }

            string temp = string.IsNullOrWhiteSpace(_pacienteActual.Temperatura) ? "Pendiente" : $"{_pacienteActual.Temperatura} °C";
            string peso = string.IsNullOrWhiteSpace(_pacienteActual.Peso) ? "Pendiente" : $"{_pacienteActual.Peso} kg";
            string talla = string.IsNullOrWhiteSpace(_pacienteActual.Talla) ? "Pendiente" : $"{_pacienteActual.Talla} m";
            string presion = string.IsNullOrWhiteSpace(_pacienteActual.Presion) ? "Pendiente" : _pacienteActual.Presion;

            // Arreglo de cadenas de caracteres para representar la fila del paciente en el DataGridView
            string[] filaDatos = new string[]
            {
                _pacienteActual.Dni,
                _pacienteActual.Nombre,
                _pacienteActual.Apellido,
                _pacienteActual.Edad.ToString(),
                temp,
                peso,
                talla,
                presion,
                _pacienteActual.Especialidad
            };

            // Mostrar la información en el DataGridView
            dgvDatosPaciente.Rows.Clear();
            dgvDatosPaciente.Rows.Add(filaDatos);

            // Cargar datos previos de atención si existen
            txtDiagnostico.Text = _pacienteActual.Diagnostico;
            txtReceta.Text = _pacienteActual.Receta;

            txtDiagnostico.Focus();
        }

        private void botonGuardar_Click(object? sender, EventArgs e)
        {
            if (_pacienteActual == null)
            {
                MessageBox.Show("Primero debe buscar a un paciente por su DNI.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscar_paciente.Focus();
                return;
            }

            string diag = txtDiagnostico.Text.Trim();
            string rec = txtReceta.Text.Trim();

            if (string.IsNullOrWhiteSpace(diag) || string.IsNullOrWhiteSpace(rec))
            {
                MessageBox.Show("Por favor ingrese tanto el Diagnóstico como la Receta médica.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool exito = _repo.ActualizarDoctor(_pacienteActual.Dni, diag, rec);

            if (exito)
            {
                MessageBox.Show(
                    $"Consulta médica registrada y guardada exitosamente en el archivo de texto para el paciente {_pacienteActual.Nombre} {_pacienteActual.Apellido} (DNI: {_pacienteActual.Dni}).",
                    "Consulta Guardada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                _pacienteActual.Diagnostico = diag;
                _pacienteActual.Receta = rec;
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el registro en el archivo de texto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtBuscar_paciente.Clear();
            dgvDatosPaciente.Rows.Clear();
            txtDiagnostico.Clear();
            txtReceta.Clear();
            _pacienteActual = null;
            txtBuscar_paciente.Focus();
        }

        private void botonLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void botonRegresar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void Doctor_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_formularioLogin != null && !_formularioLogin.IsDisposed)
            {
                _formularioLogin.Show();
            }
        }
    }
}
