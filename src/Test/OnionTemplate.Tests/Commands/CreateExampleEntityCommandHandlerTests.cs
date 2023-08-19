using AutoMapper;
using Moq;
using OnionTemplate.Application.Dto;
using OnionTemplate.Application.Features.Commands;
using OnionTemplate.Application.Interfaces.Repositories;
using OnionTemplate.Domain;

namespace OnionTemplate.Tests.Commands
{
    public class CreateExampleEntityCommandHandlerTests
    {
        [Fact]
        public async void Handle_Should_ReturnSuccess_WhenNameIsNotEmpty()
        {
            // ARRANGE
            string? createName = "Test";
            var createdEntity = new ExampleEntity()
            {
                Id = Guid.NewGuid(),
                Name = createName,
            };

            CreateExampleEntityCommand createEntityCommand = new CreateExampleEntityCommand()
            {
                Name = createName,
            };

            var repositoryMock = new Mock<IExampleEntityRepository>();

            repositoryMock
                .Setup(x => x.CreateAsync(It.IsAny<ExampleEntity>()))
                .ReturnsAsync(createdEntity);

            var mapperMock = new Mock<IMapper>();

            mapperMock
                .Setup(x => x.Map<ExampleEntityDto>(It.IsAny<ExampleEntity>()))
                .Returns<ExampleEntityDto>(_ => new ExampleEntityDto()
                {
                    Id =createdEntity.Id,
                    Name = createdEntity.Name,
                });

            CreateExampleEntityCommand.CreateExampleEntityCommandHandler handler =
                new CreateExampleEntityCommand.CreateExampleEntityCommandHandler(repositoryMock.Object, mapperMock.Object);

            // ACT

            var result = await handler.Handle(createEntityCommand, default);

            // ASSERT

            Assert.NotNull(result);
            Assert.True(result.Value?.Name == createName);
            Assert.True(result.SuccessStatus);
        }

        [Fact]
        public async void Handle_Should_ReturnFailure_WhenNameIsEmpty()
        {
            // ARRANGE
            string? createName = "";
            CreateExampleEntityCommand createEntityCommand = new CreateExampleEntityCommand()
            {
                Name = createName,
            };

            var repositoryMock = new Mock<IExampleEntityRepository>();
            var mapperMock = new Mock<IMapper>();

            CreateExampleEntityCommand.CreateExampleEntityCommandHandler handler =
                new CreateExampleEntityCommand.CreateExampleEntityCommandHandler(repositoryMock.Object, mapperMock.Object);

            // ACT
            var result = await handler.Handle(createEntityCommand, default);

            // ASSERT
            Assert.Null(result.Value);
            Assert.False(result.SuccessStatus);
        }
    }
}