using Application.Commands.DeleteSistema;
using AutoFixture;
using Domain.Interfaces.Service;
using Moq;

namespace Tests.Commands
{
    public class DeleteSistemaCommandHandlerTests
    {
        [Fact]
        public async Task Handle_WithExistingSistema_ReturnsTrue()
        {
            var fixture = new Fixture();
            var request = fixture.Create<DeleteSistemaCommand>();

            var serviceMock = new Mock<ISistemaService>();

            serviceMock
                .Setup(r => r.DeleteSistemaAsync(request.id))
                .ReturnsAsync(true);

            var handler = new DeleteSistemaCommandHandler(serviceMock.Object);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.True(result);

            serviceMock.Verify(r => r.DeleteSistemaAsync(It.IsAny<int>()), Times.Once);

        }
    }
}
