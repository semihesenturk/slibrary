using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SLibrary.Api.Domain.Models;

namespace SLibrary.Infrastructure.Persistence.Context;
internal class SeedData
{
    //Get fake user data with Bogus Fake Data Generator tool
    //private static List<User> GetUsers()
    //{
    //    var result = new Faker<User>("tr")
    //        .RuleFor(i => i.Id, i => Guid.NewGuid())
    //        .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
    //        .RuleFor(i => i.FirstName, i => i.Person.FirstName)
    //        .RuleFor(i => i.LastName, i => i.Person.LastName)
    //        .RuleFor(i=> i.MobileNumber, i=> i.Phone.PhoneNumber().ToString())
    //        .RuleFor(i=> i.NationalId, i => i.PickRandom(11111111111, 99999999999))
    //      .Generate(10);

    //    return result;
    //}

    private static List<User> GetUsers()
    {
        var users = new List<User>() {
             new User() {Id = Guid.NewGuid(), FirstName = "Semih", LastName = "Esenturk", MobileNumber = "5342290912", NationalId = 11111111111 },
             new User() {Id = Guid.NewGuid(), FirstName = "Mehmet", LastName = "Akan", MobileNumber = "5342290913", NationalId = 11111111112 },
             new User() {Id = Guid.NewGuid(), FirstName = "Leman", LastName = "Özbek", MobileNumber = "5342290914", NationalId = 11111111113 }
        };

        return users;
    }

    private static List<Book> GetBooks()
    {
        var users = GetUsers();
        var books = new List<Book>()
        {
            new Book() {Title ="Art of software development", ISBN = "999897897", Price =100, PublishedYear = "1990", Status = Common.Enums.BookStatusEnum.CheckedIn},
            new Book() {Title ="Art of software design patterns", ISBN = "949892817", Price =100, PublishedYear = "1996", Status = Common.Enums.BookStatusEnum.CheckedOut},
            new Book() {Title ="Database Designs", ISBN = "939191117", Price =100, PublishedYear = "1995", Status = Common.Enums.BookStatusEnum.CheckedIn}
        };

        return books;
    }
    public async Task SeedAsync(IConfiguration configuration)
    {
        var dbContextBuilder = new DbContextOptionsBuilder();
        dbContextBuilder.UseSqlServer(configuration["SLibraryDbConnectionString"]);

        var context = new SLibraryContext(dbContextBuilder.Options);

        if (context.Users.Any())
        {
            await Task.CompletedTask;
            return;
        }

        //Seed user datas
        var users = GetUsers();
        var books = GetBooks();

        await context.Users.AddRangeAsync(users);
        await context.Books.AddRangeAsync(books);

        //Save all fake datas
        await context.SaveChangesAsync();
    }
}
