using DevFreela.Core.Entites;
using DevFreela.Infrastructure.ClassGeneric;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserSkillConfigurations : TB_, IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder
               .ToTable(string.Concat(_TB, nameof(UserSkill)).ToUpper())
               .HasKey(t => t.Id);
        }
    }
}
