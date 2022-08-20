using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppUsers.Commands.UserLogin;

public class UserLoginCommand : IRequest<Guid>
{
    public string Account { get; set; }
    public string Password { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string ZipCode { get; set; }


    public UserLoginCommand(string account, string password, string street,
        string city, string province, string zipCode)
    {
        Account = account;
        Password = password;
        Street = street;
        City = city;
        Province = province;
        ZipCode = zipCode;
    }
}

public class UserLoginHandler : IRequestHandler<UserLoginCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public UserLoginHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var appUser = new AppUser()
        {
            Account = request.Account,
            Password = request.Password,
            Address = new Address(
                    street: request.Street,
                    city: request.City,
                    province: request.Province,
                    zipCode: request.ZipCode
                )
        };

        _context.AppUsers.Add(appUser);
        await _context.SaveChangesAsync(cancellationToken);

        return appUser.Id;
    }
}
