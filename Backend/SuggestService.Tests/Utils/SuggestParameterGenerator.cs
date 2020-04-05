using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using Moq;

namespace SuggestService.Tests.Utils
{
    public class SuggestParameterGenerator
    {
        public static IEnumerable<object[]> GetSuggests()
        {
            var faker = new Faker();

            yield return new object[] { faker.Random.WordsArray(1) };
            yield return new object[] { faker.Random.WordsArray(3) };
            yield return new object[] { faker.Random.WordsArray(5) };
            yield return new object[] { faker.Random.WordsArray(20) };
            yield return new object[] { faker.Random.WordsArray(150) };
        }
    }
}
