using DevFreela.Core.Entites;
using DevFreela.Infrastructure.ClassGeneric;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectCommentConfigurations : TB_, IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder
                 .ToTable(string.Concat(_TB, nameof(ProjectComment)).ToUpper())
                 .HasKey(t => t.Id);

            builder
                .HasOne(x => x.Project)
                .WithMany(x => x.Comment)
                .HasForeignKey(x => x.IdProject);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.ProjectComments)
                .HasForeignKey(x => x.IdUser);
        }
    }
}
