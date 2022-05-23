using Rakendus.Data;

namespace Rakendus.Domain
{
    public abstract class PersonEntity<TData> : UniqueEntity<TData> where TData : PersonData, new()
    {
        public PersonEntity() : this(new TData()) { }
        public PersonEntity(TData d) : base(d) { }
        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public DateTime DoB => getValue(Data?.DoB);
    }
}
