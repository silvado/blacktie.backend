using Application.Contracts.Sistema;
using Application.Queries.GetSistemaConfig;
using AutoFixture;
using Domain.Exceptions;
using Domain.Interfaces.Service;
using Domain.Models;
using Moq;

namespace Tests.Queries
{
    public class GetSistemaConfigHandlerTests
    {
        private readonly Mock<ISistemaService> _mockService;
        private readonly GetSistemaConfigHandler _handler;
        private readonly Fixture _fixture;

        public GetSistemaConfigHandlerTests()
        {
            _mockService = new Mock<ISistemaService>();
            _handler = new GetSistemaConfigHandler(_mockService.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Handle_WhenSistemaNotFound_ReturnsNull()
        {
            // Arrange
            var request = _fixture.Create<GetSistemaConfigQuery>();

            // Mocking the service to return null for GetSistemaBySiglaAsync
            _mockService
                .Setup(s => s.GetSistemaBySiglaAsync())
                .ReturnsAsync((Sistema?)null);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(result);
            _mockService.Verify(s => s.GetSistemaBySiglaAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenConfiguracaoIsNull_ThrowsSapiconfigNotAcceptableException()
        {
            // Arrange
            var request = _fixture.Create<GetSistemaConfigQuery>();

            // Criação do objeto Sistema
            var sistema = _fixture.Create<Sistema>();
            sistema.Configuracao = null; // Configuração explícita como null

            _mockService
                .Setup(s => s.GetSistemaBySiglaAsync())
                .ReturnsAsync(sistema);

            // Act & Assert
            await Assert.ThrowsAsync<BlacktieNotAcceptableException>(() => _handler.Handle(request, CancellationToken.None));
            _mockService.Verify(s => s.GetSistemaBySiglaAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenConfiguracaoIsInvalid_ThrowsSapiconfigNotAcceptableException()
        {
            // Arrange
            var request = _fixture.Create<GetSistemaConfigQuery>();
            var sistema = _fixture.Build<Sistema>()
                .With(s => s.Configuracao, "InvalidConfig")
                .Create();

            _mockService
                .Setup(s => s.GetSistemaBySiglaAsync())
                .ReturnsAsync(sistema);

            _mockService
                .Setup(s => s.IsValidJson(It.IsAny<string>()))
                .Returns(false); // Simulate an invalid JSON

            // Act & Assert
            await Assert.ThrowsAsync<BlacktieNotAcceptableException>(() => _handler.Handle(request, CancellationToken.None));
            _mockService.Verify(s => s.GetSistemaBySiglaAsync(), Times.Once);
            _mockService.Verify(s => s.IsValidJson(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenConfiguracaoIsValid_ReturnsMappedSistemaConfigDto()
        {
            // Arrange
            var request = _fixture.Create<GetSistemaConfigQuery>();
            var sistema = _fixture.Build<Sistema>()
                .With(s => s.Configuracao, "{\"key\":\"value\"}") // Valid JSON
                .Create();

            _mockService
                .Setup(s => s.GetSistemaBySiglaAsync())
                .ReturnsAsync(sistema);

            _mockService
                .Setup(s => s.IsValidJson(It.IsAny<string>()))
                .Returns(true); // Simulate a valid JSON

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SistemaConfigDto>(result);            
            _mockService.Verify(s => s.GetSistemaBySiglaAsync(), Times.Once);
            _mockService.Verify(s => s.IsValidJson(It.IsAny<string>()), Times.Once);
        }
    }
}
