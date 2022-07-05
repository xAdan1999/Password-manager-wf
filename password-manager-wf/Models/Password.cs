using System;

namespace password_manager_wf.Models
{
    public class Password
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int websiteId { get; set; }
        public string websiteName { get; set; }
        public string usernameOrEmail { get; set; }
        public string passwordToSave { get; set; }
    }
}
