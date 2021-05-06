using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Participant :EntityHelper.Entity
    {
        public Event EventID { get; set; }
        public Consumer Consumer { get; set; }
    }
}
