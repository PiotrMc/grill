using EntityHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Consumer : Entity
    {
        public String CustomerFirstName { get; set; }
        public String CustomerLastName { get; set; }
        public String CustomerEmail { get; set; }
        [Column(TypeName = "Date")]
        public DateTime CustomerDateofBirth { get; set; }

    }
}
