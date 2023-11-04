using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using UserServices.Domain;

namespace Persistance.Base
{
    public class Context : DbContext
    {
        public DbSet<User> User { get; set; }
    }
}
