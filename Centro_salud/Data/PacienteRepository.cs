using System;
using System.IO;
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

        // Retorna un arreglo de pacientes usando bucle for clásico y arreglos de cadenas
        public Paciente[] ObtenerTodos()
        {
            if (!File.Exists(_filePath))
            {
                return new Paciente[0];
            }

            // Arreglo de cadenas de caracteres leídas del archivo
            string[] lineas = File.ReadAllLines(_filePath);
            
            // Primer bucle for clásico: contar registros válidos
            int contadorValidos = 0;
            for (int i = 0; i < lineas.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(lineas[i]))
                {
                    contadorValidos++;
                }
            }

            // Arreglo de pacientes con tamaño exacto
            Paciente[] pacientes = new Paciente[contadorValidos];
            int posicion = 0;

            // Segundo bucle for clásico: convertir cada línea en objeto Paciente
            for (int i = 0; i < lineas.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(lineas[i]))
                {
                    Paciente? p = Paciente.FromTextLine(lineas[i]);
                    if (p != null)
                    {
                        pacientes[posicion] = p;
                        posicion++;
                    }
                }
            }

            // Si hubo líneas inválidas, ajustar el tamaño del arreglo
            if (posicion < pacientes.Length)
            {
                Paciente[] arregloAjustado = new Paciente[posicion];
                for (int i = 0; i < posicion; i++)
                {
                    arregloAjustado[i] = pacientes[i];
                }
                return arregloAjustado;
            }

            return pacientes;
        }

        // Búsqueda secuencial con bucle for clásico en el arreglo de pacientes
        public Paciente? BuscarPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return null;

            Paciente[] todos = ObtenerTodos();

            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].Dni.Equals(dni.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return todos[i];
                }
            }

            return null;
        }

        public bool ExisteDni(string dni)
        {
            return BuscarPorDni(dni) != null;
        }

        // Validación con bucle for clásico en el arreglo de pacientes
        public bool ValidarContraseñaPaciente(string contraseña, out Paciente? pacienteEncontrado)
        {
            pacienteEncontrado = null;
            if (string.IsNullOrWhiteSpace(contraseña))
                return false;

            Paciente[] todos = ObtenerTodos();

            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].Contraseña.Equals(contraseña.Trim()))
                {
                    pacienteEncontrado = todos[i];
                    return true;
                }
            }

            return false;
        }

        public void Registrar(Paciente nuevoPaciente)
        {
            Paciente[] lista = ObtenerTodos();
            int index = -1;

            // Búsqueda con ciclo for clásico
            for (int i = 0; i < lista.Length; i++)
            {
                if (lista[i].Dni.Equals(nuevoPaciente.Dni.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                // Si ya existe por DNI, actualizamos sus datos en el arreglo
                lista[index].Nombre = nuevoPaciente.Nombre;
                lista[index].Apellido = nuevoPaciente.Apellido;
                lista[index].Edad = nuevoPaciente.Edad;
                lista[index].Sis = nuevoPaciente.Sis;
                lista[index].Fecha = nuevoPaciente.Fecha;
                lista[index].Especialidad = nuevoPaciente.Especialidad;
                lista[index].Contraseña = nuevoPaciente.Contraseña;
                GuardarTodos(lista);
            }
            else
            {
                // Nuevo arreglo de pacientes con tamaño + 1
                Paciente[] nuevaLista = new Paciente[lista.Length + 1];
                for (int i = 0; i < lista.Length; i++)
                {
                    nuevaLista[i] = lista[i];
                }
                nuevaLista[nuevaLista.Length - 1] = nuevoPaciente;
                GuardarTodos(nuevaLista);
            }
        }

        public bool ActualizarTopico(string dni, string temperatura, string talla, string peso, string presion)
        {
            Paciente[] lista = ObtenerTodos();
            int index = -1;

            // Bucle for clásico para localizar el paciente
            for (int i = 0; i < lista.Length; i++)
            {
                if (lista[i].Dni.Equals(dni.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            if (index < 0)
                return false;

            lista[index].Temperatura = temperatura.Trim();
            lista[index].Talla = talla.Trim();
            lista[index].Peso = peso.Trim();
            lista[index].Presion = presion.Trim();

            GuardarTodos(lista);
            return true;
        }

        public bool ActualizarDoctor(string dni, string diagnostico, string receta)
        {
            Paciente[] lista = ObtenerTodos();
            int index = -1;

            // Bucle for clásico para localizar el paciente
            for (int i = 0; i < lista.Length; i++)
            {
                if (lista[i].Dni.Equals(dni.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            if (index < 0)
                return false;

            lista[index].Diagnostico = diagnostico.Trim();
            lista[index].Receta = receta.Trim();

            GuardarTodos(lista);
            return true;
        }

        // Guarda usando un arreglo de cadenas de caracteres y un bucle for clásico
        private void GuardarTodos(Paciente[] pacientes)
        {
            string[] lineas = new string[pacientes.Length];

            for (int i = 0; i < pacientes.Length; i++)
            {
                lineas[i] = pacientes[i].ToTextLine();
            }

            File.WriteAllLines(_filePath, lineas);
        }
    }
}
