using Microsoft.Extensions.DependencyInjection;
using TheWall.Application.Contracts;
using TheWall.Application.Model;

namespace TheWall.Application.Implementations;

internal class LoginProvider(IServiceProvider serviceProvider, ITokenProvider tokenProvider) : ILoginProvider
{

    public async Task<LoginResult> LoginAsync(LoginModelBase request, CancellationToken cancellationToken)
    {
        User? user = null;
        if (request is UsernamePasswordLoginModel model)
        {
            var handler = serviceProvider
                .GetRequiredService<ILoginHandler<UsernamePasswordLoginModel>>();
            user = await handler.LoginAsync(model, cancellationToken);
        }

        if (user == null)
        {
            throw new ApplicationException();
        }

        return new LoginResult()
        {
            Token = await tokenProvider.GetToken(user,cancellationToken)
        };
    }
}