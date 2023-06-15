using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorreDeControl.Core.Application.ViewModels.Aeropuerto;
using TorreDeControl.Core.Domain.Entities;

namespace TorreDeControl.Core.Application.Interfaces.IServices
{
    public interface IAeropuertoService : IGenericService<SaveAeropuertoViewModel,AeropuertoViewModel,Aeropuerto>
    {

    }
}
