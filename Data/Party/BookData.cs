using System.ComponentModel.DataAnnotations;


namespace Rakendus.Data.Party
{
    public class BookData
    {
        [Key]
        public string IsbnID { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Field { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? PageCount { get; set; }
    }
}
