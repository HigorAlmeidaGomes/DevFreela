using DevFreela.Application.Queries.GetProjects;
using DevFreela.Core.Entites;
using DevFreela.Core.Repositories;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // Arrange
            var project = new List<Project>
            {
                new Project(1,1,"Teste Project1","Testando1",10),
                new Project(1,1,"Teste Project2","Testando2",20),
                new Project(1,1,"Teste Project3","Testando3",30),
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(x => x.GetAllAsync().Result).Returns(project);

            var getAllProjectsQuery = new GetAllProjectQuery();
            var getAllProjectQueryHandler = new GetAllProjectQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectViewModelList = await getAllProjectQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(project.Count, projectViewModelList.Count);

            projectRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once());
        }
    }
}
