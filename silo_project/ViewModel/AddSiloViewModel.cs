﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using silo_project.Models;

namespace silo_project.ViewModel
{
    public class AddSiloViewModel
    {
        public IEnumerable<Silo> allSilos { get; set; }
        public Silo silo { get; set; }
    }
}
