using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LibaryDataBase.Data
{
    public class Book
    {
        [Key]
        public string isbnID { get; set; }


        [StringLength(60, MinimumLength = 3), Required]
        public string? Title { get; set; }
        
        
        [RegularExpression(@"^[A-Za-z]+[\s][A-Za-z]+[A-Za-z]+$"), Required]
        public string? Author { get; set; }
       

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Required, StringLength(30)]
        public string? Field { get; set; }


        [Display(Name = "Publish Date"), DataType(DataType.Date)]
        public DateTime? PublishDate { get; set; }
        
        
        [Display(Name = "Pages"), Required]
        public int? PageCount { get; set; }

    }
}
