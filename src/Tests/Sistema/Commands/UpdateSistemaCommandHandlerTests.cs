using Application.Commands.UpdateSistema;
using AutoFixture;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;
using Moq;

namespace Tests.Commands
{
    public class UpdateSistemaCommandHandlerTests
    {
        [Fact]
        public async Task Handle_WithExistingSistema_ReturnsTrue()
        {
            var fixture = new Fixture();
            var request = fixture.Create<UpdateSistemaCommand>();

            var serviceMock = new Mock<ISistemaService>();

            var item = request.Adapt<Sistema>();

            serviceMock
                .Setup(r => r.UpdateSistemaAsync(item))
                .ReturnsAsync(true);

            var handler = new UpdateSistemaCommandHandler(serviceMock.Object);
            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsType<bool>(result);

        }
    }
}
