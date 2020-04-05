using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using SuggestService.Controllers;
using SuggestService.Domain.Results;
using SuggestService.Domain.Results.Enums;
using SuggestService.Tests.Utils.Builders;
using Xunit;

namespace SuggestService.Tests.UnitTests.SuggestControllerTests
{
    public class WhenSuggestControllerGetSuggests
    {
        [Fact]
        public async Task GetSuggest_ReturnOk()
        {
            var service = Create.SuggestService().Get();

            var controller = new SuggestController(service);

            var result = await controller.Suggest("input", CancellationToken.None);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetSuggest_ReturnConflict()
        {
            var serviceResult = new Result<SuggestServiceResult, IReadOnlyCollection<string>>(SuggestServiceResult.Error);
            var service = Create.SuggestService().SetResult(serviceResult).Get();

            var controller = new SuggestController(service);

            var result = await controller.Suggest("input", CancellationToken.None);

            result.Should().BeOfType<ConflictObjectResult>();
        }

        [Fact]
        public async Task GetSuggest_ReturnData()
        {
            var data = new[] {"a", "b", "c"};
            var serviceResult = new Result<SuggestServiceResult, IReadOnlyCollection<string>>(SuggestServiceResult.Ok, data);
            var service = Create.SuggestService().SetResult(serviceResult).Get();


            var controller = new SuggestController(service);

            var result = await controller.Suggest("input", CancellationToken.None);

            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(data);
        }
    }
}
