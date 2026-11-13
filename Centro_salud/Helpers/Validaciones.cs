using System;
using System.Windows.Forms;

namespace Centro_salud.Helpers
{
    public static class Validaciones
    {
        /// <summary>
        /// Permite únicamente letras (incluidas tildes y ñ), espacios y teclas de control (Backspace, etc.).
        /// </summary>
        public static void PermitirSoloLetras(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Permite únicamente números enteros y teclas de control.
        /// </summary>
        public static void PermitirSoloNumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Permite números decimales con un único punto o coma.
        /// </summary>
        public static void PermitirDecimales(KeyPressEventArgs e, TextBox textBox)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.' || e.KeyChar == ',') && !textBox.Text.Contains('.') && !textBox.Text.Contains(','))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Permite números y una barra oblicua (/) para formato de presión arterial (ejemplo: 120/80).
        /// </summary>
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
