using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class DelawareAppDataInitializer
    {
        private readonly DelawareAppDbContext _dbContext;

        public DelawareAppDataInitializer(DelawareAppDataInitializer dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                // Seed Products
            }
        }
    }
}
