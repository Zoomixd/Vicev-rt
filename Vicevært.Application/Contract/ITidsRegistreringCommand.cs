using PedelApp.Application.Contract.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedelApp.Application.Contract
{
    public interface ITidsRegistreringCommand
    {
        Task CreateAsync(TidsRegistreringCommandDto tidsRegistreringDto);
    }
}
