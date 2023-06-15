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
    public class AviónRepository : GenericRepository<Avión>, IAviónRepository
    {
        private readonly ApplicationContext _dbContext;

        public AviónRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
