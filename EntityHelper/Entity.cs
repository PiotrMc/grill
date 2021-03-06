using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityHelper
{
    public class Entity
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column]
        public DateTime ConsumerDateofBirth { get; }

        [Column]
        public string ConsumerFirstName { get; }
    }
}
