using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using SuggestService.DataAccess.Interfaces;
using SuggestService.Domain.Models;
using SuggestService.Domain.Results.Enums;
using SuggestService.Tests.Utils;
using Xunit;

namespace SuggestService.Tests.UnitTests.SuggestServiceTests
{
    public class WhenSuggestServiceGetSuggests
    {
        [Theory]
        [MemberData(nameof(SuggestParameterGenerator.GetSuggests), MemberType = typeof(SuggestParameterGenerator))]
        public async Task GetSuggest_ReturnSuggest(string[] suggests)
        {
            var repoMock = new Mock<ISuggestRepository>();
            repoMock.Setup(c => c.GetSuggestsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => suggests.Select(c=> new Suggest(){Suggestion = c}).ToArray());

            var service = new Services.SuggestService(repoMock.Object);

            var result = await service.GetSuggestsAsync("input", CancellationToken.None);

            result.Data.Should().BeEquivalentTo(suggests);
        }

        [Fact]
        public async Task GetSuggest_ReturnError()
        {
            var repoMock = new Mock<ISuggestRepository>();
            repoMock.Setup(c => c.GetSuggestsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).Throws<Exception>();

            var service = new Services.SuggestService(repoMock.Object);

            var result = await service.GetSuggestsAsync("input", CancellationToken.None);

            result.Value.Should().BeEquivalentTo(SuggestServiceResult.Error);
        }
    }
}
