using System.ComponentModel.DataAnnotations.Schema;

namespace articleApp.Data.Models
{
    public class Article : MainModel
    {
        public string CategoryId { get; set; }
        public string UserId { get; set; }
        public string MainTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Article")]
        public Category Category { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Article")]
        public User User { get; set; }

    }
}