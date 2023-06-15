using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorreDeControl.Core.Application.ViewModels.Aeropuerto;
using TorreDeControl.Core.Application.ViewModels.Avión;
using TorreDeControl.Core.Domain.Entities;

namespace TorreDeControl.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Aeropuerto, AeropuertoViewModel>()
                .ReverseMap();

            CreateMap<Aeropuerto, SaveAeropuertoViewModel>()
                .ReverseMap();

            CreateMap<Avión, AviónViewModel>()
                .ReverseMap();

            CreateMap<Avión, SaveAviónViewModel>()
                .ReverseMap();
        }
    }
}
