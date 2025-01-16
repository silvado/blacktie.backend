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
    public class GetSistemaPublicacaoHandlerTests
    {

        [Fact]
        public async Task Handle_WhenServiceReturnsPagedList_ReturnsMappedPagedList()
        {
            // Arrange
            var fixture = new Fixture();

            // Parâmetros para o filtro
            var queryParameters = fixture.Create<GetSistemaPublicacaoParameters>();
            queryParameters.PageNumber = 1; // Ajuste valores específicos
            queryParameters.PageSize = 10;

            var query = new GetSistemaPublicacaoQuery(queryParameters);

            // Filtro que será passado para o serviço
            var expectedFilter = queryParameters.Adapt<SistemaPublicacaoFilter>();

            // Lista de resultados simulada
            var sistemaPublicacaoList = fixture.CreateMany<SistemaPublicacao>(5).ToList();

            // PagedList simulada
            var pagedList = new PagedList<SistemaPublicacao>(
                sistemaPublicacaoList, sistemaPublicacaoList.Count, expectedFilter.PageNumber, expectedFilter.PageSize
            );

            // Mock do serviço
            var mockService = new Mock<ISistemaPublicacaoService>();
            mockService
                .Setup(s => s.GetFilteredAsync(It.Is<SistemaPublicacaoFilter>(f =>
                    f.PageNumber == expectedFilter.PageNumber &&
                    f.PageSize == expectedFilter.PageSize
                )))
                .ReturnsAsync(pagedList);

            var handler = new GetSistemaPublicacaoHandler(mockService.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(pagedList.TotalCount, result.TotalCount);
            Assert.Equal(pagedList.Data.Count, result.Data.Count);
            mockService.Verify(s => s.GetFilteredAsync(It.IsAny<SistemaPublicacaoFilter>()), Times.Once);
        }


        [Fact]
        public async Task Handle_WhenServiceReturnsNull_ReturnsNull()
        {
            // Arrange
            var fixture = new Fixture();

            // Parâmetros para o filtro
            var queryParameters = fixture.Create<GetSistemaPublicacaoParameters>();
            queryParameters.PageNumber = 1; // Ajuste valores específicos
            queryParameters.PageSize = 10;

            var query = new GetSistemaPublicacaoQuery(queryParameters);

            // Filtro que será passado para o serviço
            var expectedFilter = queryParameters.Adapt<SistemaPublicacaoFilter>();

            // Mock do serviço simulando retorno null
            var mockService = new Mock<ISistemaPublicacaoService>();
            mockService
                .Setup(s => s.GetFilteredAsync(It.Is<SistemaPublicacaoFilter>(f =>
                    f.PageNumber == expectedFilter.PageNumber &&
                    f.PageSize == expectedFilter.PageSize
                )))
                .ReturnsAsync((PagedList<SistemaPublicacao>?)null);

            var handler = new GetSistemaPublicacaoHandler(mockService.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Null(result); // Verifica se o resultado é nulo
            mockService.Verify(s => s.GetFilteredAsync(It.IsAny<SistemaPublicacaoFilter>()), Times.Once); // Verifica se o método foi chamado
        }

    }
}
