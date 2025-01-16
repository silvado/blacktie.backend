using Application.Helpers;
using System.Security.Cryptography;
using System.Text;

namespace Tests.Helpers
{
    public class HashHelperTests
    {
        private readonly HashHelper _hashHelper;

        public HashHelperTests()
        {
            _hashHelper = new HashHelper();
        }

        [Fact]
        public void HashMD5_ShouldReturnExpectedHash_ForGivenInput()
        {
            // Arrange
            var input = "TestString";
            var expectedHash = CalculateMD5Hash(input);

            // Act
            var result = _hashHelper.HashMD5(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedHash, result);
        }

        [Fact]
        public void HashSHA256_ShouldReturnExpectedHash_ForGivenInput()
        {
            // Arrange
            var input = "TestString";
            var expectedHash = CalculateSHA256Hash(input);

            // Act
            var result = _hashHelper.HashSHA256(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedHash, result);
        }

        private string CalculateMD5Hash(string input)
        {
            using MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        private string CalculateSHA256Hash(string input)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
