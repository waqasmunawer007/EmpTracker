using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class LotDetails:BaseServerResponse
    {
        public Vehicle vehicle { get; set; }
    }

    public class Vehicle
    {

        public string DeselectedStateIcon { get; set; }

        public bool IsSelected { get; set; }
        
        public string SelectedStateIcon { get; set; }

        public Action<Vehicle> OnClickListener { get; set; }

        public string id { get; set; }
        public string LotId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Trim { get; set; }
        public string Description { get; set; }
        public string Class { get; set; }
        public string PaymentDone { get; set; }
        public string IsPicked { get; set; }
        public object BuyerID { get; set; }
        public string Location { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }


}
