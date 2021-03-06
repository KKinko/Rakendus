using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Tests.LibaryDatabase;

public abstract class PagesTests : HostTests
{
}
    [TestClass] public class IndexPagesTests: PagesTests {

    [TestMethod] public async Task GetCountriesIndexPageTest() {
        int cnt;
        var d = addRandomItems<ICountriesRepo, Country, CountryData>(out cnt, x => new Country(x));
        var page = await client.GetAsync("/Countries?handler=Index");
        areEqual(HttpStatusCode.OK, page.StatusCode);
        var html = await page.Content.ReadAsStringAsync();
        isTrue(html.Contains("<h1>Countries</h1>"));
    }
    [TestMethod] public async Task GetCurrenciesIndexPageTest() {
        int cnt;
        var d = addRandomItems<ICurrenciesRepo, Currency, CurrencyData>(out cnt, x => new Currency(x));
        var page = await client.GetAsync("/Currencies?handler=Index");
        areEqual(HttpStatusCode.OK, page.StatusCode);
        var html = await page.Content.ReadAsStringAsync();
        isTrue(html.Contains("<h1>Currencies</h1>"));
    }
    [TestMethod] public async Task GetReadersIndexPageTest() {
        var page = await client.GetAsync("/Readers?handler=Index");
        areEqual(HttpStatusCode.OK, page.StatusCode);
        var html = await page.Content.ReadAsStringAsync();
        isTrue(html.Contains("<h1>Log in</h1>"));
    }

    [TestMethod]  public async Task GetCountriesDetailedPageTest() {
        int cnt;
        var id = GetRandom.String();
        var d = addRandomItems<ICountriesRepo, Country, CountryData>(out cnt, x => new Country(x), id);
        isNotNull(d);
        isNotNull(d.Name);
        isNotNull(d.Description);
        var page = await client.GetAsync($"/Countries/Details?handler=Details&id={id}&order=&idx=0&filter=");
        areEqual(HttpStatusCode.OK, page.StatusCode);
        var html = await page.Content.ReadAsStringAsync();
        isTrue(html.Contains("<h1>Details</h1>"));
        isTrue(html.Contains(id));
        isTrue(html.Contains(d.Code));
        isTrue(html.Contains(d.Name));
        isTrue(html.Contains(d.Description));
    }
}
