namespace Rakendus.Infra.Initializers
{
    public static class RakendusDbInitializer
    {
        public static void Init(RakendusDb? db)
        {
            new BooksInitializer(db).Init();
            new ReadersInitializer(db).Init();
            new ItemsInitializer(db).Init();
            new LoanedInitializer(db).Init();
            new CountriesInitializer(db).Init();
            new CurrenciesInitializer(db).Init();
            new CitiesInitializer(db).Init();
            new CountryCurrenciesInitializer(db).Init();
        }
    }
}
