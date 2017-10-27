using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class LotGroupEntity
    {

        public string Location { get; set; }

        public int Count { get; set; }

        public string DeselectedStateIcon { get; set; }

        public bool IsSelected { get; set; }

        public string SelectedStateIcon { get; set; }
        
        public Action<LotGroupEntity> OnClickListener { get; set; }

        public List<Vehicle> vehicle { get; set; }
        
    }
    
}
