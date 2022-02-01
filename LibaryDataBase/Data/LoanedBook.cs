using System.ComponentModel.DataAnnotations;

namespace LibaryDataBase.Data
{
    public class LoanedBook
    {
        [Key]
        public string LoanedID { get; set; }
        //public int ItemID { get; set; }
        //public int ReaderID { get; set; }
        //Display(Name = "Loaned Date")]
        public DateTime? LoanedDate { get; set; }
        //Display(Name = "Loaned Due")]
        public DateTime? LoanedDue { get; set; }
        //Display(Name = "Loaned Returned")]
        public DateTime? LoanedReturned { get; set; }

        public int? OverdueFine { get; set; }

        public bool? LoanedStatus { get; set; }
    }
}
