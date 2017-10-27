using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class LotList : BaseServerResponse
    {
        public List<Vehicle> vehicle { get; set; }
    }
}
