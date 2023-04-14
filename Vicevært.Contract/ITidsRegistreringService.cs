using PedelApp.Contract.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedelApp.Contract
{
    public interface ITidsRegistreringService
    {
        Task CreateAsync(TidsRegistreringDto tidsRegistreringDto);
        // Task EditAsync(RekvisitionDto rekvisitionDto);
        Task<TidsRegistreringDto?> GetAsync(int tidsRegistreringsid);
        Task<IEnumerable<TidsRegistreringDto>> GetAsync();
    }
}
