using DevFreela.Core.Entites;
using DevFreela.Infrastructure.ClassGeneric;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfigurations : TB_, IEntityTypeConfiguration<Project>
    {

        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
           .ToTable(string.Concat(_TB, nameof(Project)).ToUpper())
           .HasKey(pk => pk.Id);

            builder
                .HasOne(x => x.Freelancer)
                .WithMany(y => y.FreelanceProjects)
                .HasForeignKey(fk => fk.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Client)
                .WithMany(y => y.OwnedProjects)
                .HasForeignKey(fk => fk.IdClient)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
