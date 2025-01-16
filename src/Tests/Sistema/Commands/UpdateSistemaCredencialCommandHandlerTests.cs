using Application.Commands.UpdateSistemaCredencial;
using Application.Contracts.Sistema;
using Application.Contracts;
using AutoFixture;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;
using Moq;

namespace Tests.Commands
{
    public class UpdateSistemaCredencialCommandHandlerTests
    {
        private readonly Mock<ISistemaService> _mockService;
        private readonly Fixture _fixture;
        private readonly UpdateSistemaCredencialCommandHandler _handler;

        public UpdateSistemaCredencialCommandHandlerTests()
        {
            _mockService = new Mock<ISistemaService>();
            _fixture = new Fixture(); // Fixture para gerar dados
            _handler = new UpdateSistemaCredencialCommandHandler(_mockService.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_UpdatesAndReturnsSistemaCadastroDto()
        {
            // Arrange
            var sistemaRequest = _fixture.Create<SistemaRequest>();
            var updateCommand = new UpdateSistemaCredencialCommand(sistemaRequest);

            // Entidade existente retornada pelo método GetSistemaByIdAsync
            var existingSistema = _fixture.Build<Sistema>()
                .With(s => s.Id, sistemaRequest.Id) // Garante que o ID seja o mesmo do request
                .Create();

            // Resultado esperado após atualização
            var updatedSistema = _fixture.Create<Sistema>();
            var expectedResponse = updatedSistema.Adapt<SistemaCadastroDto>();

            // Configuração dos mocks
            _mockService
                .Setup(s => s.GetSistemaByIdAsync(sistemaRequest.Id))
                .ReturnsAsync(existingSistema);

            _mockService
                .Setup(s => s.UpdateSistemaCredencialAsync(It.IsAny<Sistema>()))
                .ReturnsAsync(updatedSistema);

            // Act
            var result = await _handler.Handle(updateCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SistemaCadastroDto>(result);
            Assert.Equal(expectedResponse.Id, result.Id);
            Assert.Equal(expectedResponse.NomeSistema, result.NomeSistema);
            Assert.Equal(expectedResponse.SiglaSistema, result.SiglaSistema);

            // Verifica chamadas dos serviços
            _mockService.Verify(s => s.GetSistemaByIdAsync(sistemaRequest.Id), Times.Once);
            _mockService.Verify(s => s.UpdateSistemaCredencialAsync(It.Is<Sistema>(s => s.Id == existingSistema.Id)), Times.Once);
        }
    }
}
