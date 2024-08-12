

namespace Shopper.Application.Users
{
    public record CurrentUser(string Id, string Email, IReadOnlyList<string> Roles ,string? Nationality ,DateOnly? DateOfBirth)
    {
        public bool IsAuthenticated => !String.IsNullOrEmpty(Id);
        public bool IsAdmin => Roles.Contains("Admin");

        public bool IsInRole(string role) => Roles.Contains(role);
    }
}
