using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace silo_project.Models
{
    public class SQLSiloRepository:ISiloRepository
    {
        private readonly AppDbContext _db;

        public SQLSiloRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Silo> GetAllSilos()
        {
            return _db.Silos;
        }

        public Silo AddSilo(Silo silo)
        {
            _db.Silos.Add(silo);
            _db.SaveChanges();
            return (silo);
        }

        public Silo FindSilo(int id)
        {
           return _db.Silos.FirstOrDefault((silo) => silo.ID == id);
        }

        public EntityEntry DeleteSilo(Silo silo)
        {
            Silo siloToDelete = silo;
            EntityEntry entityEntry = _db.Silos.Remove(siloToDelete);
            _db.SaveChanges();
            return entityEntry;
        }
    }
}
