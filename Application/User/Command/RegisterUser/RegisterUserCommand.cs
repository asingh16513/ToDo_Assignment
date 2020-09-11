using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.User.Command.RegisterUser
{
    public class RegisterUserCommand :IRequest<int>
    {
        public Domain.Models.User User { get; set; }
    }
}
