using DevFreela.Core.Entites;
using DevFreela.Infrastructure.ClassGeneric;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class SkillConfigurations : TB_, IEntityTypeConfiguration<Skill>
    {

        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder
            .ToTable(string.Concat(_TB, nameof(Skill)).ToUpper())
            .HasKey(t => t.Id);
        }
    }
}
