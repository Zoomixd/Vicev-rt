using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedelApp.Application.Infrastructure
{
    public interface ITidsRegistreringRepository
    {
        Task AddAsync(Domain.Entities.TidsRegistrering tidsRegistrering);
        Task<Domain.Entities.TidsRegistrering> GetAsync(int tidsRegistreringsid);
        Task SaveAsync(Domain.Entities.TidsRegistrering tidsRegistrering);
    }
}
