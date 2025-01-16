using Application.Commands.CreateSistema;
using Application.Contracts;
using Application.Contracts.Sistema;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;
using Moq;

namespace Tests.Commands
{
    public class CreateSistemaCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsSistemaCadastroDto()
        {
            // Arrange
            var mockService = new Mock<ISistemaService>();

            // Dados de entrada
            var sistemaRequest = new SistemaRequest
            {
                Id = 1,
                NomeSistema = "Sistema Teste",
                SiglaSistema = "ST",
                Configuracao = "Configuração Teste",
                ConfiguracaoPrevia = "Configuração Prévia Teste"
            };

            var sistemaCommand = new CreateSistemaCommand(sistemaRequest);

            // Objeto que o serviço deve receber após o mapeamento
            var expectedSistema = new Sistema
            {
                Id = sistemaRequest.Id,
                NomeSistema = sistemaRequest.NomeSistema,
                SiglaSistema = sistemaRequest.SiglaSistema,
                Configuracao = sistemaRequest.Configuracao,
                ConfiguracaoPrevia = sistemaRequest.ConfiguracaoPrevia
            };

            // Resultado esperado do serviço
            var sistemaCadastroDto = new SistemaCadastroDto
            {
                Id = 1,
                NomeSistema = "Sistema Teste",
                SiglaSistema = "ST"
            };

            // Configuração do mock
            mockService
                .Setup(service => service.CreateSistemaAsync(It.IsAny<Sistema>()))
                .ReturnsAsync(expectedSistema.Adapt<Sistema>());

            var handler = new CreateSistemaCommandHandler(mockService.Object);

            // Act
            var result = await handler.Handle(sistemaCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SistemaCadastroDto>(result);
            Assert.Equal(sistemaCadastroDto.Id, result.Id);
            Assert.Equal(sistemaCadastroDto.NomeSistema, result.NomeSistema);
            Assert.Equal(sistemaCadastroDto.SiglaSistema, result.SiglaSistema);

            // Verifica se o serviço foi chamado corretamente
            mockService.Verify(
                service => service.CreateSistemaAsync(It.Is<Sistema>(s =>
                    s.Id == expectedSistema.Id &&
                    s.NomeSistema == expectedSistema.NomeSistema &&
                    s.SiglaSistema == expectedSistema.SiglaSistema &&
                    s.Configuracao == expectedSistema.Configuracao &&
                    s.ConfiguracaoPrevia == expectedSistema.ConfiguracaoPrevia)),
                Times.Once);
        }
    }
}
