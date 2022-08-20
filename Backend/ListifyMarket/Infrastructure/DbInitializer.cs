using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.AppUsers.Any())
            return;

        var admin = new AppUser()
        {
            Id = Guid.NewGuid(),
            Name = "Momomomo Xiaoyou",
            Account = "danvic.wang",
            Password = "12345",
            Address = new Address("club de leones", "Santos Domingo", "SDE", "1401")
        };

        context.AppUsers.Add(admin);
        context.SaveChanges();
    }
}
