using Microsoft.EntityFrameworkCore;
using ServiceStation.DAL.Data;
using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.DAL.Repositories
{
    public class TokenRepository : GenericRepository<RefreshToken>, ITokenRepository
    {

        public TokenRepository(ServiceStationDContext databaseContext)
    : base(databaseContext)
        {
        }

        public async Task<RefreshToken> GetModelByClientId(int clientId) => await table.Where(p => p.ClientId == clientId).FirstOrDefaultAsync();




    }
}
