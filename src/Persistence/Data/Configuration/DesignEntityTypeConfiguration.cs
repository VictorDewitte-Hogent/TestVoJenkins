using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Packaging;

namespace Persistence.Data.Configuration
{
    public class DesignEntityTypeConfiguration : IEntityTypeConfiguration<Box>
    {
        public void Configure(EntityTypeBuilder<Box> builder)
        {
            builder.Property(c => c.Name).IsRequired();
        }
    }
}
