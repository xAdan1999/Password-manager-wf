using System;

namespace password_manager_wf.Models.Responses
{
    public class PasswordResponse
    {
        //modelo para obtencion de datos
        public int id { get; set; }
        public string title { get; set; }
        public string usernameOrEmail { get; set; }
        public string passwordToSave { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
    }
}
