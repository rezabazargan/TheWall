using Microsoft.AspNetCore.Identity;
using TheWall.Application.Contracts;
using TheWall.Application.Model;

namespace TheWall.Application.Implementations;

internal class RegisterHandler(UserManager<User> userManager) : IRegisterHandler
{
    public async Task<string> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid().ToString();
        var result = await userManager.CreateAsync(new User()
        {
            Id = id,
            Email = request.Email,
            Name = request.Name,
            UserName = request.Email
        }, request.Password);

        if (result.Succeeded)
            return id;

        throw new ApplicationException(string.Join(",", result.Errors.Select(e => e.Description)));
    }
}