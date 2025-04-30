using Microsoft.EntityFrameworkCore;
using SUT24_JohanHansson_Labb3_API.Models;

namespace SUT24_JohanHansson_Labb3_API.Controllers.Data
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        //Create DbSet for Person, Interest, PersonInterest and Link.
        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }
        public DbSet<Link> Links { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Person)
                .WithMany(p => p.PersonInterests)
                .HasForeignKey(pi => pi.PersonId);

            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Interest)
                .WithMany(i => i.PersonInterests)
                .HasForeignKey(pi => pi.InterestId);

            modelBuilder.Entity<Link>()
                .HasOne(l => l.PersonInterest)
                .WithMany(pi => pi.Links)
                .HasForeignKey(l => l.PersonInterestId);
        }
    }
}

