using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using Xunit;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartsWorks()
        {
            var project = new Project("Test Project", "This is a unit test", 1, 2, 1000);

            project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
        }
    }
}