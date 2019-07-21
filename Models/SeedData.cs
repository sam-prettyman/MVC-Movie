using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MVCMovie.Models;
using MVCMovie;
using MvcMovie.Models;

namespace MVCMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVCMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MVCMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Emma Smith: My Story",
                        Rating = "G",
                        ReleaseDate = DateTime.Parse("2008-4-11"),
                        Genre = "Historical Drama",
                        Price = 10.99M

                    },

                    new Movie
                    {
                        Title = "The R.M. ",
                        Rating = "PG",
                        ReleaseDate = DateTime.Parse("2003-1-31"),
                        Genre = "Religous Comedy",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "The Singles 2nd Ward",
                        Rating = "PG",
                        ReleaseDate = DateTime.Parse("2007-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Mobsters and Mormons",
                        Rating = "PG",
                        ReleaseDate = DateTime.Parse("2005-4-15"),
                        Genre = "Western",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}