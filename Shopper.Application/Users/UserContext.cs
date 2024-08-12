using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Shopper.Application.Users;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{

    public CurrentUser? GetCurrentUser()
    {
        // we don have access directly to the claims here unlike controllers ,
        // User.Claims.ToList(); | .FirstOrDefault(x=>x.Type==x).value
        // so we need to get them from the httpContextAccessor

        var user = (httpContextAccessor?.HttpContext?.User) ?? throw new InvalidOperationException("User not found or Use Context is not present");
        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {

            //return null;

            throw new AuthenticationException("User is not authenticated");

        }


        var dateOfBirthString = user.FindFirst(x => x.Type == "DateOfBirth")?.Value;

        var currentUser = new CurrentUser(
            user.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value,
            user.FindFirst(x => x.Type == ClaimTypes.Email)!.Value,
            user.Claims.Where(x => x.Type == ClaimTypes.Role)!.Select(x => x.Value).ToList(),
            Nationality: user.FindFirst(x => x.Type == "National")?.Value,
            DateOfBirth: dateOfBirthString == null ? (DateOnly?)null :
                DateOnly.ParseExact(dateOfBirthString, "yyyy-MM-dd")


        );


        return currentUser;
    }
}