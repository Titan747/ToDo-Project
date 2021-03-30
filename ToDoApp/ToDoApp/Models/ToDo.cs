using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
	public class ToDo
	{
        public class Equipment
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Required]
            public int Id { get; set; }
            [Required]
            public string Description { get; set; }
            public bool IsDone { get; set; }
        }
    }
}
