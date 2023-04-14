using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedelApp.Application.Contract.Dtos
{
    public interface ITidsRegistreringQuery
    {
        Task<TidsRegistreringQueryDto?> GetTidsRegistreringAsync(int tidsRegistreringsid);
        Task<IEnumerable<TidsRegistreringQueryDto>> GetTidsRegistreringsAsync();
    }
}
