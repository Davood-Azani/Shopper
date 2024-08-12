﻿using MediatR;

namespace Shopper.Application.Users.Commands.UnAssignUserRoles
{
    public class UnAssignUserRoleCommand :IRequest
    {
        public string UserEmail { get; set; } = default!;
        public string RoleName { get; set; } = default!;
    }
}
