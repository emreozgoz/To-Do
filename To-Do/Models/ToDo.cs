using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace To_Do.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Describe{ get; set; }

        public bool isFinished { get; set; }
    }
}
