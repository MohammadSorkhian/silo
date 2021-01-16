using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace silo_project.Models
{
    public class SQLSiloRepository:ISQLRepository
    {
        private readonly AppDbContext _db;

        public SQLSiloRepository(AppDbContext db)
        {
            _db = db;
        }

        #region Silo
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
            EntityEntry entityEntry = _db.Silos.Remove(silo);
            _db.SaveChanges();
            return entityEntry;
        }

        public void UpdateSilo(Silo silo)
        {
            EntityEntry siloEntityEntry = _db.Silos.Attach(silo);
            siloEntityEntry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }
        #endregion Silo




        #region Records
        public IEnumerable<Record> GetAllRecords()
        {
            return _db.Records.Include(r => r.Silo);
        }

        public Record AddRecord(Record record)
        {
            _db.Records.Add(record);
            _db.SaveChanges();
            return record;
        }

        public EntityEntry DeteteRecord(Record record)
        {
            EntityEntry entityEntry = _db.Records.Remove(record);
            _db.SaveChanges();
            return entityEntry;
        }

        public Record FindRecord(int id)
        {
            Record record = _db.Records.FirstOrDefault((r) => r.ID == id);
            return record;
        }

        public void UpdateRecord(Record record)
        {
            throw new NotImplementedException();
        }
        #endregion Records
    }
}
