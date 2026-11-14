using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Centro_salud.Models;

namespace Centro_salud.Data
{
    public class PacienteRepository
    {
        private readonly string _filePath;

        public PacienteRepository()
        {
            // Apuntar directamente al archivo en la raíz del proyecto
            _filePath = ResolverRutaArchivo();

            // Crear el archivo si aún no existe
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, string.Empty);
            }
        }

        public string FilePath => _filePath;

        private static string ResolverRutaArchivo()
        {
            // 1. Si existe en la raíz del proyecto (3 niveles arriba desde bin/Debug/net10.0-windows)
            string rutaProyecto = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\pacientes.txt"));
            if (File.Exists(rutaProyecto))
            {
                return rutaProyecto;
            }

            // 2. Si el directorio de trabajo actual es la raíz del proyecto
            string rutaActual = Path.Combine(Directory.GetCurrentDirectory(), "pacientes.txt");
            if (File.Exists(rutaActual))
            {
                return rutaActual;
            }

            string rutaActualSub = Path.Combine(Directory.GetCurrentDirectory(), "Centro_salud", "pacientes.txt");
            if (File.Exists(rutaActualSub))
            {
                return rutaActualSub;
            }

            // 3. Si la carpeta del proyecto existe (identificada por Centro_salud.csproj), usar esa ruta
            string carpetaProyecto = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            if (Directory.Exists(carpetaProyecto) && File.Exists(Path.Combine(carpetaProyecto, "Centro_salud.csproj")))
            {
                return Path.Combine(carpetaProyecto, "pacientes.txt");
            }

            // 4. Directorio base de la aplicación como alternativa
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pacientes.txt");
        }

        public List<Paciente> ObtenerTodos()
        {
            var lista = new List<Paciente>();
            if (!File.Exists(_filePath))
                return lista;

            string[] lineas = File.ReadAllLines(_filePath);
            foreach (var linea in lineas)
            {
                var paciente = Paciente.FromTextLine(linea);
                if (paciente != null)
                {
                    lista.Add(paciente);
                }
            }

            return lista;
        }

        public Paciente? BuscarPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return null;

            var todos = ObtenerTodos();
            return todos.FirstOrDefault(p => p.Dni.Equals(dni.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public bool ExisteDni(string dni)
        {
            return BuscarPorDni(dni) != null;
        }

        public bool ValidarContraseñaPaciente(string contraseña, out Paciente? pacienteEncontrado)
        {
            pacienteEncontrado = null;
            if (string.IsNullOrWhiteSpace(contraseña))
                return false;

            var todos = ObtenerTodos();
            pacienteEncontrado = todos.FirstOrDefault(p => p.Contraseña.Equals(contraseña.Trim()));
            return pacienteEncontrado != null;
        }

        public void Registrar(Paciente nuevoPaciente)
        {
            var lista = ObtenerTodos();
            int index = lista.FindIndex(p => p.Dni.Equals(nuevoPaciente.Dni.Trim(), StringComparison.OrdinalIgnoreCase));

            if (index >= 0)
            {
                // Si ya existe por DNI, actualizamos sus datos preservando lo que no cambie
                var existente = lista[index];
                existente.Nombre = nuevoPaciente.Nombre;
                existente.Apellido = nuevoPaciente.Apellido;
                existente.Edad = nuevoPaciente.Edad;
                existente.Sis = nuevoPaciente.Sis;
                existente.Fecha = nuevoPaciente.Fecha;
                existente.Especialidad = nuevoPaciente.Especialidad;
                existente.Contraseña = nuevoPaciente.Contraseña;
                lista[index] = existente;
            }
            else
            {
                lista.Add(nuevoPaciente);
            }

            GuardarTodos(lista);
        }

        public bool ActualizarTopico(string dni, string temperatura, string talla, string peso, string presion)
        {
            var lista = ObtenerTodos();
            var paciente = lista.FirstOrDefault(p => p.Dni.Equals(dni.Trim(), StringComparison.OrdinalIgnoreCase));

            if (paciente == null)
                return false;

            paciente.Temperatura = temperatura.Trim();
            paciente.Talla = talla.Trim();
            paciente.Peso = peso.Trim();
            paciente.Presion = presion.Trim();

            GuardarTodos(lista);
            return true;
        }

        public bool ActualizarDoctor(string dni, string diagnostico, string receta)
        {
            var lista = ObtenerTodos();
            var paciente = lista.FirstOrDefault(p => p.Dni.Equals(dni.Trim(), StringComparison.OrdinalIgnoreCase));

            if (paciente == null)
                return false;

            paciente.Diagnostico = diagnostico.Trim();
            paciente.Receta = receta.Trim();

            GuardarTodos(lista);
            return true;
        }

        private void GuardarTodos(List<Paciente> pacientes)
        {
            var lineas = pacientes.Select(p => p.ToTextLine());
            File.WriteAllLines(_filePath, lineas);
        }
    }
}
