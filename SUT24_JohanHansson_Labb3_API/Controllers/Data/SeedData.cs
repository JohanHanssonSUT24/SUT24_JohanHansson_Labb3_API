using SUT24_JohanHansson_Labb3_API.Models;

namespace SUT24_JohanHansson_Labb3_API.Controllers.Data
{
    public static class SeedData
    {
        public static void addSeedData(ApiDbContext context)//Method to add seeddata to db.
        {
            if (context.Persons.Any() || context.Interests.Any()) return;//If data exists, stop here.(my teacher dosnt like this)

            var interests = new List<Interest>//Create list with interests to be added
            {
                new Interest{ Title = "Programming", Description = "Coding and software development"},
                new Interest{ Title = "Cooking", Description = "Making good food"},
                new Interest{ Title = "Music", Description = "Rocking all over the world"},
                new Interest{ Title = "Sport", Description = "Petters least favorite thing in the world"},
                new Interest{ Title = "Gardening", Description = "Cutting grass and watering plants"},
                new Interest{ Title = "Mechanics", Description = "Fixing engines and repairing cars"}
            };
            context.Interests.AddRange(interests);
            context.SaveChanges();
            var person = new List<Person>//Create list with people to be added
            {
                new Person {FirstName = "Johan", LastName = "Hansson", Phone = "0700532273"},
                new Person {FirstName = "Jenny", LastName = "Hansson", Phone = "0700515273"},
                new Person {FirstName = "Erik", LastName = "Eriksson", Phone = "0700147273"},
                new Person {FirstName = "Stina", LastName = "Stinsson", Phone = "0700345273"},
                new Person {FirstName = "Eskil", LastName = "Lunde", Phone = "0737902273"}
            };
            context.Persons.AddRange(person);
            context.SaveChanges();

            var personInterest = new List<PersonInterest> //Create list that creates relations between Person and Interest.
            {
                new PersonInterest { PersonId = 1, InterestId = 6},
                new PersonInterest { PersonId = 1, InterestId = 1},
                new PersonInterest { PersonId = 2, InterestId = 3},
                new PersonInterest { PersonId = 3, InterestId = 2},
                new PersonInterest { PersonId = 3, InterestId = 4},
                new PersonInterest { PersonId = 4, InterestId = 5},
                new PersonInterest { PersonId = 5, InterestId = 1},
            };
            context.PersonInterests.AddRange(personInterest);
            context.SaveChanges();

            var links = new List<Link> //Create list of links to be added to db
            {
                new Link { Url = "https://stackoverflow.com", PersonInterestId = 1},
                new Link { Url = "https://allrecipes.com", PersonInterestId = 2},
                new Link { Url = "https://open.spotify.com/", PersonInterestId = 3},
                new Link { Url = "https://www.aftonbladet.se/sportbladet", PersonInterestId = 4},
                new Link { Url = "https://www.granngarden.se/", PersonInterestId = 5},
                new Link { Url = "https://www.mekonomen.se/", PersonInterestId = 6}
            };
            context.Links.AddRange(links);
            context.SaveChanges();
        }
    }
}
