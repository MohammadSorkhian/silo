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
        public IEnumerable<string> siloNames { get; set; }

        //These info is used for filtering
        public string siloName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }
        public int startWeight { get; set; }
        public int endWeight { get; set; }

    }
}
