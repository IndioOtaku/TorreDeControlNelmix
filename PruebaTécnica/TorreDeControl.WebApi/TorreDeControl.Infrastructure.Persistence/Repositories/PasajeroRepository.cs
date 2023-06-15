using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorreDeControl.Core.Application.Interfaces.Repositories;
using TorreDeControl.Core.Domain.Entities;
using TorreDeControl.Infrastructure.Persistence.Contexts;

namespace TorreDeControl.Infrastructure.Persistence.Repositories
{
    public class PasajeroRepository : GenericRepository<Pasajero>, IPasajeroRepository
    {
        private readonly ApplicationContext _dbContext;

        public PasajeroRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
