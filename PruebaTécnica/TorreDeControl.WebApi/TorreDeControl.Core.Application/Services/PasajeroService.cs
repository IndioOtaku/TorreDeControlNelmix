using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorreDeControl.Core.Application.Interfaces.IServices;
using TorreDeControl.Core.Application.Interfaces.Repositories;
using TorreDeControl.Core.Application.ViewModels.Avión;
using TorreDeControl.Core.Application.ViewModels.Pasajero;
using TorreDeControl.Core.Domain.Entities;

namespace TorreDeControl.Core.Application.Services
{
    public class PasajeroService : GenericService<SavePasajeroViewModel, PasajeroViewModel, Pasajero>, IPasajeroService
    {
        private readonly IPasajeroRepository _pasajeroRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public PasajeroService(IPasajeroRepository pasajeroRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(pasajeroRepository, mapper)
        {
            _pasajeroRepository = pasajeroRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<List<PasajeroViewModel>> GetAllViewModelWithInclude()
        {
            var pasajeroList = await _pasajeroRepository.GetAllWithIncludeAsync(new List<string> { "Avión" });

            return pasajeroList.Select(pasajero => new PasajeroViewModel
            {
                idPasajero = pasajero.idPasajero,
                nombrePasajero = pasajero.nombrePasajero,
                pesoPasajero = pasajero.pesoPasajero,
                nombreAvión = pasajero.Avión.nombreAvión
            }).ToList();
        }
    }
}
