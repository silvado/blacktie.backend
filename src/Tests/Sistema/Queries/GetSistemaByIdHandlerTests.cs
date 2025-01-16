using Application.Contracts;
using Application.Queries.GetSistemaById;
using AutoFixture;
using Domain.Interfaces.Service;
using Domain.Models;
using Moq;

namespace Tests.Queries
{
    public class GetSistemaByIdHandlerTests
    {
        [Fact]
        public async Task Handle_WithResults_ReturnsSistemaById()
        {
            // Arrange
            var fixture = new Fixture();
            var request = fixture.Create<GetSistemaByIdQuery>();

            var sistema = fixture.Create<Sistema>(); 
                        
            var repositoryMock = new Mock<ISistemaService>();
            
            repositoryMock
                .Setup(r => r.GetSistemaByIdAsync(request.id))
                .ReturnsAsync(sistema);

            var handler = new GetSistemaByIdHandler(repositoryMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SistemaDto>(result);
            repositoryMock.Verify(r => r.GetSistemaByIdAsync(request.id), Times.Once);

        }

        [Fact]
        public async Task Handle_WhenSistemaIsNull_ReturnsNull()
        {
            // Arrange
            var fixture = new Fixture();
            var request = fixture.Create<GetSistemaByIdQuery>();

            // Mock para retornar null para o GetSistemaByIdAsync
            var repositoryMock = new Mock<ISistemaService>();
            repositoryMock
                .Setup(r => r.GetSistemaByIdAsync(request.id))
                .ReturnsAsync((Sistema?)null); // Simula o retorno null

            var handler = new GetSistemaByIdHandler(repositoryMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(result); // Agora, o resultado será null
            repositoryMock.Verify(r => r.GetSistemaByIdAsync(request.id), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenSistemaIsEmpty_ReturnsNull()
        {
            // Arrange
            var fixture = new Fixture();
            var request = fixture.Create<GetSistemaByIdQuery>();            
                        
            var repositoryMock = new Mock<ISistemaService>();

            repositoryMock
                .Setup(r => r.GetSistemaByIdAsync(request.id))
                .ReturnsAsync(new Sistema()); // Retorna vazio

            var handler = new GetSistemaByIdHandler(repositoryMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(result);
            repositoryMock.Verify(r => r.GetSistemaByIdAsync(request.id), Times.Once);
        }
    }
}
