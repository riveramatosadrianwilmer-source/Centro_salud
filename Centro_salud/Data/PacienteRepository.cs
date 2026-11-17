using System;
using System.IO;
using Centro_salud.Models;

namespace Centro_salud.Data
{
    using Paciente = Centro_salud.Models.Paciente;

    // Clase repositorio para administrar las operaciones de lectura, escritura y búsqueda en el archivo plano
    public class PacienteRepository
    {
        // Ruta absoluta del archivo de texto pacientes.txt
        private readonly string _filePath;

        // Constructor del repositorio: resuelve la ruta y asegura la existencia del archivo
        public PacienteRepository()
        {
            _filePath = ResolverRutaArchivo();

            // Si el archivo no existe, lo crea vacío
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, string.Empty);
            }
        }

        // Propiedad de solo lectura para consultar la ruta del archivo
        public string FilePath => _filePath;

        // Procedimiento auxiliar para encontrar la ruta correcta de pacientes.txt
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

            // 3. Si la carpeta del proyecto existe (identificada por Centro_salud.csproj)
            string carpetaProyecto = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            if (Directory.Exists(carpetaProyecto) && File.Exists(Path.Combine(carpetaProyecto, "Centro_salud.csproj")))
            {
                return Path.Combine(carpetaProyecto, "pacientes.txt");
            }

            // 4. Directorio base de la aplicación como alternativa
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pacientes.txt");
        }

        // Método que recupera todos los pacientes del archivo y los retorna en un arreglo de objetos Paciente[]
        public Paciente[] ObtenerTodos()
        {
            if (!File.Exists(_filePath))
            {
                return new Paciente[0];
            }

            // 1. Leer todas las líneas de texto del archivo en un arreglo de cadenas
            string[] lineas = File.ReadAllLines(_filePath);
            
            // 2. Primer bucle for clásico: contar cuántas líneas contienen datos válidos
            int contadorValidos = 0;
            for (int i = 0; i < lineas.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(lineas[i]))
                {
                    contadorValidos++;
                }
            }

            // 3. Crear el arreglo de objetos Paciente con el tamaño exacto necesario
            Paciente[] pacientes = new Paciente[contadorValidos];
            int posicion = 0;

            // 4. Segundo bucle for clásico: convertir cada línea de texto en un objeto Paciente
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

            // 5. Ajustar el arreglo si hubo registros con formato incorrecto
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

        // Método de búsqueda secuencial por DNI utilizando un bucle for clásico
        public Paciente? BuscarPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return null;

            Paciente[] todos = ObtenerTodos();

            // Bucle for clásico para comparar cada paciente
            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].Dni == dni.Trim())
                {
                    return todos[i]; // Retorna el paciente encontrado
                }
            }

            return null; // Si no se encontró, retorna null
        }

        // Método que verifica si un DNI ya existe registrado en el sistema
        public bool ExisteDni(string dni)
        {
            return BuscarPorDni(dni) != null;
        }

        // Método para validar la contraseña de un paciente durante el Login
        public bool ValidarContraseñaPaciente(string contraseña, out Paciente? pacienteEncontrado)
        {
            pacienteEncontrado = null;
            if (string.IsNullOrWhiteSpace(contraseña))
                return false;

            Paciente[] todos = ObtenerTodos();

            // Bucle for clásico para comprobar la contraseña
            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].Contraseña == contraseña.Trim())
                {
                    pacienteEncontrado = todos[i];
                    return true;
                }
            }

            return false;
        }

        // Método para registrar un nuevo paciente o actualizar sus datos personales
        public void Registrar(Paciente nuevoPaciente)
        {
            Paciente[] lista = ObtenerTodos();
            int index = -1;

            // Búsqueda con ciclo for clásico para ver si el DNI ya existe
            for (int i = 0; i < lista.Length; i++)
            {
                if (lista[i].Dni == nuevoPaciente.Dni.Trim())
                {
                    index = i;
                    break;
                }
            }

            // Si el DNI ya existe, actualizamos los datos de esa posición
            if (index >= 0)
            {
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
                // Si es un nuevo paciente, creamos un nuevo arreglo con tamaño (Length + 1)
                Paciente[] nuevaLista = new Paciente[lista.Length + 1];
                for (int i = 0; i < lista.Length; i++)
                {
                    nuevaLista[i] = lista[i];
                }
                nuevaLista[nuevaLista.Length - 1] = nuevoPaciente; // Insertamos al final
                GuardarTodos(nuevaLista);
            }
        }

        // Método para actualizar los datos de Tópico/Triaje (temperatura, talla, peso, presión)
        public bool ActualizarTopico(string dni, string temperatura, string talla, string peso, string presion)
        {
            Paciente[] lista = ObtenerTodos();
            int index = -1;

            // Bucle for clásico para localizar el paciente por su DNI
            for (int i = 0; i < lista.Length; i++)
            {
                if (lista[i].Dni == dni.Trim())
                {
                    index = i;
                    break;
                }
            }

            // Si no existe el paciente, no se puede actualizar
            if (index < 0)
                return false;

            // Actualizamos los valores de triaje
            lista[index].Temperatura = temperatura.Trim();
            lista[index].Talla = talla.Trim();
            lista[index].Peso = peso.Trim();
            lista[index].Presion = presion.Trim();

            // Guardamos todos los cambios en el archivo
            GuardarTodos(lista);
            return true;
        }

        // Método para actualizar los datos del Doctor (diagnóstico y receta médica)
        public bool ActualizarDoctor(string dni, string diagnostico, string receta)
        {
            Paciente[] lista = ObtenerTodos();
            int index = -1;

            // Bucle for clásico para localizar al paciente por su DNI
            for (int i = 0; i < lista.Length; i++)
            {
                if (lista[i].Dni == dni.Trim())
                {
                    index = i;
                    break;
                }
            }

            if (index < 0)
                return false;

            // Actualizamos el diagnóstico y la receta
            lista[index].Diagnostico = diagnostico.Trim();
            lista[index].Receta = receta.Trim();

            // Guardamos todos los cambios en el archivo
            GuardarTodos(lista);
            return true;
        }

        // Procedimiento privado para escribir todos los registros en el archivo de texto físico
        private void GuardarTodos(Paciente[] pacientes)
        {
            // Creamos un arreglo de cadenas de texto con la misma cantidad de elementos
            string[] lineas = new string[pacientes.Length];

            // Bucle for clásico para serializar cada objeto en una línea con formato delimitado (|)
            for (int i = 0; i < pacientes.Length; i++)
            {
                lineas[i] = pacientes[i].ToTextLine();
            }

            // Escribe todas las líneas en el archivo de texto en disco
            File.WriteAllLines(_filePath, lineas);
        }
    }
}
