using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PokemonApp.Tests
{
    public class PokemonApiTests
    {
        [Fact]
        public async Task GetPokemon_ValidName_ReturnsPokemon()
        {
            // Arrange
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            // Mock the protected SendAsync method
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"name\":\"pikachu\",\"height\":4,\"weight\":60}"),
                })
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://pokeapi.co/api/v2/")
            };

            // Act
            var response = await httpClient.GetAsync("pokemon/pikachu");

            // Assert
            Assert.True(response.IsSuccessStatusCode);

            // Verify that the mocked method was called
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(1), // Ensure the method was called once
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            );
        }
    }
}