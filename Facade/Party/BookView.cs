

using Rakendus.Data.Party;
using System.ComponentModel.DataAnnotations;

namespace Rakendus.Facade.Party
{
    public class BookView
    {
        [Required] public string IsbnID { get; set; }
        [Display(Name = "Title")] public string? Title { get; set; }
        [Display(Name = "Author")]  public string? Author { get; set; }
        [Display(Name = "Field")]  public string? Field { get; set; }
        [Display(Name = "Publish date")] public DateTime? PublishDate { get; set; }
        [Display(Name = "Pages")] public int? PageCount { get; set; }
        [Display(Name = "Book")] public string? FullBookName { get; set; }

    }
}
