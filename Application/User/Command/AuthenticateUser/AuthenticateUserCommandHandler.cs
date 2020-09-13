using Application.Helper;
using Application.Interface;
using Domain.Models;
using MediatR;
using Microsoft.Extensions.Options;
using Persistence;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Command.AuthenticateUser
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, UserAuthResult>
    {
        private readonly IOptions<ApplicationSetting> _applicationSettingAccessor;
        private readonly IUserManager _userAccessor;
        private readonly IMD5Hash _hashHelper;
        public AuthenticateUserCommandHandler(IOptions<ApplicationSetting> applicationSettingAccessor, IUserManager userAccessor, IMD5Hash hashHelper)
        {
            _applicationSettingAccessor = applicationSettingAccessor;
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
            _hashHelper = hashHelper;
        }

        public async Task<UserAuthResult> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            UserAuthResult userAuthResult = null;
            var db = GetInstance.Get<IUserDbManager>();
            var base64EncodedPwd = Convert.FromBase64String(request.Password);
            var passWord = Encoding.UTF8.GetString(base64EncodedPwd);
            passWord = _hashHelper.GetMD5Hash(passWord);
            Domain.Models.User user = await db.AuthenticateUser(request.Name, passWord);
            if (user != null)
            {
                userAuthResult = new UserAuthResult
                {
                    AuthToken = _userAccessor.GenerateToken(user, _applicationSettingAccessor.Value.AuthenticationTokenSecret),
                    UserId = user.Id
                };
            }
            return userAuthResult;
        }
    }
}
