using Microsoft.EntityFrameworkCore;
using LibaryDataBase.Data;

namespace LibaryDataBase.Data
{
    public static class SeedDataBooks
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context == null || context.Book == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }


                if (context.Book.Any())
                {
                    return;
                }

                context.Book.AddRange(
                    new Book
                    {
                        isbnID = "1231",
                        Title = "When Harry Met Sally",
                        Author = "Logan Paul",
                        Field = "Romantic Comedy",
                        PublishDate = DateTime.Parse("1989-2-12"),
                        PageCount = 304,
                    
           
                    },

                    new Book
                    {
                       isbnID = "2341",
                        Title = "Ghostbusters",
                        Author = "Harry Potter",
                        Field = "Comedy",
                        PublishDate = DateTime.Parse("1999-3-9"),
                        PageCount = 200,
                        
                    },

                    new Book
                    {
                        isbnID = "2342",
                        Title = "Rio Bravo",
                        Author = "Jake Lake",
                        Field = "Western",
                        PublishDate = DateTime.Parse("2000-10-14"),
                        PageCount = 234,
                        
                    },

                    new Book
                    {
                        isbnID = "3121",
                        Title = "Transformers",
                        Author = "Michael Bay",
                        Field = "Action",
                        PublishDate = DateTime.Parse("2011-11-7"),
                        PageCount = 501,
                        
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
