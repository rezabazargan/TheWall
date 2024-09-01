using TheWall.Application.Model;

namespace TheWall.Application.Contracts;

public interface ILoginHandler<T> where T: LoginModelBase
{
    Task<LoginUserResult> LoginAsync(T request, CancellationToken cancellationToken);
}