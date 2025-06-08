using CourseWork.Data.Models;
using CourseWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseWork.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content), "Database context cannot be null.");
            }

            if (!content.Categories.Any())
            {
                foreach (Category category in Categories.Values)
                {
                    content.Categories.Add(category ?? throw new InvalidOperationException("Category is null."));
                }
            }

            if (!content.Games.Any())
            {
                List<Game> games = new List<Game>
                {
                    new Game
                    {
                        Name = "Cyberpunk 2077",
                        Description = "Футуристическая RPG с открытым миром.",
                        Price = 1999,
                        IsFavorite = true,
                        Category = Categories["Экшен"] ?? throw new InvalidOperationException("Category 'Экшен' is null.")
                    },
                    new Game
                    {
                        Name = "The Witcher 3: Wild Hunt",
                        Description = "Приключенческая RPG с захватывающим сюжетом.",
                        Price = 1499,
                        IsFavorite = true,
                        Category = Categories["Ролевые игры"] ?? throw new InvalidOperationException("Category 'Ролевые игры' is null.")
                    },
                    new Game
                    {
                        Name = "Minecraft",
                        Description = "Песочница для строительства и выживания.",
                        Price = 999,
                        IsFavorite = true,
                        Category = Categories["Экшен"] ?? throw new InvalidOperationException("Category 'Экшен' is null.")
                    },
                    new Game
                    {
                        Name = "Red Dead Redemption 2",
                        Description = "Захватывающий вестерн с открытым миром.",
                        Price = 2499,
                        IsFavorite = false,
                        Category = Categories["Экшен"] ?? throw new InvalidOperationException("Category 'Экшен' is null.")
                    },
                    new Game
                    {
                        Name = "Dark Souls III",
                        Description = "Темная и сложная RPG с жесткими боями.",
                        Price = 1299,
                        IsFavorite = false,
                        Category = Categories["Ролевые игры"] ?? throw new InvalidOperationException("Category 'Ролевые игры' is null.")
                    },
                    new Game
                    {
                        Name = "Grand Theft Auto V",
                        Description = "Криминальный боевик с открытым миром.",
                        Price = 1799,
                        IsFavorite = true,
                        Category = Categories["Экшен"] ?? throw new InvalidOperationException("Category 'Экшен' is null.")
                    },
                    new Game
                    {
                        Name = "Mass Effect Legendary Edition",
                        Description = "Космическая эпопея с глубокой историей.",
                        Price = 1699,
                        IsFavorite = false,
                        Category = Categories["Ролевые игры"] ?? throw new InvalidOperationException("Category 'Ролевые игры' is null.")
                    },
                    new Game
                    {
                        Name = "Assassin's Creed Valhalla",
                        Description = "Исторический экшен с элементами RPG.",
                        Price = 2199,
                        IsFavorite = false,
                        Category = Categories["Экшен"] ?? throw new InvalidOperationException("Category 'Экшен' is null.")
                    },
                    new Game
                    {
                        Name = "Final Fantasy XV",
                        Description = "Японская RPG с красивым миром и динамичными боями.",
                        Price = 1899,
                        IsFavorite = true,
                        Category = Categories["Ролевые игры"] ?? throw new InvalidOperationException("Category 'Ролевые игры' is null.")
                    },
                    new Game
                    {
                        Name = "Fortnite",
                        Description = "Популярная многопользовательская игра с элементами строительства.",
                        Price = 1999,
                        IsFavorite = true,
                        Category = Categories["Экшен"] ?? throw new InvalidOperationException("Category 'Экшен' is null.")
                    }
                };

                foreach (Game game in games)
                {
                    content.Games.Add(game ?? throw new InvalidOperationException("Game is null."));
                }
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    Category[] list = new Category[] {
                        new Category {
                            CategoryName = "Экшен",
                            Description = "Динамичные игры с акцентом на боевые действия."
                        } ?? throw new InvalidOperationException("Category 'Экшен' is null."),
                        new Category {
                            CategoryName = "Ролевые игры",
                            Description = "Глубокие истории и развитие персонажей."
                        } ?? throw new InvalidOperationException("Category 'Ролевые игры' is null.")
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category element in list)
                    {
                        category.Add(element?.CategoryName ?? throw new InvalidOperationException("Category name is null."), element);
                    }
                }

                return category;
            }
        }
    }
}