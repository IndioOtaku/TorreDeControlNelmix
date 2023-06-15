using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorreDeControl.Core.Application.ViewModels.Aeropuerto;
using TorreDeControl.Core.Application.ViewModels.Avión;
using TorreDeControl.Core.Domain.Entities;

namespace TorreDeControl.Core.Application.Interfaces.IServices
{
    public interface IAviónService : IGenericService<SaveAviónViewModel, AviónViewModel, Avión>
    {
        Task<List<AviónViewModel>> GetAllViewModelWithInclude();
    }
}
