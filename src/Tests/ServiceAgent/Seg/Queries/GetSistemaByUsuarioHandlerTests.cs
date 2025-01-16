using Application.ServiceAgent.Seg.Queries.GetSistemaByUsuario;
using Domain.Interfaces.Helpers;
using Domain.Interfaces.ServiceAgent.DataContracts.Response;
using Domain.Interfaces.ServiceAgent;
using Moq;

namespace Tests.ServiceAgent.Seg.Queries
{
    public class GetSistemaByUsuarioHandlerTests
    {
        [Fact]
        public async Task Handle_WhenServiceReturnsData_ReturnsMappedList()
        {
            // Arrange
            var mockService = new Mock<ISegServiceAgent>();
            var mockUserClaimsHelper = new Mock<IUserClaimsHelper>();

            // Dados simulados
            var userCodUsu = "12345";
            mockUserClaimsHelper.Setup(helper => helper.GetUserCodUsu()).Returns(userCodUsu);

            var segResponse = new OperationResponse<SegResponse>
            {
                Data = new SegResponse
                {
                    Sistemas = new List<SegSistema>
                {
                    new SegSistema { CodSistema = 1, SiglaSistema = "SYS1", NomeSist = "Sistema 1" },
                    new SegSistema { CodSistema = 2, SiglaSistema = "SYS2", NomeSist = "Sistema 2" }
                }
                },
                StatusCode = 200
            };

            mockService.Setup(service => service.GetSistemaByUsuario(userCodUsu))
                       .ReturnsAsync(segResponse);

            var handler = new GetSistemaByUsuarioHandler(mockService.Object, mockUserClaimsHelper.Object);

            // Act
            var result = await handler.Handle(new GetSistemaByUsuarioQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count); // Verifica se a lista tem dois itens
            Assert.Equal("SYS1", result[0].SiglaSistema); // Verifica o primeiro item
            Assert.Equal("SYS2", result[1].SiglaSistema); // Verifica o segundo item

            mockUserClaimsHelper.Verify(helper => helper.GetUserCodUsu(), Times.Once);
            mockService.Verify(service => service.GetSistemaByUsuario(userCodUsu), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenServiceReturnsNull_ReturnsNull()
        {
            // Arrange
            var mockService = new Mock<ISegServiceAgent>();
            var mockUserClaimsHelper = new Mock<IUserClaimsHelper>();

            var userCodUsu = "12345";
            mockUserClaimsHelper.Setup(helper => helper.GetUserCodUsu()).Returns(userCodUsu);

            mockService.Setup(service => service.GetSistemaByUsuario(userCodUsu))
                       .ReturnsAsync((OperationResponse<SegResponse>?)null);

            var handler = new GetSistemaByUsuarioHandler(mockService.Object, mockUserClaimsHelper.Object);

            // Act
            var result = await handler.Handle(new GetSistemaByUsuarioQuery(), CancellationToken.None);

            // Assert
            Assert.Null(result);

            mockUserClaimsHelper.Verify(helper => helper.GetUserCodUsu(), Times.Once);
            mockService.Verify(service => service.GetSistemaByUsuario(userCodUsu), Times.Once);
        }
    }
}
