using DevFreela.Core.Entites;
using Xunit;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTestes
    {
        [Fact]
        public void TestProjetStartWorks()
        {
            var project = new Project(1, 1, "Teste", "Teste", 1);
            project.Start();
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
        }
    }
}
