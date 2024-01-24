//using GameShop.Data;
//using GameShop.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace GameShop
//{
//    public class Seed
//    {
//        private readonly GameShopContext dataContext;

//        public Seed(GameShopContext context)
//        {
//            this.dataContext = context;
//        }

//        public void SeedDataContext()
//        {
//            if (!dataContext.GameOrders.Any())
//            {
//                var categories = new List<Category>
//                {
//                    new Category { CategoryName = "Action" },
//                    new Category { CategoryName = "Adventure" },
//                    new Category { CategoryName = "Simulation" },
//                };

//                var producers = new List<Producer>
//                {
//                    new Producer
//                    {
//                        ProducerName = "CD Projekt",
//                        ProducerDescrip = "Polish video game developer",
//                        ProducerCountry = "Poland",
//                        Games = new List<Game>
//                        {
//                            new Game
//                            {
//                                Title = "Witcher 3: Wild Hunt",
//                                Platform = "PC",
//                                Language = "Polish",
//                                Price = 59.99m,
//                                PEGI = "18+",
//                                Reviews = new List<Review>
//                                {
//                                    new Review
//                                    {
//                                        Title = "Amazing Game",
//                                        Text = "One of the best RPGs ever!",
//                                        Rating = 5,
//                                        Reviewer = new Reviewer
//                                        {
//                                            FirstName = "John",
//                                            LastName = "Doe"
//                                        }
//                                    }
//                                },
//                                //GameCategories = new List<GameCategory>
//                                //{
//                                //    new GameCategory { Category = categories[0] }
//                                //}
//                            },
//                            new Game
//                            {
//                                Title = "Cyberpunk 2077",
//                                Platform = "PC",
//                                Language = "Polish",
//                                Price = 49.99m,
//                                PEGI = "18+",
//                                Reviews = new List<Review>
//                                {
//                                    new Review
//                                    {
//                                        Title = "Great but buggy",
//                                        Text = "Enjoyable despite some bugs.",
//                                        Rating = 4,
//                                        Reviewer = new Reviewer
//                                        {
//                                            FirstName = "Jane",
//                                            LastName = "Doe"
//                                        }
//                                    },
//                                    new Review // New Review: Cyberpunk 2077 Review by Mark Thompson
//                                    {
//                                        Title = "Impressive World",
//                                        Text = "Despite the initial issues, the game's world is breathtaking.",
//                                        Rating = 4,
//                                        Reviewer = new Reviewer
//                                        {
//                                            FirstName = "Mark",
//                                            LastName = "Thompson"
//                                        }
//                                    }
//                                },
//                                //GameCategories = new List<GameCategory>
//                                //{
//                                //    new GameCategory { Category = categories[1] } // Assuming Adventure category
//                                //}
//                            }
//                        }
//                    },
//                    new Producer // New Producer: Ubisoft
//                    {
//                        ProducerName = "Ubisoft",
//                        ProducerDescrip = "French video game company",
//                        ProducerCountry = "France",
//                        Games = new List<Game>
//                        {
//                            new Game
//                            {
//                                Title = "Assassin's Creed Valhalla",
//                                Platform = "PlayStation",
//                                Language = "English",
//                                Price = 69.99m,
//                                PEGI = "18+",
//                                Reviews = new List<Review>
//                                {
//                                    new Review
//                                    {
//                                        Title = "Epic Adventure",
//                                        Text = "Fantastic open-world experience!",
//                                        Rating = 5,
//                                        Reviewer = new Reviewer
//                                        {
//                                            FirstName = "Michael",
//                                            LastName = "Johnson"
//                                        }
//                                    }
//                                },
//                                //GameCategories = new List<GameCategory>
//                                //{
//                                //    new GameCategory { Category = categories[0] }
//                                //}
//                            }
//                        }
//                    }
//                };

//                ////var gameOrders = new List<GameOrder>
//                ////{
//                //    //new GameOrder
//                //    //{
//                //        Game = producers[0].Games.First(),
//                //        Order = new Order
//                //        {
//                //            OrderNumber = "1A",
//                //            //OrderDate = new DateOnly(2023, 1, 1),
//                //            OrderCost = 59.99m,
//                //            Client = new Client
//                //            {
//                //                Name = "Jack London",
//                //                PhoneNumber = "123456789",
//                //                Email = "jack.london@gmail.com",
//                //                Address = "Oleska 48",
//                //                PostalCode = "48-002",
//                //                City = "Opole",
//                //                Region = "Opolskie",
//                //                Country = "Poland"
//                //            }
//                //        },
//                //    //},
//                //    //new GameOrder
//                //    //{
//                //        Game = producers[0].Games.Last(),
//                //        Order = new Order
//                //        {
//                //            OrderNumber = "2A",
//                //            //OrderDate = new DateOnly(2023, 2, 15),
//                //            OrderCost = 49.99m,
//                //            Client = new Client
//                //            {
//                //                Name = "Alice Smith",
//                //                PhoneNumber = "987654321",
//                //                Email = "alice.smith@gmail.com",
//                //                Address = "Poznańska 23",
//                //                PostalCode = "12-345",
//                //                City = "Wrocław",
//                //                Region = "Dolnośląskie",
//                //                Country = "Poland"
//                //            }
//                //        },
//                //   // },
//                //    //new GameOrder // New Game Order: Another Order for Witcher 3
//                //    //{
//                //        Game = producers[0].Games.First(),
//                //        Order = new Order
//                //        {
//                //            OrderNumber = "3A",
//                //            //OrderDate = new DateOnly(2023, 3, 10),
//                //            OrderCost = 59.99m,
//                //            Client = new Client
//                //            {
//                //                Name = "Emily Wilson",
//                //                PhoneNumber = "111222333",
//                //                Email = "emily.wilson@gmail.com",
//                //                Address = "Gdańska 15",
//                //                PostalCode = "54-678",
//                //                City = "Gdańsk",
//                //                Region = "Pomorskie",
//                //                Country = "Poland"
//                //            }
//                //        },
//                //    //},
//                //};

//                //dataContext.Categories.AddRange(categories);
//                //dataContext.Producers.AddRange(producers);
//                //dataContext.GameOrders.AddRange(gameOrders);
//                dataContext.SaveChanges();
//            }
//        }
//    }
//}
