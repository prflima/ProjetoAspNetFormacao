using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectExist_Executed_ReturnThreeProjectViewModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Project test 01", "description test 01", 1, 2, 10000),
                new Project("Project test 02", "description test 02", 1, 2, 20000),
                new Project("Project test 03", "description test 03", 1, 2, 30000)
            };

            var projectRepository = new Mock<IProjectRepository>();
            projectRepository.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

            var queryHandler = new GetAllProjectsQuery();
            var handler = new GetAllProjectsQueryHandler(projectRepository.Object);

            // Act
            var result = await handler.Handle(queryHandler, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(projects.Count, result.Count);

            projectRepository.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}