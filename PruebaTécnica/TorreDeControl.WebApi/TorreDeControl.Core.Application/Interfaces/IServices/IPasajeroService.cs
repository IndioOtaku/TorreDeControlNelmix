using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorreDeControl.Core.Application.ViewModels.Avión;
using TorreDeControl.Core.Application.ViewModels.Pasajero;
using TorreDeControl.Core.Domain.Entities;

namespace TorreDeControl.Core.Application.Interfaces.IServices
{
    public interface IPasajeroService : IGenericService<SavePasajeroViewModel,PasajeroViewModel,Pasajero>
    {
        Task<List<PasajeroViewModel>> GetAllViewModelWithInclude();
    }
}
