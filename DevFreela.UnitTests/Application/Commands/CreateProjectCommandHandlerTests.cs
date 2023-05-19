using DevFreela.Application.Commands.CommandsProject.CreateProject;
using DevFreela.Core.Entites;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            {
                // Arrange
                var projectRepository = new Mock<IProjectRepository>();

                var createProjectCommand = new CreateProjectCommand
                {
                    Title = "Test CreateProjectCommand",
                    Description = "CreateProjectCommand TESTE",
                    TotalCost = 100,
                    IdClient = 2,
                    IdFreelancer = 1,
                };

                var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepository.Object);

                // act
                var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());
                //assert
                Assert.True(id >= 0);
                projectRepository.Verify(x => x.AddAsync(It.IsAny<Project>()), Times.Once());

            }
        }
    }
}
