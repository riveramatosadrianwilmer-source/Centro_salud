using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Centro_salud.Data;
using Centro_salud.Helpers;
using Centro_salud.Models;

namespace Centro_salud
{
    // Formulario para el módulo del Doctor: atención médica, diagnóstico y recetas
    public partial class Doctor : Form
    {
        // Ruta relativa al archivo plano de pacientes
        string archivo = @"..\..\..\pacientes.txt";

        // Referencia al formulario de Login para poder regresar
        private readonly Form? _formularioLogin;

        // Repositorio para gestionar la lectura y actualización de los pacientes
        private readonly PacienteRepository _repo;

        // Almacena el paciente actualmente seleccionado para atender
        private Centro_salud.Models.Paciente? _pacienteActual;

        // Método constructor de la clase Doctor
        public Doctor(Form? formularioLogin = null)
        {
            InitializeComponent(); // Inicializa los controles visuales de la interfaz
            _formularioLogin = formularioLogin;
            _repo = new PacienteRepository();
            AsegurarRutaArchivo(); // Verifica y asegura la ruta correcta del archivo TXT
            ConfigurarDataGridView(); // Configura las columnas y estilos de la tabla
            consultarPacientes(); // Carga y muestra todos los pacientes del archivo en la tabla
            dgvDatosPaciente.ClearSelection(); // Desmarca cualquier fila seleccionada al inicio
        }

        // Procedimiento para asegurar la ubicación correcta del archivo de texto
        private void AsegurarRutaArchivo()
        {
            if (!File.Exists(archivo))
            {
                archivo = _repo.FilePath;
            }
        }

        // Procedimiento para definir las columnas y apariencia visual del DataGridView
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

            // Configuración de encabezados y filas
            dgvDatosPaciente.EnableHeadersVisualStyles = false;
            dgvDatosPaciente.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13, 110, 253);
            dgvDatosPaciente.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDatosPaciente.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvDatosPaciente.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvDatosPaciente.RowTemplate.Height = 30;

            // Evento para cargar el paciente al hacer clic en una celda o fila
            dgvDatosPaciente.CellClick += dgvDatosPaciente_CellClick;
        }

        // Procedimiento para consultar el archivo de pacientes y llenar el DataGridView
        private void consultarPacientes()
        {
            // 1. Limpiar filas existentes en la tabla
            dgvDatosPaciente.Rows.Clear();

            // 2. Verificar si el archivo físico existe
            if (File.Exists(archivo))
            {
                // Leer todas las líneas del archivo de texto
                string[] lineas = File.ReadAllLines(archivo);

                // Bucle for clásico para recorrer cada registro
                for (int i = 0; i < lineas.Length; i++)
                {
                    // Separar los campos por el delimitador pipe (|)
                    string[] datos = lineas[i].Split('|');

                    // Validar que la línea contenga los datos básicos requeridos
                    if (datos.Length >= 8)
                    {
                        // Formatear los datos de triaje si están disponibles
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

                        // Agregar la fila con los datos extraídos al DataGridView
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

        // Evento KeyPress para permitir únicamente números en la caja de búsqueda de DNI
        private void txtBuscar_paciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirSoloNumeros(e);
        }

        // Evento del botón Buscar Paciente
        private void botonBuscar_Click(object? sender, EventArgs e)
        {
            string dni = txtBuscar_paciente.Text.Trim();

            // Si la caja está vacía, recarga la lista completa de pacientes
            if (string.IsNullOrWhiteSpace(dni))
            {
                consultarPacientes();
                return;
            }

            // Si se ingresó un DNI, busca y muestra a ese paciente en específico
            CargarPacientePorDni(dni);
        }

        // Procedimiento para buscar a un paciente por su DNI y cargar sus datos
        private void CargarPacientePorDni(string dni)
        {
            // Búsqueda del paciente utilizando arreglo y ciclo for clásico (sin foreach)
            Centro_salud.Models.Paciente[] listaPacientes = _repo.ObtenerTodos();
            _pacienteActual = null;

            // Bucle for clásico para localizar el DNI correspondiente
            for (int i = 0; i < listaPacientes.Length; i++)
            {
                if (listaPacientes[i].Dni == dni)
                {
                    _pacienteActual = listaPacientes[i];
                    break; // Paciente encontrado, terminamos la búsqueda
                }
            }

            // Si no se encontró ningún paciente con ese DNI
            if (_pacienteActual == null)
            {
                MessageBox.Show($"No se encontró ningún paciente registrado con el DNI: {dni}",
                                "Paciente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiagnostico.Clear();
                txtReceta.Clear();
                return;
            }

            // Validar textos de signos vitales para la visualización
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

            // Mostrar el paciente buscado en el DataGridView
            dgvDatosPaciente.Rows.Clear();
            dgvDatosPaciente.Rows.Add(filaDatos);

            // Cargar datos previos de diagnóstico y receta si existen
            txtDiagnostico.Text = _pacienteActual.Diagnostico;
            txtReceta.Text = _pacienteActual.Receta;

            txtDiagnostico.Focus(); // Pone el foco en la caja de diagnóstico
        }

        // Evento que se ejecuta al hacer clic sobre una fila del DataGridView
        private void dgvDatosPaciente_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Validar que se haya hecho clic sobre una fila válida (índice >= 0)
            if (e.RowIndex >= 0 && dgvDatosPaciente.Rows[e.RowIndex].Cells["colDni"]?.Value != null)
            {
                string dni = dgvDatosPaciente.Rows[e.RowIndex].Cells["colDni"]?.Value?.ToString() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(dni))
                {
                    txtBuscar_paciente.Text = dni;
                    CargarPacientePorDni(dni); // Carga la información médica del paciente seleccionado
                }
            }
        }

        // Evento del botón Guardar Consulta (Diagnóstico y Receta Médica)
        private void botonGuardar_Click(object? sender, EventArgs e)
        {
            // 1. Validar que se haya seleccionado un paciente
            if (_pacienteActual == null)
            {
                MessageBox.Show("Primero debe buscar o seleccionar a un paciente por su DNI.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscar_paciente.Focus();
                return;
            }

            string diag = txtDiagnostico.Text.Trim();
            string rec = txtReceta.Text.Trim();

            // 2. Validar que no haya campos vacíos
            if (string.IsNullOrWhiteSpace(diag) || string.IsNullOrWhiteSpace(rec))
            {
                MessageBox.Show("Por favor ingrese tanto el Diagnóstico como la Receta médica.",
                                "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Actualizar el registro en el archivo de texto
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
                consultarPacientes(); // Actualiza la tabla con los nuevos datos guardados
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el registro en el archivo de texto.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Procedimiento para limpiar los controles y restablecer la vista
        private void LimpiarFormulario()
        {
            txtBuscar_paciente.Clear();
            txtDiagnostico.Clear();
            txtReceta.Clear();
            _pacienteActual = null;
            consultarPacientes(); // Recarga la lista completa de pacientes en la tabla
            dgvDatosPaciente.ClearSelection(); // Desmarca la selección
            txtBuscar_paciente.Focus(); // Coloca el cursor en la caja de búsqueda
        }

        // Evento del botón Limpiar Campos
        private void botonLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        // Evento del botón Regresar para cerrar la ventana y volver al Login
        private void botonRegresar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        // Evento de cierre de ventana para reabrir el formulario de Login
        private void Doctor_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_formularioLogin != null && !_formularioLogin.IsDisposed)
            {
                _formularioLogin.Show();
            }
        }
    }
}
