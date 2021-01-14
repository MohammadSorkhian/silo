using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace silo_project.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
        : base(options)
        { }

        public DbSet<Silo> Silos { get; set; }

        public DbSet<DeviceRef> DeviceRefs { get; set; }

        public DbSet<Record> Records { get; set; }

        public DbSet<Setting> Settings { get; set; }


    }

}
