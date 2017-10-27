using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class BaseServerResponse
    {
        public bool Status { get; set; }
        public String ErrorMessage { get; set; }
    }
}
