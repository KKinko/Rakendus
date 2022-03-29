using Rakendus.Data;

namespace Rakendus.Domain
{
    public abstract class Entity
    {
        private const string defaultStr = "Undefined";
        private const bool defaultBool = false;
        private const int defaultInt = 0;
        private static DateTime defaultDate => DateTime.MinValue;
        protected static string getValue(string? v) => v ?? defaultStr;
        protected static bool getValue(bool? v) => v ?? defaultBool;
        protected static DateTime getValue(DateTime? v) => v ?? defaultDate;
        protected static int getValue(int? v) => v ?? defaultInt;

    }
    public abstract class Entity<TData> : Entity where TData : EntityData, new()
    {
        private readonly TData data;
        public TData Data => data;
        public Entity() : this(new TData()) { }
        public Entity(TData d) => data = d;
        public string ID => getValue(Data?.ID);

    }
}
