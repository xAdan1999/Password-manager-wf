using System;

namespace password_manager_wf.Models
{
    public class Password
    {
        //modelo para realizar insert  o update
        public int id { get; set; }
        public int user_id { get; set; }
        public string title { get; set; }
        public string username_or_email { get; set; }
        public string password { get; set; }
    }
}
