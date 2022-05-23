using Rakendus.Data;
using Rakendus.Data.Party;

namespace Rakendus.Domain
{
    public abstract class UniqueEntity
    {
        public static string defaultStr = "Undefined";
        private const bool defaultBool = false;
        private const int defaultInt = 0;
        private static DateTime defaultDate => DateTime.MinValue;
        protected static string getValue(string? v) => v ?? defaultStr;
        protected static bool getValue(bool? v) => v ?? defaultBool;
        protected static IsoGender getValue(IsoGender? v) => v ?? IsoGender.NotApplicable;
        protected static DateTime getValue(DateTime? v) => v ?? defaultDate;
        public abstract string ID { get; }
        public abstract byte[] Token { get; }
        protected static int getValue(int? v) => v ?? defaultInt;

    }
    public abstract class UniqueEntity<TData> : UniqueEntity where TData : UniqueData, new()
    {
        public TData Data { get; }
        public UniqueEntity() : this(new TData()) { }
        public UniqueEntity(TData d) => Data = d;
        public override string ID => getValue(Data?.ID);
        public override byte[] Token => Data?.Token ?? Array.Empty<byte>();

    }
}
