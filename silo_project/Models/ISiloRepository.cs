using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace silo_project.Models
{
    public interface ISiloRepository
    {
        IEnumerable<Silo> GetAllSilos();
        Silo AddSilo(Silo silo);
    }
}
