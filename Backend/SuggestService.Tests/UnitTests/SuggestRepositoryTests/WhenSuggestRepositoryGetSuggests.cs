using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using SuggestService.Tests.Utils;
using Xunit;

namespace SuggestService.Tests.UnitTests.SuggestRepositoryTests
{
    public class WhenSuggestRepositoryGetSuggests
    {
        //[Theory]
        //[MemberData(nameof(SuggestParameterGenerator.GetSuggests), MemberType = typeof(SuggestParameterGenerator))]
        //public async Task GetSuggest_ReturnOk(string[] suggests)
        //{

        //    //КОГДА НИБУДЬ OrmLite ЗАРАБОТАЕТ ДЛЯ ПОСТГРЕСА В ИНМЕМОРИ, ТОГДА И ВСЕ ЗАРАБОТАЕТ :))))


        //    //var suggest = suggests.Select(c => new SuggestEntity() {Suggestion = c}).ToList();
        //    //var db = new InMemoryDatabase();
        //    //db.Insert(suggest);

        //    //var connectionFactory = new Mock<IDbConnectionFactory>();
        //    //connectionFactory.Setup(c => c.Create()).Returns(() => db.OpenConnection());

        //    //var repository = new SuggestRepository(connectionFactory.Object);

        //    //var result = await repository.GetSuggestsAsync("input", CancellationToken.None);

        //    //result.Count.Should().BeLessOrEqualTo(10);
        //    //result.Select(c=>c.Suggestion).Should().BeEquivalentTo(suggests.Take(10));
        //}


        //КОГДА НИБУДЬ OrmLite ЗАРАБОТАЕТ ДЛЯ ПОСТГРЕСА В ИНМЕМОРИ, ТОГДА И ВСЕ ЗАРАБОТАЕТ :))))

        public class InMemoryDatabase
        {
            private readonly OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(":memory:", PostgreSqlDialect.Instance);

            public IDbConnection OpenConnection() => this.dbFactory.OpenDbConnection();

            public void Insert<T>(IEnumerable<T> items)
            {
                using (var db = this.OpenConnection())
                {
                    db.CreateTableIfNotExists<T>();
                    foreach (var item in items)
                    {
                        db.Insert(item);
                    }
                }
            }
        }
    }
}
