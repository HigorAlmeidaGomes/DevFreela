using DevFreela.Core.Entites;
using DevFreela.Infrastructure.ClassGeneric;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : TB_, IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                  .ToTable(string.Concat(_TB, nameof(User)).ToUpper())
                  .HasKey(t => t.Id);

            builder
                .HasMany(x => x.Skills)
                .WithOne()
                .HasForeignKey(x => x.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
