using PedelApp.Domain.DomainServices;
using PedelApp.Domain.Entities;
using PedelApp.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedelApp.Infrastructure.DomainServiceImpl
{
    public class TidsRegistreringDomainService : ITidsRegistreringDomainService
    {
        private readonly PedelAppContext _db;

        public TidsRegistreringDomainService(PedelAppContext db)
        {
            _db = db;
        }
        IEnumerable<Domain.Entities.TidsRegistrering> ITidsRegistreringDomainService.GetAllTidsRegistrerings()
        {
            return _db.TidsRegistrerings.ToList();
        }
        
    }
}
