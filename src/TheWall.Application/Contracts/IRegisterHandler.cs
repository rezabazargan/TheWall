using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWall.Application.Contracts
{
    public interface IRegisterHandler
    {
        Task<string> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken);
    }
}