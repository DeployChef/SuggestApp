using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using SuggestService.DataAccess.Interfaces;
using SuggestService.DataAccess.Translators;
using SuggestService.Domain.Models;
using SuggestService.Entities;
using SuggestService.Tests.Utils;
using Xunit;

namespace SuggestService.Tests.UnitTests.TranslatorsTests
{
    public class WhenSuggestTranslator
    {
        [Theory]
        [MemberData(nameof(SuggestParameterGenerator.GetSuggests), MemberType = typeof(SuggestParameterGenerator))]
        public void TranslationSuggest_AllTranslated(string[] suggests)
        {
            var suggestEntities = suggests.Select(c => new SuggestEntity() {Suggestion = c}).ToList();

            foreach (var suggestEntity in suggestEntities)
            {
                var suggest = suggestEntity.ToModel();

                suggest.Suggestion.Should().BeEquivalentTo(suggestEntity.Suggestion);
            }
        }
    }
}
