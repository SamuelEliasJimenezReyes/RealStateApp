using Microsoft.EntityFrameworkCore;

namespace RealState.Infraestructure.Persistence.Context
{
    public  class RealStateContext : DbContext
    {
        public RealStateContext(DbContextOptions<RealStateContext> options) : base(options) { }

    }
}
