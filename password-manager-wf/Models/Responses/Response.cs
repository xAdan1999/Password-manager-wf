using System;

namespace password_manager_wf.Models.Responses
{
    public class Response
    {
        //para deserializar acciones como insert, update y delete
        public bool success { get; set; }
        public string message { get; set; }
    }
}
