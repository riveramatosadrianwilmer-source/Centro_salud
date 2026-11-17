using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Centro_salud.Data;
using Centro_salud.Helpers;
using Centro_salud.Models;

namespace Centro_salud
{
    // Formulario de consulta del Paciente: permite ver el historial de citas, diagnóstico y receta
    public partial class Paciente : Form
    {
        // Ruta relativa al archivo de texto plano donde residen los datos
        string archivo = @"..\..\..\pacientes.txt";

        // Referencia al formulario de Login para retornar al cerrar
        private readonly Form? _formularioLogin;

        // Repositorio de acceso a datos de los pacientes
        private readonly PacienteRepository _repo;

        // Método constructor de la clase Paciente
        public Paciente(Form? formularioLogin = null, string? dniInicial = null)
        {
            InitializeComponent(); // Inicializa los controles visuales de la interfaz
            _formularioLogin = formularioLogin;
            _repo = new PacienteRepository();
            AsegurarRutaArchivo(); // Confirma la ruta del archivo de texto
            ConfigurarDataGridView(); // Configura las columnas del DataGridView
            consultarPacientes(); // Carga inicialmente los registros en la tabla

            // Si el paciente ingresó desde el Login, buscamos automáticamente su DNI
            if (!string.IsNullOrWhiteSpace(dniInicial))
            {
                txtBuscar.Text = dniInicial;
                consultarPorDni(dniInicial);
            }
        }

        // Procedimiento para asegurar la ubicación correcta del archivo de texto
        private void AsegurarRutaArchivo()
        {
            if (!File.Exists(archivo))
            {
                archivo = _repo.FilePath;
            }
        }

        // Procedimiento para configurar las columnas y el estilo visual del DataGridView
        private void ConfigurarDataGridView()
        {
            dgvPaciente.Columns.Clear();
            dgvPaciente.Columns.Add("colDni", "DNI");
            dgvPaciente.Columns.Add("colNombre", "NOMBRE");
            dgvPaciente.Columns.Add("colApellido", "APELLIDO");
            dgvPaciente.Columns.Add("colEdad", "EDAD");
            dgvPaciente.Columns.Add("colSis", "SIS");
            dgvPaciente.Columns.Add("colEspecialidad", "ESPECIALIDAD");
            dgvPaciente.Columns.Add("colDiagnostico", "DIAGNÓSTICO");
            dgvPaciente.Columns.Add("colReceta", "RECETA");

            // Estilos visuales de encabezados y filas
            dgvPaciente.EnableHeadersVisualStyles = false;
            dgvPaciente.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13, 110, 253);
            dgvPaciente.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPaciente.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvPaciente.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvPaciente.RowTemplate.Height = 30;
        }

        // Procedimiento para consultar el archivo de pacientes y mostrar los registros en la tabla
        private void consultarPacientes()
        {
            // 1. Limpiar filas existentes en la tabla
            dgvPaciente.Rows.Clear();

            // 2. Verificar la existencia del archivo físico
            if (File.Exists(archivo))
            {
                // Leer todas las líneas de texto del archivo plano
                string[] lineas = File.ReadAllLines(archivo);

                // Bucle for clásico para procesar cada línea
                for (int i = 0; i < lineas.Length; i++)
                {
                    // Separar los campos por el delimitador pipe (|)
                    string[] datos = lineas[i].Split('|');

                    // Validar que la línea tenga al menos 8 campos requeridos
                    if (datos.Length >= 8)
                    {
                        // Obtener diagnóstico y receta o mensaje por defecto
                        string diag = "Pendiente de atención";
                        if (datos.Length > 12 && datos[12] != "")
                        {
                            diag = datos[12];
                        }

                        string rec = "Pendiente de atención";
                        if (datos.Length > 13 && datos[13] != "")
                        {
                            rec = datos[13];
                        }

                        // Agregar los datos del paciente al DataGridView
                        dgvPaciente.Rows.Add(datos[0],
                                             datos[1],
                                             datos[2],
                                             datos[3],
                                             datos[4],
                                             datos[6],
                                             diag,
                                             rec);
                    }
                }
            }
            else
            {
                MessageBox.Show("El archivo de pacientes no existe.");
            }
        }

        // Procedimiento para consultar un paciente específico por DNI en el archivo
        private void consultarPorDni(string dni)
        {
            dgvPaciente.Rows.Clear();

            if (File.Exists(archivo))
            {
                string[] lineas = File.ReadAllLines(archivo);
                bool encontrado = false;

                // Bucle for clásico para recorrer el archivo buscando el DNI
                for (int i = 0; i < lineas.Length; i++)
                {
                    string[] datos = lineas[i].Split('|');

                    // Comparar si el DNI del archivo coincide con el DNI buscado
                    if (datos.Length >= 8 && datos[0] == dni.Trim())
                    {
                        string diag = "Pendiente de atención";
                        if (datos.Length > 12 && datos[12] != "")
                        {
                            diag = datos[12];
                        }

                        string rec = "Pendiente de atención";
                        if (datos.Length > 13 && datos[13] != "")
                        {
                            rec = datos[13];
                        }

                        // Agregar la fila encontrada al DataGridView
                        dgvPaciente.Rows.Add(datos[0],
                                             datos[1],
                                             datos[2],
                                             datos[3],
                                             datos[4],
                                             datos[6],
                                             diag,
                                             rec);

                        // Mostrar el diagnóstico y receta en los cuadros de texto inferiores
                        txtDetalleDiagnostico.Text = diag;
                        txtDetalleReceta.Text = rec;
                        encontrado = true;
                        break; // Se encontró al paciente, finaliza el ciclo
                    }
                }

                // Si no se encontró ningún registro con ese DNI
                if (!encontrado)
                {
                    MessageBox.Show($"No se encontró ningún registro para el DNI {dni}.",
                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDetalleDiagnostico.Clear();
                    txtDetalleReceta.Clear();
                }
            }
            else
            {
                MessageBox.Show("El archivo de pacientes no existe.");
            }
        }

        // Evento KeyPress para restringir la entrada a solo números en la búsqueda de DNI
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirSoloNumeros(e);
        }

        // Evento del botón Buscar
        private void botonBuscar_Click(object? sender, EventArgs e)
        {
            string dni = txtBuscar.Text.Trim();

            // Si el campo está vacío, recarga todos los pacientes en la tabla
            if (string.IsNullOrWhiteSpace(dni))
            {
                consultarPacientes();
                return;
            }

            // Si tiene DNI, ejecuta la búsqueda específica
            consultarPorDni(dni);
        }

        // Evento que actualiza los cuadros de texto detallados al cambiar de fila en la tabla
        private void dgvPaciente_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvPaciente.CurrentRow != null)
            {
                txtDetalleDiagnostico.Text = dgvPaciente.CurrentRow.Cells["colDiagnostico"].Value?.ToString() ?? string.Empty;
                txtDetalleReceta.Text = dgvPaciente.CurrentRow.Cells["colReceta"].Value?.ToString() ?? string.Empty;
            }
        }

        // Evento del botón Regresar para volver al Login
        private void botonRegresar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        // Evento del botón Salir para cerrar completamente la aplicación
        private void botonSalir_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        // Evento de cierre de ventana para volver a mostrar el Login
        private void Paciente_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_formularioLogin != null && !_formularioLogin.IsDisposed)
            {
                _formularioLogin.Show();
            }
        }
    }
}
