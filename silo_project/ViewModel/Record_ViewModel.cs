using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using silo_project.Models;

namespace silo_project.ViewModel
{
    public class Record_ViewModel
    {
        public IEnumerable<Record> allRecords { get; set; }
        public Record record { get; set; }
        public List<string> silosNames { get; set; }
    }
}
