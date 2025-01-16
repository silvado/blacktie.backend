using Application.Contracts;
using Application.Queries.GetSistema;
using Application.Queries.GetSistemaPublicacao;
using AutoFixture;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;
using Moq;

namespace Tests.Queries
{
    public class GetSistemaHandlerTests
    {
        private readonly Mock<ISistemaService> _mockService;
        private readonly Fixture _fixture;
        private readonly GetSistemaHandler _handler;

        public GetSistemaHandlerTests()
        {
            _mockService = new Mock<ISistemaService>();
            _fixture = new Fixture();
            _handler = new GetSistemaHandler(_mockService.Object);
        }

        [Fact]
        public async Task Handle_WhenServiceReturnsPagedList_ReturnsMappedPagedList()
        {
            // Arrange
            var fixture = new Fixture();

            // Parâmetros para o filtro
            var queryParameters = fixture.Create<GetSistemaParameters>();
            queryParameters.PageNumber = 1; // Ajuste valores específicos
            queryParameters.PageSize = 10;

            var query = new GetSistemaQuery(queryParameters);

            // Filtro que será passado para o serviço
            var expectedFilter = queryParameters.Adapt<SistemaFilter>();

            // Lista de resultados simulada
            var sistemaList = fixture.CreateMany<Sistema>(5).ToList();

            // PagedList simulada
            var pagedList = new PagedList<Sistema>(
                sistemaList, sistemaList.Count, expectedFilter.PageNumber, expectedFilter.PageSize
            );

            // Mock do serviço
            var mockService = new Mock<ISistemaService>();
            mockService
                .Setup(s => s.GetFilteredAsync(It.Is<SistemaFilter>(f =>
                    f.PageNumber == expectedFilter.PageNumber &&
                    f.PageSize == expectedFilter.PageSize
                )))
                .ReturnsAsync(pagedList);

            var handler = new GetSistemaHandler(mockService.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(pagedList.TotalCount, result.TotalCount);
            Assert.Equal(pagedList.Data.Count, result.Data.Count);
            mockService.Verify(s => s.GetFilteredAsync(It.IsAny<SistemaFilter>()), Times.Once);
        }

        [Fact]
        public async Task Handle_NoResults_ReturnsNull()
        {
            // Arrange
            var queryParameters = _fixture.Create<GetSistemaParameters>();
            var query = new GetSistemaQuery(queryParameters);
                       

            // Configuração do mock para retornar null
            _mockService
                .Setup(s => s.GetFilteredAsync(It.IsAny<SistemaFilter>())) // Aceita qualquer SistemaFilter
                .ReturnsAsync((PagedList<Sistema>?)null);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Null(result);

            // Verifica que o método foi chamado ao menos uma vez com qualquer SistemaFilter
            _mockService.Verify(s => s.GetFilteredAsync(It.IsAny<SistemaFilter>()), Times.Once);
        }
    }
}
