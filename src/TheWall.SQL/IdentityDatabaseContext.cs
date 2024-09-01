using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheWall.Application.Model;

namespace TheWall.SQL
{
    public class IdentityDatabaseContext(DbContextOptions<IdentityDatabaseContext> options) : 
        IdentityDbContext<User>(options)
    {
    }
}
