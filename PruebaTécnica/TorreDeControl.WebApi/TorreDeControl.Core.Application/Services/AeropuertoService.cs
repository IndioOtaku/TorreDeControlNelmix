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
using TorreDeControl.Core.Domain.Entities;

namespace TorreDeControl.Core.Application.Services
{
    public class AeropuertoService : GenericService<SaveAeropuertoViewModel, AeropuertoViewModel, Aeropuerto>, IAeropuertoService
    {
        private readonly IAeropuertoRepository _aeropuertoRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public AeropuertoService(IAeropuertoRepository aeropuertoRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(aeropuertoRepository, mapper)
        {
            _aeropuertoRepository = aeropuertoRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public override async Task Update(SaveAeropuertoViewModel vm, int id)
        {
            await base.Update(vm, id);
        }
    }
}
