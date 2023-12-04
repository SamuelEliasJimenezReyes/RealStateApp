

using RealState.Infraestructure.Persistence.Context;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Domain.Entities;

namespace RealState.Infraestructure.Persistence.Repositories
{
    public class ImagesPropertiesRepository : GenericRepository<ImagesProperties>, IImagesPropertiesRepository
    {
        public ImagesPropertiesRepository(RealStateContext dbContext) : base(dbContext)
        {
        }
    }
}
