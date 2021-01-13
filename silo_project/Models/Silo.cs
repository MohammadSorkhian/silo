using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace silo_project.Models
{
    public class Silo
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public DeviceRef DeviceID { get; set; }

        public int CommandID { get; set; }

        public int ZeroValue { get; set; }

        [Column(TypeName ="Decimal(8,3)")]
        public decimal ScaleValue { get; set; }

        public bool AllowDownload { get; set; }

        public int Weight { get; set; }

        public bool IsActive { get; set; }

        public bool IsRegistered { get; set; }
    }
}
