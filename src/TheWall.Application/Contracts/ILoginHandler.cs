using TheWall.Application.Model;

namespace TheWall.Application.Contracts;

public interface ILoginHandler<T> where T: LoginModelBase
{
    Task<User> LoginAsync(T request, CancellationToken cancellationToken);
}