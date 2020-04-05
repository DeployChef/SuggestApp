using SuggestService.Domain.Models;
using SuggestService.Entities;

namespace SuggestService.DataAccess.Translators
{
    public static class SuggestTranslatorsExtensions
    {
        public static Suggest ToModel(this SuggestEntity entity)
        {
            return new Suggest
            {
                Suggestion = entity.Suggestion
            };
        }
    }
}
