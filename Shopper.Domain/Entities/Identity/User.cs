using Microsoft.AspNetCore.Identity;

namespace Shopper.Domain.Entities.Identity;

public class User : IdentityUser
{
    public DateOnly? BirthDate { get; set; }

    public string? Nationality { get; set; }
    public ICollection<Product> OwnedProducts { get; set; } = [];

    
}