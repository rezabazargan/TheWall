using Microsoft.AspNetCore.Identity;
using TheWall.Application.Contracts;
using TheWall.Application.Model;

namespace TheWall.Application.Implementations;

internal class UsernamePasswordLoginHandler(UserManager<User> userManager) : ILoginHandler<UsernamePasswordLoginModel>
{
    public async Task<LoginUserResult> LoginAsync(UsernamePasswordLoginModel request, CancellationToken cancellationToken)
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

        return new LoginUserResult()
        {
            Email = user.Email ?? string.Empty,
            Id = user.Id,
            Name = user.Name ?? string.Empty,
            Roles = (await userManager.GetRolesAsync(user)).ToArray()
        };

    }
}