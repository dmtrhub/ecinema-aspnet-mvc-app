using ecinema_aspnet_mvc_app.Data.Enums;
using ecinema_aspnet_mvc_app.Models;
using System.IO;

namespace ecinema_aspnet_mvc_app.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Matthew McConaughey",
                            Bio = "This is the Bio of the Matthew McConaughey",
                            PictureUrl = "https://static1.purepeople.com/articles/4/82/77/4/@/650340-matthew-mcconaughey-580x0-3.jpg",
                            DateOfBirth = new DateTime(1969, 11, 4)

                        },
                        new Actor()
                        {
                            FullName = "Edward Norton",
                            Bio = "This is the Bio of the Edward Norton",
                            PictureUrl = "https://www.mojoba.de/wp-content/uploads/edward-norton.jpg.webp",
                            DateOfBirth = new DateTime(1969, 8, 18)

                        },
                        new Actor()
                        {
                            FullName = "Brad Pitt",
                            Bio = "This is the Bio of the Brad Pitt",
                            PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4c/Brad_Pitt_2019_by_Glenn_Francis.jpg/640px-Brad_Pitt_2019_by_Glenn_Francis.jpg",
                            DateOfBirth = new DateTime(1963, 12, 18)
                        },
                        new Actor()
                        {
                            FullName = "Leonardo DiCaprio",
                            Bio = "This is the Bio of the Leonardo DiCaprio",
                            PictureUrl = "https://flxt.tmsimg.com/assets/435_v9_bc.jpg",
                            DateOfBirth = new DateTime(1974, 11, 11)
                        },
                        new Actor()
                        {
                            FullName = "Matt Damon",
                            Bio = "This is the Bio of the Matt Damon",
                            PictureUrl = "https://m.media-amazon.com/images/M/MV5BMTM0NzYzNDgxMl5BMl5BanBnXkFtZTcwMDg2MTMyMw@@._V1_FMjpg_UX1000_.jpg",
                            DateOfBirth = new DateTime(1970, 10, 8)
                        },
                        new Actor()
                        {
                            FullName = "Tom Hanks",
                            Bio = "This is the Bio of the Tom Hanks",
                            PictureUrl = "https://m.media-amazon.com/images/M/MV5BMTQ2MjMwNDA3Nl5BMl5BanBnXkFtZTcwMTA2NDY3NQ@@._V1_FMjpg_UX1000_.jpg",
                            DateOfBirth = new DateTime(1956, 7, 9)
                        }
                    }); ;
                    context.SaveChanges();
                }

                //Cinemas
                if(!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cineplexx",
                            PictureUrl = "https://bg-gallery.s3.amazonaws.com/resident_cover/cineplexx/izlozi_sajt_5.png.1920x980_q75.png",
                            Description = "Cineplexx Belgrade description."
                        },
                        new Cinema()
                        {
                            Name = "CineStar Big",
                            PictureUrl = "https://www.mojnovisad.com/files/_thumb/600x400/news/5/8/9/10589/10589-cinestar-bioskop-big-trzni-centar.jpg",
                            Description = "CineStar Big Shopping Center description."
                        },
                        new Cinema()
                        {
                            Name = "Cineplexx Promenada",
                            PictureUrl = "https://lh3.googleusercontent.com/p/AF1QipNC4qlSX3WF-3H5qrW3EEZca25oteODqeQVpKwu=s1360-w1360-h1020",
                            Description = $"Cineplexx Promenada description."
                        },
                        new Cinema()
                        {
                            Name = "Roda Cineplex",
                            PictureUrl = "https://lh3.googleusercontent.com/p/AF1QipOnaieyKNJuKaWTf7TVt7288F9rrOzZSJup6J97=s1360-w1360-h1020",
                            Description = "Roda Cineplex description."
                        },
                        new Cinema()
                        {
                            Name = "Bioskop Zvezda",
                            PictureUrl = "https://centarzakulturubor.org.rs/wp-content/uploads/2014/06/Bioskop-Zvezda-Bor.jpg",
                            Description = "Bioskop Zvezda description."
                        },
                    });
                    context.SaveChanges();
                };

                //Producers
                if(!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Quentin Tarantino",
                            Bio = "This is the Bio of the Quentin Tarantino",
                            PictureUrl = "https://resizing.flixster.com/oRX8YU-Oj8U7WDKJarl8RnxU1zk=/218x280/v2/https://flxt.tmsimg.com/assets/52431_v9_bb.jpg"
                        },
                        new Producer()
                        {
                            FullName = "David Fincher",
                            Bio = "This is the Bio of the David Fincher",
                            PictureUrl = "https://flxt.tmsimg.com/assets/74061_v9_ba.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Martin Scorsese",
                            Bio = "This is the Bio of the Martin Scorsese",
                            PictureUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Christopher Nolan",
                            Bio = "This is the Bio of the Christopher Nolan",
                            PictureUrl = "https://hips.hearstapps.com/hmg-prod/images/christopher-nolan-hands-and-footprints-ceremony.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Steven Spielberg",
                            Bio = "This is the Bio of the Steven Spielberg",
                            PictureUrl = "https://cdn.britannica.com/95/176995-050-609666E2/Steven-Spielberg-2013.jpg"
                        }
                    });

                    context.SaveChanges();
                }

                //Movies
                if(!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Title = "Fight Club",
                            Description = "This is the Fight Club movie description",
                            Price = 39.30,
                            PictureUrl = "https://resizing.flixster.com/0kbkzWG-fGf5yEZSmLw4VB_SpnQ=/206x305/v2/https://flxt.tmsimg.com/assets/p23069_p_v8_aa.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 2,
                            Category = MovieCategory.Drama
                        },
                        new Movie()
                        {
                            Title = "Once upon a time in Hollywood",
                            Description = "This is the Once upon a time in Hollywood movie description",
                            Price = 42.00,
                            PictureUrl = "https://m.media-amazon.com/images/M/MV5BOTg4ZTNkZmUtMzNlZi00YmFjLTk1MmUtNWQwNTM0YjcyNTNkXkEyXkFqcGdeQXVyNjg2NjQwMDQ@._V1_FMjpg_UX1000_.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 2,
                            ProducerId = 1,
                            Category = MovieCategory.Comedy
                        },
                        new Movie()
                        {
                            Title = "The Wolf of Wall Street",
                            Description = "This is the Wolf of Wall Street movie description",
                            Price = 35.50,
                            PictureUrl = "https://i.ytimg.com/vi/J788MZ2uIGA/movieposter_en.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 3,
                            Category = MovieCategory.Biography
                        },
                        new Movie()
                        {
                            Title = "Interstellar",
                            Description = "This is the Interstellar movie description",
                            Price = 40.40,
                            PictureUrl = "https://s3.amazonaws.com/nightjarprod/content/uploads/sites/130/2021/08/19085635/gEU2QniE6E77NI6lCU6MxlNBvIx-scaled.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 4,
                            Category = MovieCategory.SciFi
                        },
                        new Movie()
                        {
                            Title = "Saving Private Ryan",
                            Description = "This is the Saving Private Ryan movie description",
                            Price = 36.00,
                            PictureUrl = "https://m.media-amazon.com/images/M/MV5BZjhkMDM4MWItZTVjOC00ZDRhLThmYTAtM2I5NzBmNmNlMzI1XkEyXkFqcGdeQXVyNDYyMDk5MTU@._V1_FMjpg_UX1000_.jpg",
                            StartDate = DateTime.Now.AddDays(-8),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 5,
                            ProducerId = 5,
                            Category = MovieCategory.War
                        },
                        new Movie()
                        {
                            Title = "Catch me if you can",
                            Description = "This is the The Wolf of Wall Street movie description",
                            Price = 35.50,
                            PictureUrl = "https://m.media-amazon.com/images/M/MV5BNDQ1YmNmNDctMTZiZS00OGU3LWIyN2YtMWIwMmVhNDQ0MjY5XkEyXkFqcGdeQXVyMjQ0NzE0MQ@@._V1_.jpg",
                            StartDate = DateTime.Now.AddDays(4),
                            EndDate = DateTime.Now.AddDays(15),
                            CinemaId = 3,
                            ProducerId = 5,
                            Category = MovieCategory.Action
                        }
                    });

                    context.SaveChanges();
                }

                //Actos_Movies
                if(!context.Actors_Movies.Any())
                {
                    context.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            MovieId = 1,
                            ActorId = 2
                        },
                        new Actor_Movie()
                        {
                            MovieId = 1,
                            ActorId = 3
                        },
                        new Actor_Movie()
                        {
                            MovieId = 2,
                            ActorId = 3
                        },
                        new Actor_Movie()
                        {
                            MovieId = 2,
                            ActorId = 4
                        },
                        new Actor_Movie()
                        {
                            MovieId = 3,
                            ActorId = 1
                        },
                        new Actor_Movie()
                        {
                            MovieId = 3,
                            ActorId = 4
                        },
                        new Actor_Movie()
                        {
                            MovieId = 4,
                            ActorId = 1
                        },
                        new Actor_Movie()
                        {
                            MovieId = 4,
                            ActorId = 5
                        },
                        new Actor_Movie()
                        {
                            MovieId = 5,
                            ActorId = 5
                        },
                        new Actor_Movie()
                        {
                            MovieId = 5,
                            ActorId = 6
                        },
                        new Actor_Movie()
                        {
                            MovieId = 6,
                            ActorId = 4
                        },
                        new Actor_Movie()
                        {
                            MovieId = 6,
                            ActorId = 6
                        },
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
