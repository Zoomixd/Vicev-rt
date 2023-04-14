using Microsoft.EntityFrameworkCore;
using PedelApp.Application.Contract.Dtos;
using PedelApp.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedelApp.Infrastructure.Queries
{
    public class TidsRegistreringQuery : ITidsRegistreringQuery
    {
        private readonly PedelAppContext _db;

        public TidsRegistreringQuery(PedelAppContext db)
        {
            _db = db;
        }



        async Task<TidsRegistreringQueryDto?> ITidsRegistreringQuery.GetTidsRegistreringAsync(int tidsRegistreringsid)
        {
            var result = await _db.TidsRegistrerings.FindAsync(tidsRegistreringsid);
            if (result is null) return new TidsRegistreringQueryDto();

            return new TidsRegistreringQueryDto
            {
                TidsRegistreringsId = result.TidsRegistreringsId,
                Start = result.Start,
                End = result.End,
                PedelId = result.PedelId,
                RekvisitionsId = result.RekvisitionsId

            };
        }

        async Task<IEnumerable<TidsRegistreringQueryDto>> ITidsRegistreringQuery.GetTidsRegistreringsAsync()
        {
            var result = new List<TidsRegistreringQueryDto>();
            var dbTidsRegistrerings = await _db.TidsRegistrerings.ToListAsync();
            dbTidsRegistrerings.ForEach(a => result.Add(new TidsRegistreringQueryDto
            {
                TidsRegistreringsId = a.TidsRegistreringsId,
                Start = a.Start,
                End = a.End,
                PedelId = a.PedelId,
                RekvisitionsId = a.RekvisitionsId  
            }));
            return result;
        }
    }
}
