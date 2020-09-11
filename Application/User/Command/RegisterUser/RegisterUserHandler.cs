using Application.Helper; 
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Command.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, int>
    {
        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<IUser>();
            var base64EncodedPwd = System.Convert.FromBase64String(request.User.Password);
            var passWord = System.Text.Encoding.UTF8.GetString(base64EncodedPwd);
            request.User.Password = MD5HashHelper.MD5Hash(passWord);
            var result = await db.RegisterUser(request.User);
            return result;
        }
    }
}
