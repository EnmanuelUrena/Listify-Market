using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Address //Jut an example
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string ZipCode { get; set; }

    public Address(string street, string city, string province, string zipCode)
    {
        Street = street;
        City = city;
        Province = province;
        ZipCode = zipCode;
    }

}
