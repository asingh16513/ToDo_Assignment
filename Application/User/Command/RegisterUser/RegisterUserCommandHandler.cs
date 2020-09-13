using Application.Helper;
using Application.Interface;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Command.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IMD5Hash _hashHelper;
        public RegisterUserCommandHandler(IMD5Hash hashHelper)
        {
            _hashHelper = hashHelper;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<IUserDbManager>();
            var base64EncodedPwd = System.Convert.FromBase64String(request.User.Password);
            var passWord = System.Text.Encoding.UTF8.GetString(base64EncodedPwd);
            request.User.Password = _hashHelper.GetMD5Hash(passWord);
            var result = await db.RegisterUser(request.User);
            return result;
        }
    }
}
