namespace Centro_salud.Models
{
    // Clase modelo que representa la entidad Paciente (expediente médico completo)
    public class Paciente
    {
        // 1. Datos personales y cita (registrados en Registrar Cita)
        public string Dni { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string Sis { get; set; } = "No"; // "Si" o "No"
        public string Fecha { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;

        // 2. Signos vitales de triaje (registrados en Tópico)
        public string Temperatura { get; set; } = string.Empty;
        public string Talla { get; set; } = string.Empty;
        public string Peso { get; set; } = string.Empty;
        public string Presion { get; set; } = string.Empty;

        // 3. Atención médica (registrada por el Doctor)
        public string Diagnostico { get; set; } = string.Empty;
        public string Receta { get; set; } = string.Empty;

        // Convierte las propiedades del objeto Paciente en una sola línea de texto separada por pipes (|)
        public string ToTextLine()
        {
            // Sanitiza saltos de línea para evitar romper la estructura de línea por registro
            string diagSanitizado = (Diagnostico ?? string.Empty).Replace("\r\n", " ").Replace("\n", " ").Replace("|", "/");
            string recSanitizado = (Receta ?? string.Empty).Replace("\r\n", " ").Replace("\n", " ").Replace("|", "/");

            return $"{Dni}|{Nombre}|{Apellido}|{Edad}|{Sis}|{Fecha}|{Especialidad}|{Contraseña}|{Temperatura}|{Talla}|{Peso}|{Presion}|{diagSanitizado}|{recSanitizado}";
        }

        // Método estático que recibe una línea de texto del archivo y reconstruye un objeto Paciente
        public static Paciente? FromTextLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return null;

            // Divide la línea utilizando el delimitador pipe (|) en un arreglo de cadenas
            string[] partes = line.Split('|');
            if (partes.Length < 8)
                return null;

            int.TryParse(partes[3], out int edad);

            // Retorna la nueva instancia de Paciente con sus atributos asignados
            return new Paciente
            {
                Dni = partes[0].Trim(),
                Nombre = partes[1].Trim(),
                Apellido = partes[2].Trim(),
                Edad = edad,
                Sis = partes[4].Trim(),
                Fecha = partes[5].Trim(),
                Especialidad = partes[6].Trim(),
                Contraseña = partes[7].Trim(),
                Temperatura = partes.Length > 8 ? partes[8].Trim() : string.Empty,
                Talla = partes.Length > 9 ? partes[9].Trim() : string.Empty,
                Peso = partes.Length > 10 ? partes[10].Trim() : string.Empty,
                Presion = partes.Length > 11 ? partes[11].Trim() : string.Empty,
                Diagnostico = partes.Length > 12 ? partes[12].Trim() : string.Empty,
                Receta = partes.Length > 13 ? partes[13].Trim() : string.Empty
            };
        }
    }
}
