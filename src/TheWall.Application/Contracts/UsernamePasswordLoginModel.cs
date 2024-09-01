using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWall.Application.Contracts
{
    public class UsernamePasswordLoginModel : LoginModelBase
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
