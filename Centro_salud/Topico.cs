using System;
using System.Drawing;
using System.Windows.Forms;
using Centro_salud.Data;
using Centro_salud.Helpers;
using Centro_salud.Models;

namespace Centro_salud
{
    // Formulario de Tópico: registro de signos vitales (triaje) y cálculo automático del IMC
    public partial class Topico : Form
    {
        // Referencia al formulario de Login para volver al cerrar
        private readonly Form? _formularioLogin;

        // Repositorio para actualizar los signos vitales en el archivo de texto
        private readonly PacienteRepository _repo;

        // Paciente actualmente buscado y en proceso de triaje
        private Centro_salud.Models.Paciente? _pacienteActual;

        // Constructor del formulario de Tópico
        public Topico(Form? formularioLogin = null)
        {
            InitializeComponent(); // Inicializa los controles visuales de la interfaz
            _formularioLogin = formularioLogin;
            _repo = new PacienteRepository();
        }

        // Restricción: solo números en la caja de búsqueda de DNI
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirSoloNumeros(e);
        }

        // Restricción: números decimales para temperatura
        private void txtTemperatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirDecimales(e, txtTemperatura);
        }

        // Restricción: números decimales para talla
        private void txtTalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirDecimales(e, txtTalla);
        }

        // Restricción: números decimales para peso
        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirDecimales(e, txtPeso);
        }

        // Restricción: formato de presión con dígitos y barra inclinada (ejemplo: 120/80)
        private void txtPresion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.PermitirPresion(e, txtPresion);
        }

        // Evento del botón Buscar Paciente por DNI
        private void botonBuscar_Click(object? sender, EventArgs e)
        {
            string dni = txtBuscar.Text.Trim();

            // 1. Validar que se haya ingresado un DNI
            if (string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show("Por favor ingrese el número de DNI a buscar.",
                                "DNI requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscar.Focus();
                return;
            }

            // 2. Búsqueda secuencial en arreglo de pacientes con bucle for clásico (sin foreach)
            Centro_salud.Models.Paciente[] pacientes = _repo.ObtenerTodos();
            _pacienteActual = null;

            for (int i = 0; i < pacientes.Length; i++)
            {
                if (pacientes[i].Dni == dni)
                {
                    _pacienteActual = pacientes[i];
                    break; // Paciente encontrado, finalizamos la búsqueda
                }
            }

            // 3. Si no existe el paciente
            if (_pacienteActual == null)
            {
                MessageBox.Show($"No se encontró ningún paciente registrado con el DNI: {dni}",
                                "Paciente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario(mantenerDni: true);
                return;
            }

            // 4. Mostrar los datos del paciente en los controles
            txtNombre.Text = $"{_pacienteActual.Nombre} {_pacienteActual.Apellido}";
            txtespecialidad.Text = _pacienteActual.Especialidad;
            txtTemperatura.Text = _pacienteActual.Temperatura;
            txtTalla.Text = _pacienteActual.Talla;
            txtPeso.Text = _pacienteActual.Peso;
            txtPresion.Text = _pacienteActual.Presion;

            // Calcular y mostrar el estado del IMC si ya tiene peso y talla
            ActualizarCalculoImc();

            txtTemperatura.Focus();
        }

        // Evento del botón Guardar Triaje
        private void botonGuardar_Click(object? sender, EventArgs e)
        {
            // 1. Validar que primero se haya buscado a un paciente
            if (_pacienteActual == null)
            {
                MessageBox.Show("Primero debe buscar y seleccionar un paciente registrado.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscar.Focus();
                return;
            }

            // 2. Arreglos paralelos de TextBox y nombres para validar campos vacíos con bucle for
            TextBox[] cajasSignos = { txtTemperatura, txtTalla, txtPeso, txtPresion };
            string[] nombresSignos = { "Temperatura", "Talla", "Peso", "Presión" };

            // Bucle for clásico para validar que no haya signos vitales vacíos
            for (int i = 0; i < cajasSignos.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(cajasSignos[i].Text.Trim()))
                {
                    MessageBox.Show($"Por favor complete el campo de {nombresSignos[i]}.",
                                    "Dato incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cajasSignos[i].Focus();
                    return;
                }
            }

            string temp = txtTemperatura.Text.Trim();
            string talla = txtTalla.Text.Trim();
            string peso = txtPeso.Text.Trim();
            string presion = txtPresion.Text.Trim();

            // 3. Actualizar la información en el archivo de texto
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

                LimpiarFormulario(mantenerDni: false); // Limpia los controles tras guardar
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la información en el archivo de texto.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Procedimiento para limpiar los controles utilizando un arreglo y bucle for clásico
        private void LimpiarFormulario(bool mantenerDni)
        {
            if (!mantenerDni)
            {
                txtBuscar.Clear();
                _pacienteActual = null;
            }

            // Arreglo de cajas de texto para limpieza masiva
            TextBox[] cajasLimpiar = { txtNombre, txtespecialidad, txtTemperatura, txtTalla, txtPeso, txtPresion };
            for (int i = 0; i < cajasLimpiar.Length; i++)
            {
                cajasLimpiar[i].Clear();
            }

            lblImcResultado.Text = "Esperando peso y talla...";
            lblImcResultado.ForeColor = Color.FromArgb(108, 117, 125);
        }

        // Evento cuando cambia el texto de la talla para recalcular el IMC en tiempo real
        private void txtTalla_TextChanged(object? sender, EventArgs e)
        {
            ActualizarCalculoImc();
        }

        // Evento cuando cambia el texto del peso para recalcular el IMC en tiempo real
        private void txtPeso_TextChanged(object? sender, EventArgs e)
        {
            ActualizarCalculoImc();
        }

        // Procedimiento para calcular el Índice de Masa Corporal (IMC) y determinar el estado
        private void ActualizarCalculoImc()
        {
            string tallaStr = txtTalla.Text.Trim().Replace(',', '.');
            string pesoStr = txtPeso.Text.Trim().Replace(',', '.');

            // Intenta convertir texto a valores numéricos decimales
            if (double.TryParse(tallaStr, out double talla) &&
                double.TryParse(pesoStr, out double peso) &&
                talla > 0 && peso > 0)
            {
                // Si el usuario ingresó la talla en centímetros (ejemplo: 165 en vez de 1.65), la convertimos a metros
                if (talla > 3.0)
                {
                    talla /= 100.0;
                }

                // Fórmula matemática del IMC: peso / (talla * talla)
                double imc = peso / (talla * talla);
                string clasificacion;
                Color colorTexto;

                // Estructura condicional if - else if para clasificar el resultado
                if (imc < 18.5)
                {
                    clasificacion = "Bajo peso";
                    colorTexto = Color.FromArgb(255, 140, 0); // Naranja
                }
                else if (imc < 25.0)
                {
                    clasificacion = "Normal";
                    colorTexto = Color.FromArgb(25, 135, 84); // Verde
                }
                else if (imc < 30.0)
                {
                    clasificacion = "Sobrepeso";
                    colorTexto = Color.FromArgb(255, 140, 0); // Naranja
                }
                else
                {
                    clasificacion = "Obesidad";
                    colorTexto = Color.FromArgb(220, 53, 69); // Rojo
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

        // Evento del botón Limpiar
        private void botonLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarFormulario(mantenerDni: false);
            txtBuscar.Focus();
        }

        // Evento del botón Regresar para volver al Login
        private void botonRegresar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        // Evento al cerrar la ventana para reabrir el Login
        private void Topico_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_formularioLogin != null && !_formularioLogin.IsDisposed)
            {
                _formularioLogin.Show();
            }
        }
    }
}
