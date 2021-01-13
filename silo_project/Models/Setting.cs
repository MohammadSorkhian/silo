using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace silo_project.Models
{
    public class Setting
    {
        [Column(TypeName ="nvarchar(50)")]
        [Required]
        public string Name { get; set; }

        public bool BoolValue { get; set; }

        public int IntValue { get; set; }

        public string StrValue { get; set; }
    }
}
