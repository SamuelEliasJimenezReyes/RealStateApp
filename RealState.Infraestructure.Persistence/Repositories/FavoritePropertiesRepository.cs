﻿
using RealState.Infraestructure.Persistence.Context;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Domain.Entities;

namespace RealState.Infraestructure.Persistence.Repositories
{
    public class FavoritePropertiesRepository : GenericRepository<FavoriteProperties>, IFavoritePropertiesRepository
    {
        private readonly RealStateContext _context;
        public FavoritePropertiesRepository(RealStateContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<int>> GetFavoritePropertiesId(string clientId)
        {
            var list = await GetAllAsync();
            return list.Where(x => x.ClientId == clientId).Select(x => x.PropertiesId).ToList();
        }
    }
}
