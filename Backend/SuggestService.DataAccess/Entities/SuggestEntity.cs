using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuggestService.DataAccess.Entities
{
    public class SuggestEntity
    {
        [Key]
        public string Suggestion { get; set; }
    }
}
