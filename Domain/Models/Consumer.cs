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
        public String ConsumerFirstName { get; set; }
        public String ConsumerLastName { get; set; }
        public String ConsumerEmail { get; set; }
        [Column(TypeName = "Date")]
        
        public DateTime ConsumerDateofBirth { get; set; }

    }
}
