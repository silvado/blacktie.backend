using Application.Helpers;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;

namespace Tests.Helpers
{
    public class UserClaimsHelperTests
    {
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private readonly UserClaimsHelper _userClaimsHelper;

        public UserClaimsHelperTests()
        {
            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            _userClaimsHelper = new UserClaimsHelper(_httpContextAccessorMock.Object);
        }

        private void SetUpHttpContextWithClaims(IEnumerable<Claim> claims)
        {
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var httpContext = new DefaultHttpContext { User = claimsPrincipal };

            _httpContextAccessorMock.Setup(hca => hca.HttpContext).Returns(httpContext);
        }

        [Fact]
        public void GetUserName_ShouldReturnClaimValue_WhenClaimExists()
        {
            // Arrange
            SetUpHttpContextWithClaims(new List<Claim> { new Claim("NomeUsu", "John Doe") });

            // Act
            var result = _userClaimsHelper.GetUserName();

            // Assert
            Assert.Equal("John Doe", result);
        }

        [Fact]
        public void GetUserName_ShouldReturnEmptyString_WhenClaimDoesNotExist()
        {
            // Arrange
            SetUpHttpContextWithClaims(new List<Claim>());

            // Act
            var result = _userClaimsHelper.GetUserName();

            // Assert
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void GetUserCodUsu_ShouldReturnClaimValue_WhenClaimExists()
        {
            // Arrange
            SetUpHttpContextWithClaims(new List<Claim> { new Claim("CodUsu", "12345") });

            // Act
            var result = _userClaimsHelper.GetUserCodUsu();

            // Assert
            Assert.Equal("12345", result);
        }


        [Fact]
        public void GetUserAutorizacoes_ShouldReturnEmptyList_WhenClaimIsEmpty()
        {
            // Arrange
            SetUpHttpContextWithClaims(new List<Claim>());

            // Act
            var result = _userClaimsHelper.GetUserAutorizacoes();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetUserFromClaims_ShouldReturnCorrectUserSegWeb_WhenClaimsArePresent()
        {
            // Arrange
            var autorizacoesJson = "[{\"Id\":1,\"Nome\":\"Permissao1\"}]";
            SetUpHttpContextWithClaims(new List<Claim>
            {
                new Claim("NomeUsu", "John Doe"),
                new Claim("CodUsu", "12345"),
                new Claim("MatriculaUsu", "98765"),
                new Claim("IdFunc", "10"),
                new Claim("IpUsu", "192.168.0.1"),
                new Claim("Autorizacoes", autorizacoesJson)
            });

            // Act
            var result = _userClaimsHelper.GetUserFromClaims();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Autorizacoes); // Verifica explicitamente que 'Autorizacoes' não é null
            Assert.Equal("12345", result.CodUsu);
            Assert.Equal("John Doe", result.Nome);
            Assert.Equal("98765", result.Matricula);
            Assert.Equal(10, result.IDFunc);
            Assert.Equal("192.168.0.1", result.NomeMaquina);
            Assert.Single(result.Autorizacoes); // Agora está seguro acessar
        }


        [Fact]
        public void GetUserFromClaims_ShouldHandleMissingClaims()
        {
            // Arrange
            SetUpHttpContextWithClaims(new List<Claim>());

            // Act
            var result = _userClaimsHelper.GetUserFromClaims();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Autorizacoes);
            Assert.Equal(string.Empty, result.CodUsu);
            Assert.Equal(string.Empty, result.Nome);
            Assert.Equal(string.Empty, result.Matricula);
            Assert.Null(result.IDFunc);
            Assert.Equal(string.Empty, result.NomeMaquina);
            Assert.Empty(result.Autorizacoes);
        }
    }
}
