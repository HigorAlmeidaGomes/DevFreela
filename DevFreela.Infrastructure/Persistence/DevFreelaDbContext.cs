using DevFreela.Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        private const string _TB = "TB_";
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region TabelaProjectRelacionamento
            builder.Entity<Project>()
                .ToTable(string.Concat(_TB, nameof(Project)))
                .HasKey(pk => pk.Id);

            builder.Entity<Project>()
                .HasOne(x => x.Freelancer)
                .WithMany(y => y.FreelanceProjects)
                .HasForeignKey(fk => fk.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Project>()
                .HasOne(x => x.Client)
                .WithMany(y => y.OwnedProjects)
                .HasForeignKey(fk => fk.IdClient)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region TabelaUserRelacionamento
            builder.Entity<User>()
                .ToTable(string.Concat(_TB, nameof(User)))
                .HasKey(t => t.Id);

            builder.Entity<User>()
                .HasMany(x => x.Skills)
                .WithOne()
                .HasForeignKey(x => x.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region TabelaProjectCommentRelacionamento
            builder.Entity<ProjectComment>()
                .ToTable(string.Concat(_TB, nameof(ProjectComment)))
                .HasKey(t => t.Id);

            builder.Entity<ProjectComment>()
                .HasOne(x => x.Project)
                .WithMany(x => x.Comment)
                .HasForeignKey(x => x.IdProject);

            builder.Entity<ProjectComment>()
                .HasOne(x => x.User)
                .WithMany(x => x.ProjectComments)
                .HasForeignKey(x => x.IdUser);
            #endregion

            #region TabelasIsoladas
            builder.Entity<Skill>()
            .ToTable(string.Concat(_TB, nameof(Skill)))
            .HasKey(t => t.Id);

            builder.Entity<UserSkill>()
                .ToTable(string.Concat(_TB, nameof(UserSkill)))
                .HasKey(t => t.Id);
            #endregion

            base.OnModelCreating(builder);
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }
    }
}
