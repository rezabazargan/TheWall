namespace TheWall.Application.Contracts;

public interface ILoginProvider
{
    Task<LoginResult> LoginAsync(LoginModelBase request, CancellationToken cancellationToken);
}