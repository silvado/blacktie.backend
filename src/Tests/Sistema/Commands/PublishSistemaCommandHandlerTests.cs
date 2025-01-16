using Application.Commands.PublishSistema;
using AutoFixture;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;
using Moq;

namespace Tests.Commands
{
    public class PublishSistemaCommandHandlerTests
    {
        [Fact]
        public async Task Handle_WithExistingSistema_ReturnsTrue()
        {
            var fixture = new Fixture();
            var request = fixture.Create<PublishSistemaCommand>();

            var serviceMock = new Mock<ISistemaService>();

            var item = request.Adapt<Sistema>();

            serviceMock
                .Setup(r => r.PublishSistemaAsync(item))
                .ReturnsAsync(true);

            var handler = new PublishSistemaCommandHandler(serviceMock.Object);
            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsType<bool>(result);

        }
    }
}
