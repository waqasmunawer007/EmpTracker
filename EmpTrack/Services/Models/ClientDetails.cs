using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class ClientDetails : BaseServerResponse
    {
        public Client client { get; set; }
    }

    public class Client
    {
        public string id { get; set; }
        public string clientId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string sex { get; set; }
    }

}
