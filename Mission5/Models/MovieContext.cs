using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission5.Models
{
    public class MovieContext : DbContext
    {
        // Constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            //Leave blank
        }

        public DbSet<MovieEntry> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                );

            mb.Entity<MovieEntry>().HasData(
                new MovieEntry
                {
                    MovieID = 1,
                    CategoryId = 3,
                    Title = "High School Musical",
                    Year = 2006,
                    Director = "Kenny Ortega",
                    Rating = "G",
                },
                new MovieEntry
                {
                    MovieID = 2,
                    CategoryId = 3,
                    Title = "tick, tick...BOOM!",
                    Year = 2021,
                    Director = "Lin-Manuel Miranda",
                    Rating = "PG-13",
                },
                new MovieEntry
                {
                    MovieID = 3,
                    CategoryId = 4,
                    Title = "Tangled",
                    Year = 2010,
                    Director = "Nathan Greno",
                    Rating = "PG",
                }
            );
        }
    }
}
