using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Centro_salud.Data;
using Centro_salud.Helpers;
using Centro_salud.Models;

namespace Centro_salud
{
    public partial class Doctor : Form
    {
        string archivo = @"..\..\..\pacientes.txt";
        private readonly Form? _formularioLogin;
        private readonly PacienteRepository _repo;
        private Centro_salud.Models.Paciente? _pacienteActual;

        // metodo constructor de la clase Doctor
        public Doctor(Form? formularioLogin = null)
        {
            InitializeComponent(); // hace la inerfas
            _formularioLogin = formularioLogin;
            _repo = new PacienteRepository();
            AsegurarRutaArchivo();
            ConfigurarDataGridView();
            consultarPacientes(); // luego busca para mostrar los pacientes en el archivo
        }

        private void AsegurarRutaArchivo()
        {
            if (!File.Exists(archivo))
            {
                archivo = _repo.FilePath;
            }
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

            dgvDatosPaciente.SelectionChanged += dgvDatosPaciente_SelectionChanged;
        }

        // procedimiento para consultar el archivo de pacientes
        private void consultarPacientes()
        {
            dgvDatosPaciente.Rows.Clear();

            if (File.Exists(archivo))
            {
                string[] lineas = File.ReadAllLines(archivo);
                for (int i = 0; i < lineas.Length; i++)
                {
                    string[] datos = lineas[i].Split('|');
                    if (datos.Length >= 8)
                    {
                        string temp = "Pendiente";
                        if (datos.Length > 8 && datos[8] != "")
                        {
                            temp = datos[8] + " °C";
                        }

                        string talla = "Pendiente";
                        if (datos.Length > 9 && datos[9] != "")
                        {
                            talla = datos[9] + " m";
                        }

                        string peso = "Pendiente";
                        if (datos.Length > 10 && datos[10] != "")
                        {
                            peso = datos[10] + " kg";
                        }

                        string presion = "Pendiente";
                        if (datos.Length > 11 && datos[11] != "")
                        {
                            presion = datos[11];
                        }

                        dgvDatosPaciente.Rows.Add(datos[0],
                                                  datos[1],
                                                  datos[2],
                                                  datos[3],
                                                  temp,
                                                  peso,
                                                  talla,
                                                  presion,
                                                  datos[6]);
                    }
                }
            }
            else
            {
                MessageBox.Show("El archivo de pacientes no existe.");
            }
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
                consultarPacientes();
                return;
            }

            CargarPacientePorDni(dni);
        }

        private void CargarPacientePorDni(string dni)
        {
            // Búsqueda del paciente utilizando arreglo y ciclo for clásico (sin foreach)
            Centro_salud.Models.Paciente[] listaPacientes = _repo.ObtenerTodos();
            _pacienteActual = null;

            for (int i = 0; i < listaPacientes.Length; i++)
            {
                if (listaPacientes[i].Dni == dni)
                {
                    _pacienteActual = listaPacientes[i];
                    break;
                }
            }

            if (_pacienteActual == null)
            {
                MessageBox.Show($"No se encontró ningún paciente registrado con el DNI: {dni}", "Paciente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiagnostico.Clear();
                txtReceta.Clear();
                return;
            }

            string temp = "Pendiente";
            if (!string.IsNullOrWhiteSpace(_pacienteActual.Temperatura))
            {
                temp = _pacienteActual.Temperatura + " °C";
            }

            string peso = "Pendiente";
            if (!string.IsNullOrWhiteSpace(_pacienteActual.Peso))
            {
                peso = _pacienteActual.Peso + " kg";
            }

            string talla = "Pendiente";
            if (!string.IsNullOrWhiteSpace(_pacienteActual.Talla))
            {
                talla = _pacienteActual.Talla + " m";
            }

            string presion = "Pendiente";
            if (!string.IsNullOrWhiteSpace(_pacienteActual.Presion))
            {
                presion = _pacienteActual.Presion;
            }

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

            // Mostrar el paciente buscado
            dgvDatosPaciente.Rows.Clear();
            dgvDatosPaciente.Rows.Add(filaDatos);

            // Cargar datos previos de atención si existen
            txtDiagnostico.Text = _pacienteActual.Diagnostico;
            txtReceta.Text = _pacienteActual.Receta;

            txtDiagnostico.Focus();
        }

        private void dgvDatosPaciente_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvDatosPaciente.CurrentRow != null && dgvDatosPaciente.CurrentRow.Cells["colDni"]?.Value != null)
            {
                string dni = dgvDatosPaciente.CurrentRow.Cells["colDni"]?.Value?.ToString() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(dni))
                {
                    txtBuscar_paciente.Text = dni;
                    _pacienteActual = _repo.BuscarPorDni(dni);
                    if (_pacienteActual != null)
                    {
                        txtDiagnostico.Text = _pacienteActual.Diagnostico;
                        txtReceta.Text = _pacienteActual.Receta;
                    }
                }
            }
        }

        private void botonGuardar_Click(object? sender, EventArgs e)
        {
            if (_pacienteActual == null)
            {
                MessageBox.Show("Primero debe buscar o seleccionar a un paciente por su DNI.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                consultarPacientes(); // actualiza la tabla con los datos del archivo
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el registro en el archivo de texto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtBuscar_paciente.Clear();
            txtDiagnostico.Clear();
            txtReceta.Clear();
            _pacienteActual = null;
            consultarPacientes();
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
