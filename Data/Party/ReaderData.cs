
namespace Rakendus.Data.Party
{
   public sealed class ReaderData : PersonData
   {
     public IsoGender? Gender { get; set; }
     public int? Telephone { get; set; }
     public string? CityID { get; set; }
     public string? HomeAddress { get; set; }
     public string? LoanedID { get; set; }
   } 
}