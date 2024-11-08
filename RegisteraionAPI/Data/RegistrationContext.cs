using Microsoft.EntityFrameworkCore;
using RegisteraionAPI.Model;


namespace RegistrationAPI.Data
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext(DbContextOptions<RegistrationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
