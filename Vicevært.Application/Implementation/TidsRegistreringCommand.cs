using PedelApp.Application.Contract;
using PedelApp.Application.Contract.Dtos;
using PedelApp.Application.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedelApp.Application.Implementation
{
    public class TidsRegistreringCommand : ITidsRegistreringCommand
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ITidsRegistreringRepository _repository;

        public TidsRegistreringCommand(IServiceProvider serviceProvider, ITidsRegistreringRepository repository)
        {
            _serviceProvider = serviceProvider;
            _repository = repository;
        }

        async Task ITidsRegistreringCommand.CreateAsync(TidsRegistreringCommandDto tidsRegistreringDto)
        {
            var tidsRegistrering = new Domain.Entities.TidsRegistrering(_serviceProvider, tidsRegistreringDto.Start, tidsRegistreringDto.End, tidsRegistreringDto.PedelId, tidsRegistreringDto.RekvisitionsId, tidsRegistreringDto.TidsRegistreringsId);
            await _repository.AddAsync(tidsRegistrering);
        }

        
    }
}
