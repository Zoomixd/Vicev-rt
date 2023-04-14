using PedelApp.Application.Infrastructure;
using PedelApp.Domain.Entities;
using PedelApp.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedelApp.Infrastructure.RepositoriesImpl
{
    public class TidsRegistreringRepository : ITidsRegistreringRepository
    {
        private readonly PedelAppContext _db;

        public TidsRegistreringRepository(PedelAppContext db)
        {
            _db = db;
        }
        async Task ITidsRegistreringRepository.AddAsync(Domain.Entities.TidsRegistrering tidsRegistrering)
        {
            _db.TidsRegistrerings.Add(tidsRegistrering);
            await _db.SaveChangesAsync();
        }        

        async Task<Domain.Entities.TidsRegistrering> ITidsRegistreringRepository.GetAsync(int tidsRegistreringsid)
        {
            return await _db.TidsRegistrerings.FindAsync(tidsRegistreringsid) ?? throw new Exception("TidsRegistrering not found");
        }

        async Task ITidsRegistreringRepository.SaveAsync(Domain.Entities.TidsRegistrering tidsRegistrering)
        {
            _db.TidsRegistrerings.Update(tidsRegistrering);
            await _db.SaveChangesAsync();
        }
    }
}
