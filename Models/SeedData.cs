using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CLDV6211_ICE_Task_1.Models;

namespace CLDV6211_ICE_Task_1.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CLDV6211_ICE_Task_1Context(
                serviceProvider.GetRequiredService<DbContextOptions<CLDV6211_ICE_Task_1Context>>()))
            {
                // Look for any books.
                if (context.Book.Any())
                {
                    return; // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "The Great Gatsby",
                        Author = "F. Scott Fitzgerald",
                        Description = "A tragic love story set in the Jazz Age.",
                        ReleaseDate = DateTime.Parse("1925-04-10"),
                        Price = "250.99",
                        Genre = "Classic",
                        Rating = "4"
                    },
                    new Book
                    {
                        Title = "To Kill a Mockingbird",
                        Author = "Harper Lee",
                        Description = "A powerful novel about racial injustice in the American South.",
                        ReleaseDate = DateTime.Parse("1960-07-11"),
                        Price = "300.00",
                        Genre = "Classic",
                        Rating = "5"
                    },
                    new Book
                    {
                        Title = "1984",
                        Author = "George Orwell",
                        Description = "A dystopian novel about totalitarianism and surveillance.",
                        ReleaseDate = DateTime.Parse("1949-06-08"),
                        Price = "150.00",
                        Genre = "Science Fiction",
                        Rating = "4"
                    },
                    new Book
                    {
                        Title = "Pride and Prejudice",
                        Author = "Jane Austen",
                        Description = "A timeless romance novel set in Regency-era England.",
                        ReleaseDate = DateTime.Parse("1813-01-28"),
                        Price = "400.00",
                        Genre = "Romance",
                        Rating = "5"
                    },
                    new Book
                    {
                        Title = "The Catcher in the Rye",
                        Author = "J.D. Salinger",
                        Description = "A coming-of-age story about a teenage boy in New York City.",
                        ReleaseDate = DateTime.Parse("1951-07-16"),
                        Price = "200.00",
                        Genre = "Literary Fiction",
                        Rating = "4"
                    },
                    new Book
                    {
                        Title = "Moby-Dick",
                        Author = "Herman Melville",
                        Description = "An epic tale of obsession and revenge on the high seas.",
                        ReleaseDate = DateTime.Parse("1851-10-18"),
                        Price = "169.99",
                        Genre = "Adventure",
                        Rating = "4"
                    },
                    new Book
                    {
                        Title = "The Lord of the Rings",
                        Author = "J.R.R. Tolkien",
                        Description = "A fantasy epic about a quest to destroy a powerful ring.",
                        ReleaseDate = DateTime.Parse("1954-07-29"),
                        Price = "259.99",
                        Genre = "Fantasy",
                        Rating = "5"
                    },
                    new Book
                    {
                        Title = "Harry Potter and the Philosopher's Stone",
                        Author = "J.K. Rowling",
                        Description = "The first book in the magical Harry Potter series.",
                        ReleaseDate = DateTime.Parse("1997-06-26"),
                        Price = "500.00",
                        Genre = "Fantasy",
                        Rating = "5"
                    },
                    new Book
                    {
                        Title = "The Hobbit",
                        Author = "J.R.R. Tolkien",
                        Description = "A charming adventure about a hobbit on a journey to reclaim treasure.",
                        ReleaseDate = DateTime.Parse("1937-09-21"),
                        Price = "300.00",
                        Genre = "Fantasy",
                        Rating = "4"
                    },
                    new Book
                    {
                        Title = "The Hitchhiker's Guide to the Galaxy",
                        Author = "Douglas Adams",
                        Description = "A humorous science fiction series about an intergalactic journey.",
                        ReleaseDate = DateTime.Parse("1979-10-12"),
                        Price = "369.99",
                        Genre = "Science Fiction",
                        Rating = "4"
                    },
                    new Book
                    {
                        Title = "The Hunger Games",
                        Author = "Suzanne Collins",
                        Description = "A dystopian novel set in a post-apocalyptic world.",
                        ReleaseDate = DateTime.Parse("2008-09-14"),
                        Price = "429.99",
                        Genre = "Young Adult",
                        Rating = "4"
                    },
                    new Book
                    {
                        Title = "The Da Vinci Code",
                        Author = "Dan Brown",
                        Description = "A thriller about a secret society and a hidden message in art.",
                        ReleaseDate = DateTime.Parse("2003-03-18"),
                        Price = "359.99",
                        Genre = "Mystery",
                        Rating = "4"
                    },
                    new Book
                    {
                        Title = "The Road",
                        Author = "Cormac McCarthy",
                        Description = "A post-apocalyptic novel about a father and son's journey.",
                        ReleaseDate = DateTime.Parse("2006-09-26"),
                        Price = "139.99",
                        Genre = "Literary Fiction",
                        Rating = "5"
                    },
                    new Book
                    {
                        Title = "Gone Girl",
                        Author = "Gillian Flynn",
                        Description = "A psychological thriller about a missing woman and a dark secret.",
                        ReleaseDate = DateTime.Parse("2012-06-05"),
                        Price = "129.99",
                        Genre = "Mystery",
                        Rating = "4"
                    },
                    new Book
                    {
                        Title = "The Girl with the Dragon Tattoo",
                        Author = "Stieg Larsson",
                        Description = "A gripping mystery featuring an enigmatic hacker and a journalist.",
                        ReleaseDate = DateTime.Parse("2005-08-23"),
                        Price = "150.50",
                        Genre = "Mystery",
                        Rating = "4"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
