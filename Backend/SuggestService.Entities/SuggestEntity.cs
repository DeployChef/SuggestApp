using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuggestService.Entities
{
    [Table("suggest")]
    public class SuggestEntity
    {
        [Key]
        [Column("suggestion")]
        public string Suggestion { get; set; }
    }
}
