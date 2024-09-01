using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWall.Application.Model;

namespace TheWall.Application.Contracts
{
    internal interface ITokenProvider
    {
        Task<string> GetToken(LoginUserResult user, CancellationToken cancellationToken);
    }
}
