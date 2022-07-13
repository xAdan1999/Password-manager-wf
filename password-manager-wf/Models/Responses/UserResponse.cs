using System;

namespace password_manager_wf.Models.Responses
{
    public class UserResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public int userId { get; set; }
        public string username { get; set; }
        public string token { get; set; }
    }
}
