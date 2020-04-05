using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Moq;
using SuggestService.Domain.Results;
using SuggestService.Domain.Results.Enums;
using SuggestService.Services;

namespace SuggestService.Tests.Utils.Builders
{
    public class SuggestServiceBuilder
    {
        private Mock<ISuggestService> _serviceMock;

        public SuggestServiceBuilder()
        {
            _serviceMock = new Mock<ISuggestService>();

            _serviceMock.Setup(c => c.GetSuggestsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => new Result<SuggestServiceResult, IReadOnlyCollection<string>>(SuggestServiceResult.Ok));
        }

        public SuggestServiceBuilder SetResult(Result<SuggestServiceResult, IReadOnlyCollection<string>> result)
        {
            _serviceMock.Setup(c => c.GetSuggestsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => result);
            return this;
        }


        public ISuggestService Get()
        {
            return _serviceMock.Object;
        }
    }
}
