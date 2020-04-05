using System.Linq;
using FluentAssertions;
using SuggestService.DataAccess.Translators;
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
