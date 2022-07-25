using System;

namespace password_manager_wf.Models.Responses
{
    public class UserResponse
    {
        //modelo para guardar la sesion
        public bool success { get; set; }
        public bool logged_in { get; set; }
        public string message { get; set; }
        public int user_id { get; set; }
        public string username { get; set; }
        public string token { get; set; }
    }
}
