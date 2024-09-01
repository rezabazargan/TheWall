using Microsoft.AspNetCore.Identity;
using TheWall.Application.Contracts;
using TheWall.Application.Model;

namespace TheWall.Application.Implementations;

internal class UsernamePasswordLoginHandler(UserManager<User> userManager) : ILoginHandler<UsernamePasswordLoginModel>
{
    public async Task<User> LoginAsync(UsernamePasswordLoginModel request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Username);
        if (user == null)
        {
            throw new ApplicationException("User not found");
        }

        if (userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash ?? "", request.Password) == PasswordVerificationResult.Failed)
        {
            throw new ApplicationException("User not found");
        }

        return user;

    }
}