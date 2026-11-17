using System;
using System.IO;
using System.Windows.Forms;
using Centro_salud.Data;
using Centro_salud.Helpers;
using Centro_salud.Models;
namespace Centro_salud
{
    internal static class Program
    {
        /// <summary>
        ///  Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--test")
            {
                EjecutarPruebasAutomaticas();
                return;
            }

            // Para personalizar la configuración de la aplicación
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }

        private static void EjecutarPruebasAutomaticas()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("INICIANDO PRUEBAS AUTOMÁTICAS DE CENTRO DE SALUD");
            Console.WriteLine("==================================================");

            var repo = new PacienteRepository();
            Console.WriteLine($"[1] Repositorio inicializado en: {repo.FilePath}");

            // Prueba 1: Registro de paciente
            var nuevoPaciente = new Centro_salud.Models.Paciente
            {
                Dni = "76543210",
                Nombre = "Maria",
                Apellido = "Gomez",
                Edad = 28,
                Sis = "Si",
                Fecha = "13/11/2026",
                Especialidad = "Medicina General",
                Contraseña = "clave_segura_123"
            };

            repo.Registrar(nuevoPaciente);
            Console.WriteLine("[2] Paciente registrado correctamente.");

            // Prueba 2: Búsqueda por DNI
            var pacienteBuscado = repo.BuscarPorDni("76543210");
            if (pacienteBuscado == null || pacienteBuscado.Nombre != "Maria")
            {
                throw new Exception("FALLO: No se encontró al paciente por DNI.");
            }
            Console.WriteLine("[3] Búsqueda por DNI exitosa.");

            // Prueba 3: Validación de contraseña de paciente
            bool passValida = repo.ValidarContraseñaPaciente("clave_segura_123", out var pacienteAuth);
            if (!passValida || pacienteAuth?.Dni != "76543210")
            {
                throw new Exception("FALLO: La validación de contraseña de paciente no funcionó.");
            }
            bool passInvalida = repo.ValidarContraseñaPaciente("clave_incorrecta", out _);
            if (passInvalida)
            {
                throw new Exception("FALLO: Contraseña inválida fue aceptada.");
            }
            Console.WriteLine("[4] Autenticación de contraseña de paciente exitosa.");

            // Prueba 4: Tópico - actualización de signos vitales
            bool topicoOk = repo.ActualizarTopico("76543210", "36.6", "1.65", "60.5", "110/70");
            if (!topicoOk)
            {
                throw new Exception("FALLO: No se pudo actualizar datos de tópico.");
            }
            var pacTopico = repo.BuscarPorDni("76543210");
            if (pacTopico?.Temperatura != "36.6" || pacTopico?.Presion != "110/70")
            {
                throw new Exception("FALLO: Los datos de triaje no coinciden.");
            }
            Console.WriteLine("[5] Actualización y persistencia de Tópico/Triaje exitosa.");

            // Prueba 5: Doctor - actualización de diagnóstico y receta
            bool docOk = repo.ActualizarDoctor("76543210", "Amigdalitis aguda", "Amoxicilina 500mg cada 8 horas por 7 días");
            if (!docOk)
            {
                throw new Exception("FALLO: No se pudo actualizar datos de doctor.");
            }
            var pacDoctor = repo.BuscarPorDni("76543210");
            if (pacDoctor?.Diagnostico != "Amigdalitis aguda" || string.IsNullOrWhiteSpace(pacDoctor?.Receta))
            {
                throw new Exception("FALLO: Diagnóstico y receta no se guardaron correctamente.");
            }
            Console.WriteLine("[6] Actualización y persistencia de Doctor (Diagnóstico y Receta) exitosa.");

            // Prueba 6: Verificación del contenido del archivo TXT
            string[] lineas = File.ReadAllLines(repo.FilePath);
            Console.WriteLine($"[7] Archivo TXT contiene {lineas.Length} registro(s). Última línea:\n    {lineas[lineas.Length - 1]}");

            Console.WriteLine("==================================================");
            Console.WriteLine("TODAS LAS PRUEBAS PASARON SATISFACTORIAMENTE (100% OK)");
            Console.WriteLine("==================================================");
        }
    }
}
