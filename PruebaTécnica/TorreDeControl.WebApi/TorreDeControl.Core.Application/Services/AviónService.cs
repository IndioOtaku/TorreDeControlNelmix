using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorreDeControl.Core.Application.Interfaces.IServices;
using TorreDeControl.Core.Application.Interfaces.Repositories;
using TorreDeControl.Core.Application.ViewModels.Aeropuerto;
using TorreDeControl.Core.Application.ViewModels.Avión;
using TorreDeControl.Core.Domain.Entities;

namespace TorreDeControl.Core.Application.Services
{
    public class AviónService : GenericService<SaveAviónViewModel, AviónViewModel, Avión>, IAviónService
    {
        private readonly IAviónRepository _aviónRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public AviónService(IAviónRepository aviónRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(aviónRepository, mapper)
        {
            _aviónRepository = aviónRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public override async Task Update(SaveAviónViewModel vm, int id)
        {
            await base.Update(vm, id);
        }

        public async Task<List<AviónViewModel>> GetAllViewModelWithInclude()
        {
            var aviónList = await _aviónRepository.GetAllWithIncludeAsync(new List<string> { "Aeropuerto" });

            return aviónList.Select(avión => new AviónViewModel
            {
                idAvión = avión.idAvión,
                nombreAvión = avión.nombreAvión,
                horaDeLlegada = avión.horaDeLlegada,
                horaDeSalida = avión.horaDeSalida,
                aeropuertoDeLlegada = avión.Aeropuerto.nombreAeropuerto,
                aeropuertoDeSalida = avión.Aeropuerto.nombreAeropuerto,
                límitePasajeros = avión.límitePasajeros,
                pesolímite = avión.pesoLímite,
                estadoDelAvión = avión.estadoDelAvión,
                FKaeropuerto = avión.Aeropuerto.idAeropuerto,
                cantidadPasajero = avión.Pasajeros.Where(pasajero => pasajero.idPasajero == avión.idAvión).Count(),
                pesoTotalPasajero = avión.Pasajeros.Where(pasajero => pasajero.pesoPasajero <= avión.pesoLímite).Count()
            }).ToList();
        }

    }
}
