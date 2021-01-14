using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    }
}
