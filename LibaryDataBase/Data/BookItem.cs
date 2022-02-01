using System.ComponentModel.DataAnnotations;

namespace LibaryDataBase.Data
{
    public class BookItem
    {
        [Key]
        public string BookID { get; set; }

        public string? Libary { get; set; }
    }
}
