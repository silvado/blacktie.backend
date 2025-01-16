using Application.Contracts;
using Application.Queries.GetSistemaPublicacaoById;
using AutoFixture;
using Domain.Interfaces.Service;
using Domain.Models;
using Moq;

namespace Tests.Queries
{
    public class GetSistemaPublicacaoByIdHandlerTests
    {
        [Fact]
        public async Task Handle_WithResults_ReturnsSistemaById()
        {
            // Arrange
            var fixture = new Fixture();
            var request = fixture.Create<GetSistemaPublicacaoByIdQuery>();

            var sistema = fixture.Create<SistemaPublicacao>();

            var repositoryMock = new Mock<ISistemaPublicacaoService>();

            repositoryMock
                .Setup(r => r.GetByIdAsync(request.id))
                .ReturnsAsync(sistema);

            var handler = new GetSistemaPublicacaoByIdHandler(repositoryMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SistemaPublicacaoDto>(result);
            repositoryMock.Verify(r => r.GetByIdAsync(request.id), Times.Once);

        }

        [Fact]
        public async Task Handle_WhenSistemaIsNull_ReturnsNull()
        {
            // Arrange
            var fixture = new Fixture();
            var request = fixture.Create<GetSistemaPublicacaoByIdQuery>();

            // Mock para retornar null para o GetByIdAsync
            var repositoryMock = new Mock<ISistemaPublicacaoService>();
            repositoryMock
                .Setup(r => r.GetByIdAsync(request.id))
                .ReturnsAsync((SistemaPublicacao?)null); // Simula o retorno null

            var handler = new GetSistemaPublicacaoByIdHandler(repositoryMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(result); // Agora, o resultado será null
            repositoryMock.Verify(r => r.GetByIdAsync(request.id), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenSistemaIsEmpty_ReturnsNull()
        {
            // Arrange
            var fixture = new Fixture();
            var request = fixture.Create<GetSistemaPublicacaoByIdQuery>();          

            var repositoryMock = new Mock<ISistemaPublicacaoService>();

            repositoryMock
                .Setup(r => r.GetByIdAsync(request.id))
                .ReturnsAsync(new SistemaPublicacao()); // Retorna vazio

            var handler = new GetSistemaPublicacaoByIdHandler(repositoryMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(result);
            repositoryMock.Verify(r => r.GetByIdAsync(request.id), Times.Once);
        }
    }
}
