using BlazorApp_Healthy.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp_Healthy.Server.Data
{
    public class DataContext: DbContext
    
    {
            public DbSet<User> Users { get; set; }
            public DbSet<Recipe> Recipes { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Ingredient> Ingredients { get; set; }

            public DataContext(DbContextOptions<DataContext> options) : base(options)
            { 

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Seed data for Users
                modelBuilder.Entity<User>().HasData(
                    new User { Id = Guid.NewGuid(), FullName = "John Doe" },
                    new User { Id = Guid.NewGuid(), FullName = "Jane Smith" }
                );

                // Seed data for Categories
                modelBuilder.Entity<Category>().HasData(
                    new Category { Id = Guid.NewGuid(), TitleCategory = "Desserts" },
                    new Category { Id = Guid.NewGuid(), TitleCategory = "Main Courses" }
                );

                // Seed data for Ingredients
                modelBuilder.Entity<Ingredient>().HasData(
                    new Ingredient { Id = Guid.NewGuid(), Title = "Flour", Quantity = 1.0f, Unit = "kg" },
                    new Ingredient { Id = Guid.NewGuid(), Title = "Sugar", Quantity = 0.5f, Unit = "kg" }
                );

                // Seed data for Recipes
                modelBuilder.Entity<Recipe>().HasData(
                    new Recipe
                    {
                        Id = Guid.NewGuid(),
                        Name = "Chocolate Cake",
                        Description = "Delicious chocolate cake recipe",
                        Instructons = "Mix ingredients and bake",
                        ImagePath = "/img/recipes/chocolate_cake.jpg",

                        CategoryId = Guid.NewGuid(), // Assign category ID accordingly
                       
                        IngredientId = Guid.NewGuid() // Assign ingredient ID accordingly
                    },
                    new Recipe
                    {
                        Id = Guid.NewGuid(),
                        Name = "Grilled Chicken",
                        Description = "Juicy grilled chicken recipe",
                        Instructons = "Grill the chicken with spices",
                        ImagePath = "/img/recipes/grilled_chicken.jpg",

                        CategoryId = Guid.NewGuid(), // Assign category ID accordingly

                        IngredientId = Guid.NewGuid() // Assign ingredient ID accordingly
                    }
                );

            // Define foreign key relationships
        
            }
        }
    }

