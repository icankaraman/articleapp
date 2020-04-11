using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace articleApp.Data.Models
{
    public class Category
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [InverseProperty("Category")]
        public ICollection<Article> Articles { get; set; }
    }
}