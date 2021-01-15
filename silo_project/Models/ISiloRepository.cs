using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace silo_project.Models
{
    public interface ISiloRepository
    {
        IEnumerable<Silo> GetAllSilos();

        Silo AddSilo(Silo silo);

        Silo FindSilo(int id);

        EntityEntry DeleteSilo(Silo silo);

        void UpdateSilo(Silo silo);
    }
}
