using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Centro_salud.Data;
using Centro_salud.Helpers;
using Centro_salud.Models;

namespace Centro_salud
{
    public partial class Paciente : Form
    {
        string archivo = @"..\..\..\pacientes.txt";
        private readonly Form? _formularioLogin;
        private readonly PacienteRepository _repo;

        // metodo constructor de la clase Paciente
        public Paciente(Form? formularioLogin = null, string? dniInicial = null)
        {
            InitializeComponent(); // hace la inerfas
            _formularioLogin = formularioLogin;
            _repo = new PacienteRepository();
            AsegurarRutaArchivo();
            ConfigurarDataGridView();
            consultarPacientes(); // luego busca para mostrar los pacientes en el archivo

            if (!string.IsNullOrWhiteSpace(dniInicial))
            {
                txtBuscar.Text = dniInicial;
                consultarPorDni(dniInicial);
            }
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
            dgvPaciente.Columns.Clear();
            dgvPaciente.Columns.Add("colDni", "DNI");
            dgvPaciente.Columns.Add("colNombre", "NOMBRE");
            dgvPaciente.Columns.Add("colApellido", "APELLIDO");
            dgvPaciente.Columns.Add("colEdad", "EDAD");
            dgvPaciente.Columns.Add("colSis", "SIS");
            dgvPaciente.Columns.Add("colEspecialidad", "ESPECIALIDAD");
            dgvPaciente.Columns.Add("colDiagnostico", "DIAGNÓSTICO");
            dgvPaciente.Columns.Add("colReceta", "RECETA");

            dgvPaciente.EnableHeadersVisualStyles = false;
            dgvPaciente.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13, 110, 253);
            dgvPaciente.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPaciente.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvPaciente.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvPaciente.RowTemplate.Height = 30;
        }

        // procedimiento para consultar el archivo de pacientes
        private void consultarPacientes()
        {
            dgvPaciente.Rows.Clear();

            if (File.Exists(archivo))
            {
                string[] lineas = File.ReadAllLines(archivo);
                for (int i = 0; i < lineas.Length; i++)
                {
                    string[] datos = lineas[i].Split('|');
                    if (datos.Length >= 8)
                    {
                        string diag = (datos.Length > 12 && !string.IsNullOrWhiteSpace(datos[12])) ? datos[12] : "Pendiente de atención";
                        string rec = (datos.Length > 13 && !string.IsNullOrWhiteSpace(datos[13])) ? datos[13] : "Pendiente de atención";

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

        // procedimiento para consultar un paciente específico por DNI en el archivo
        private void consultarPorDni(string dni)
        {
            dgvPaciente.Rows.Clear();

            if (File.Exists(archivo))
            {
                string[] lineas = File.ReadAllLines(archivo);
                bool encontrado = false;

                for (int i = 0; i < lineas.Length; i++)
                {
                    string[] datos = lineas[i].Split('|');
                    if (datos.Length >= 8 && datos[0].Equals(dni.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        string diag = (datos.Length > 12 && !string.IsNullOrWhiteSpace(datos[12])) ? datos[12] : "Pendiente de atención";
                        string rec = (datos.Length > 13 && !string.IsNullOrWhiteSpace(datos[13])) ? datos[13] : "Pendiente de atención";

                        dgvPaciente.Rows.Add(datos[0],
                                             datos[1],
                                             datos[2],
                                             datos[3],
                                             datos[4],
                                             datos[6],
                                             diag,
                                             rec);

                        txtDetalleDiagnostico.Text = diag;
                        txtDetalleReceta.Text = rec;
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    MessageBox.Show($"No se encontró ningún registro para el DNI {dni}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDetalleDiagnostico.Clear();
                    txtDetalleReceta.Clear();
                }
            }
            else
            {
                MessageBox.Show("El archivo de pacientes no existe.");
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirSoloNumeros(e);
        }

        private void botonBuscar_Click(object? sender, EventArgs e)
        {
            string dni = txtBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(dni))
            {
                consultarPacientes();
                return;
            }

            consultarPorDni(dni);
        }

        private void dgvPaciente_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvPaciente.CurrentRow != null)
            {
                txtDetalleDiagnostico.Text = dgvPaciente.CurrentRow.Cells["colDiagnostico"].Value?.ToString() ?? string.Empty;
                txtDetalleReceta.Text = dgvPaciente.CurrentRow.Cells["colReceta"].Value?.ToString() ?? string.Empty;
            }
        }

        private void botonRegresar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void botonSalir_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Paciente_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_formularioLogin != null && !_formularioLogin.IsDisposed)
            {
                _formularioLogin.Show();
            }
        }
    }
}
