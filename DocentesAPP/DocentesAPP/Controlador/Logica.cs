using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DocentesAPP
{
    public class Logica
    {
        public bool ValidarPassword(Entry password)
        {
            //8
            if (String.IsNullOrEmpty(password.Text))
            {
                return true;
            }
            if (password.Text.Length >= 8)
                return true;
            else
                return false;
        }
        public bool ValidarCorreo(Entry Correo)
        {

            if (string.IsNullOrEmpty(Correo.Text))
            {
                return true;
            }
            if (!Correo.Text.Contains("."))
            {
                return true;
            }

            if (!Correo.Text.Contains("@"))
            {
                return true;
            }
            //FIN

            else
                return false;
        }

    }

}
