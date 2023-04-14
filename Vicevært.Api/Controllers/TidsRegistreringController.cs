using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PedelApp.Application.Contract;
using PedelApp.Application.Contract.Dtos;
using PedelApp.Contract;
using PedelApp.Contract.Dtos;
using Vicevært.Contract.Dtos;

namespace Vicevært.Api.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/TidsRegistrering")]
    [ApiController]
    public class TidsRegistreringController : ControllerBase, ITidsRegistreringService
    {
        private readonly ITidsRegistreringCommand _tidsRegistreringCommand;
        private readonly ITidsRegistreringQuery _tidsRegistreringQuery;

        public TidsRegistreringController(ITidsRegistreringQuery tidsRegistreringQuery, ITidsRegistreringCommand tidsRegistreringCommand)
        {
            _tidsRegistreringQuery = tidsRegistreringQuery;
            _tidsRegistreringCommand = tidsRegistreringCommand;
        }

        [HttpGet]
        public async Task<IEnumerable<TidsRegistreringDto>> GetAsync()

        {
            var result = new List<TidsRegistreringDto>();
            var tidsRegistrerings = await _tidsRegistreringQuery.GetTidsRegistreringsAsync();
            tidsRegistrerings.ToList()
                .ForEach(a => result.Add(new TidsRegistreringDto { TidsRegistreringsId = a.TidsRegistreringsId, RekvisitionsId = a.RekvisitionsId, PedelId = a.PedelId, Start = a.Start, End = a.End }));
            return result;
        }

        [HttpGet("{tidsRegistreringsid}")]
        public async Task<TidsRegistreringDto?> GetAsync(int tidsRegistreringsid)
        {
            var tidsRegistrering = await _tidsRegistreringQuery.GetTidsRegistreringAsync(tidsRegistreringsid);
            if (tidsRegistrering is null) return null;
            return new TidsRegistreringDto { TidsRegistreringsId = tidsRegistrering.TidsRegistreringsId, RekvisitionsId = tidsRegistrering.RekvisitionsId, PedelId = tidsRegistrering.PedelId, Start = tidsRegistrering.Start, End = tidsRegistrering.End };
        }

        [HttpPost]
        public async Task CreateAsync([FromBody] TidsRegistreringDto value)
        {
            await _tidsRegistreringCommand.CreateAsync(new TidsRegistreringCommandDto { TidsRegistreringsId = value.TidsRegistreringsId, RekvisitionsId = value.RekvisitionsId, PedelId = value.PedelId, Start = value.Start, End = value.End });
        }

        [HttpPut]
        public Task EditAsync(RekvisitionDto rekvisitionDto)
        {
            throw new NotImplementedException();
        }
    }
}
