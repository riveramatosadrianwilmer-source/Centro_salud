using System;
using System.Windows.Forms;

namespace Centro_salud.Helpers
{
    // Clase estática con métodos auxiliares para validar las teclas ingresadas en las cajas de texto
    public static class Validaciones
    {
        // Procedimiento para permitir únicamente letras (con tildes y ñ), espacios y teclas de borrar/control
        public static void PermitirSoloLetras(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false; // Permite el carácter
            }
            else
            {
                e.Handled = true; // Bloquea el carácter no permitido
            }
        }

        // Procedimiento para permitir únicamente números enteros (0-9) y teclas de borrar/control
        public static void PermitirSoloNumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false; // Permite el número
            }
            else
            {
                e.Handled = true; // Bloquea letras o símbolos
            }
        }

        // Procedimiento para permitir números decimales con un único punto o coma
        public static void PermitirDecimales(KeyPressEventArgs e, TextBox textBox)
        {
            // Si es un dígito o tecla de control, se permite
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            // Si es punto o coma, solo se permite si la caja aún no contiene uno
            else if ((e.KeyChar == '.' || e.KeyChar == ',') && !textBox.Text.Contains('.') && !textBox.Text.Contains(','))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true; // Bloquea si ya tiene punto o si es letra
            }
        }

        // Procedimiento para permitir números y una sola barra inclinada (/) para presión arterial (ejemplo: 120/80)
        public static void PermitirPresion(KeyPressEventArgs e, TextBox textBox)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '/' && !textBox.Text.Contains('/'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
