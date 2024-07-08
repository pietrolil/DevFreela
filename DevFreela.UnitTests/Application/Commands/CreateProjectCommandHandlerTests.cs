using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            //Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            var projectRepositoryMock = new Mock<IProjectRepository>();
            var skillsRepository = new Mock<ISkillRepository>();

            unitOfWork.SetupGet(uow => uow.Projects).Returns(projectRepositoryMock.Object);
			unitOfWork.SetupGet(uow => uow.Skills).Returns(skillsRepository.Object);

			var createProjectCommand = new CreateProjectCommand
            {
                Title = "Titulo teste",
                Description = "Description",
                TotalCost = 1000,
                IdClient = 1,
                IdFreelancer = 2,
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(unitOfWork.Object);

            //Act

            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            //Assert

            Assert.True(id >= 0);

            projectRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}
