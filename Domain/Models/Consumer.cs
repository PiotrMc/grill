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
    public class Consumer : Entity
    {
        [Required]
        public String ConsumerFirstName { get; set; }
        [Required]
        public String ConsumerLastName { get; set; }
        [Required]
        public String ConsumerEmail { get; set; }
        [Column(TypeName = "Date")]
        [Required]
        public DateTime ConsumerDateofBirth { get; set; }

    }
}
