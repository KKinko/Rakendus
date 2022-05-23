using LibaryDataBase.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rakendus.Domain;
using Rakendus.Domain.Party;
using Rakendus.Infra;
using Rakendus.Infra.Initializers;
using Rakendus.Infra.Party;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<RakendusDb>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();

builder.Services.AddTransient<IBooksRepo, BooksRepo>();
builder.Services.AddTransient<IItemsRepo, ItemsRepo>();
builder.Services.AddTransient<ILoansRepo, LoansRepo>();
builder.Services.AddTransient<IReadersRepo, ReadersRepo>();
builder.Services.AddTransient<ICountriesRepo, CountriesRepo>();
builder.Services.AddTransient<ICurrenciesRepo, CurrenciesRepo>();
builder.Services.AddTransient<ICitiesRepo, CitiesRepo>(); 
builder.Services.AddTransient<ICountryCurrenciesRepo, CountryCurrenciesRepo>();
builder.Services.AddTransient<ILibariesRepo, LibariesRepo>();
builder.Services.AddTransient<IBooksAuthorsRepo, BooksAuthorsRepo>();
builder.Services.AddTransient<IAuthorsRepo, AuthorsRepo>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
using (var scope = app.Services.CreateScope())
{
    GetRepo.SetService(app.Services);
    var db = scope.ServiceProvider.GetService<RakendusDb>();
    db?.Database?.EnsureCreated();
    RakendusDbInitializer.Init(db);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
