using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

using Shopper.Domain.Entities.Identity;
using Shopper.Domain.Exceptions;

namespace Shopper.Application.Users.Commands.AssignUserRoles
{
    public class AssignUserRoleCommandHandler(ILogger<AssignUserRoleCommandHandler> logger,
         RoleManager<IdentityRole> roleManager, UserManager<User> userManager) : IRequestHandler<AssignUserRoleCommand>
    {
        public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("AssignUserRoleCommandHandler called {@request}", request);


            var userToAssign = await userManager.FindByEmailAsync(request.UserEmail)
                              ?? throw new NotFoundException(nameof(User), request.UserEmail);

            var role = await roleManager.FindByNameAsync(request.RoleName)
                ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);

            await userManager.AddToRoleAsync(userToAssign, role.Name!);


        }
    }
}
