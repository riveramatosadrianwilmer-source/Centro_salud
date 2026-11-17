using System;
using System.Windows.Forms;
using Centro_salud.Data;
using Centro_salud.Helpers;
using Centro_salud.Models;

namespace Centro_salud
{
    public partial class FormPaciente : Form
    {
        private readonly Form? _formularioLogin;
        private readonly PacienteRepository _repo;

        public FormPaciente(Form? formularioLogin = null, string? dniInicial = null)
        {
            InitializeComponent();
            _formularioLogin = formularioLogin;
            _repo = new PacienteRepository();
            ConfigurarDataGridView();

            if (!string.IsNullOrWhiteSpace(dniInicial))
            {
                txtBuscar.Text = dniInicial;
                RealizarBusqueda(dniInicial);
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

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirSoloNumeros(e);
        }

        private void botonBuscar_Click(object? sender, EventArgs e)
        {
            string dni = txtBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show("Por favor ingrese su número de DNI para consultar su información.", "DNI requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscar.Focus();
                return;
            }

            RealizarBusqueda(dni);
        }

        private void RealizarBusqueda(string dni)
        {
            // Búsqueda del paciente utilizando arreglo y ciclo for clásico (sin foreach)
            Paciente[] listaPacientes = _repo.ObtenerTodos();
            Paciente? paciente = null;

            for (int i = 0; i < listaPacientes.Length; i++)
            {
                if (listaPacientes[i].Dni.Equals(dni, StringComparison.OrdinalIgnoreCase))
                {
                    paciente = listaPacientes[i];
                    break;
                }
            }

            if (paciente == null)
            {
                MessageBox.Show($"No se encontró ningún registro para el DNI {dni}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPaciente.Rows.Clear();
                txtDetalleDiagnostico.Clear();
                txtDetalleReceta.Clear();
                return;
            }

            string diag = string.IsNullOrWhiteSpace(paciente.Diagnostico) ? "Pendiente de atención" : paciente.Diagnostico;
            string rec = string.IsNullOrWhiteSpace(paciente.Receta) ? "Pendiente de atención" : paciente.Receta;

            // Arreglo de cadenas de caracteres para llenar la fila del DataGridView
            string[] filaPaciente = new string[]
            {
                paciente.Dni,
                paciente.Nombre,
                paciente.Apellido,
                paciente.Edad.ToString(),
                paciente.Sis,
                paciente.Especialidad,
                diag,
                rec
            };

            dgvPaciente.Rows.Clear();
            dgvPaciente.Rows.Add(filaPaciente);

            txtDetalleDiagnostico.Text = diag;
            txtDetalleReceta.Text = rec;
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

        private void FormPaciente_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_formularioLogin != null && !_formularioLogin.IsDisposed)
            {
                _formularioLogin.Show();
            }
        }
    }
}
