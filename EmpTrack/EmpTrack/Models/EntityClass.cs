using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpTrack.Models
{
    public class EntityClass
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SelectedStateIcon { get; set; }

        public string DeselectedStateIcon { get; set; }

        public bool IsSelected { get; set; }

        public List<EntityClass> ChildItems { get; set; }

        public Action<EntityClass> OnClickListener { get; set; }
    }
}
