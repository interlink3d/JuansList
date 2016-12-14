using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JuansList.Models;

namespace JuansList.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
              // Look for any categories.
              if (context.Category.Any())
              {
                  return;   // DB has been seeded
              }

            //   Categories to be populated
              var categories = new Category[]
              {
                  new Category { 
                      Name = "Roofing",
                      Description = "From minor repairs to full replacements."
                  },
                  new Category { 
                      Name = "Siding",
                      Description = "Vinyl, brick, or custom, it can be done."
                  },
                  new Category {
                      Name = "Windows",
                      Description = "All shapes, sizes, and price points."
                  },
                  new Category {
                      Name = "Gutters",
                      Description = "From minor repairs to full replacements"
                  },
                  new Category {
                      Name = "Lawncare",
                      Description = "We can do as much or as little as you want"
                  },
                  new Category {
                      Name = "Flooring",
                      Description = "From carpet to tile, we have you covered!"
                  },
                  new Category {
                      Name = "Framing",
                      Description = "Everything wall structure related including drywall"
                  },
                  new Category {
                      Name = "Wood Work",
                      Description = "From trim to custom closets and creative artwork"
                  },
                  new Category {
                      Name = "Painting",
                      Description = "From touchups to a full makeover"
                  },
              };
              foreach (Category i in categories)
              {
                  context.Category.Add(i);
              }
              context.SaveChanges();
          }
       }
    }
}