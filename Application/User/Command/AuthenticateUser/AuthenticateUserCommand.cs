using Domain;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.User.Command.AuthenticateUser
{
    public class AuthenticateUserCommand : IRequest<UserAuthResult>
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
