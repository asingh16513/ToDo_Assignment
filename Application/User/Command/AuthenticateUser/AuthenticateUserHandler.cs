using Application.Helper;
using Application.Interface;
using Domain; 
using Domain.Models;
using MediatR;
using Microsoft.Extensions.Options;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks; 

namespace Application.User.Command.AuthenticateUser
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, UserAuthResult>
    {
        private readonly IOptions<ApplicationSetting> _applicationSettingAccessor;
        private readonly IUserManager _userAccessor;
        public AuthenticateUserHandler(IOptions<ApplicationSetting> applicationSettingAccessor, IUserManager userAccessor)
        {
            _applicationSettingAccessor = applicationSettingAccessor;
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
        }

        public async Task<UserAuthResult> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            UserAuthResult userAuthResult = null;
            var db = GetInstance.Get<IUser>();
            string result = string.Empty;
            var base64EncodedPwd = System.Convert.FromBase64String(request.Password);
            var passWord = System.Text.Encoding.UTF8.GetString(base64EncodedPwd);
            passWord = MD5HashHelper.MD5Hash(passWord);
            Domain.Models.User user = await db.AuthenticateUser(request.Name, passWord);
            if (user != null)
            {
                userAuthResult = new UserAuthResult();
                userAuthResult.AuthToken = _userAccessor.GenerateToken(user, _applicationSettingAccessor.Value.AuthenticationTokenSecret);
                userAuthResult.UserId = user.Id;
            }
            return userAuthResult;
        }
    }
}
