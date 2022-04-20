using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]

        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModel()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Nome do teste 1", "Descriçao teste 1",1,2,1000),
                new Project("Nome do teste 2", "Descriçao teste 2",1,2,2000),
                 new Project("Nome do teste 3", "Descriçao teste 3",1,2,3000)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            // Act
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert

            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }

       
    }
}
