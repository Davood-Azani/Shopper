using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Shopper.Domain.Entities.Identity;
using Shopper.Domain.Exceptions;

namespace Shopper.Application.Users.Commands.UnAssignUserRoles
{
    public class UnAssignUserRoleCommandHandler(ILogger<UnAssignUserRoleCommandHandler> logger,
         RoleManager<IdentityRole> roleManager, UserManager<User> userManager) : IRequestHandler<UnAssignUserRoleCommand>
    {
        public async Task Handle(UnAssignUserRoleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("UnAssignUserRoleCommandHandler called {@request}", request);


            var userToAssign = await userManager.FindByEmailAsync(request.UserEmail)
                              ?? throw new NotFoundException(nameof(User), request.UserEmail);

            var role = await roleManager.FindByNameAsync(request.RoleName)
                ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);

            await userManager.RemoveFromRoleAsync(userToAssign, role.Name!);


        }
    }
}
