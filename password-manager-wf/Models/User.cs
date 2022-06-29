using System;

namespace password_manager_wf.Models
{
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string username { get; set; }
    }
}
