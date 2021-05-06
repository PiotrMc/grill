using EntityHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Event : Entity
    {
        [Required]
        public int EventID { get; set; }

        public string EventName { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime EventDate { get; set; }
//        public Consumer? EventOwner { get; set; }
        public int? EventLimit { get; set; }
        //public virtual ICollection<Consumer> Consumers { get; set; }
    }
}
