using Data;
using Domain;
using Facade;

namespace Rakendus.Facade.Party{
    public class ReaderViewFactory {
        public Reader Create(ReaderView v) => new(new ReaderData
        {
            ID = v.ID,
            FirstName = v.FirstName,
            LastName = v.LastName,
            DoB = v.DoB,
            Gender = v.Gender,
            City = v.City,
            HomeAddress = v.HomeAddress,
            Education = v.Education,
            Telephone = v.Telephone });
        public ReaderView Create(Reader o) => new()
        {
            ID = o.ID,
            FirstName = o.FirstName,
            LastName = o.LastName,
            DoB = o.DoB,
            Gender = o.Gender,
            City = o.City,
            HomeAddress = o.HomeAddress,
            Education = o.Education,
            Telephone = o.Telephone,
            ReaderFullName = o.ToString()
        };
    }
}
 