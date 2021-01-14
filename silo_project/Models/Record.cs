using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace silo_project.Models
{
    public class Record
    {
        public int ID { get; set; }

        public Silo Silo { get; set; }

        public DateTime EnDate { get; set; }

        public DateTime PeDate { get; set; }

        // @@@@@ We may do not require to separate date from time @@@@@//
        public TimeSpan Time { get; set; }

        public int Weight { get; set; }


    }
}
