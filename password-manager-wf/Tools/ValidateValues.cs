using System.Text.RegularExpressions;
using System;

namespace password_manager_wf.Tools
{
    public class ValidateValues
    {
        //expresiones regulares para validar el email y la contraseña
        private static Regex validateEmail = new Regex("^\\S+@\\S+\\.\\S+$");
        private static Regex validatePassword = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");

        public static bool ValidateEmail(string email)
        {
            if (validateEmail.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidatePassword(string password)
        {
            if (validatePassword.IsMatch(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
