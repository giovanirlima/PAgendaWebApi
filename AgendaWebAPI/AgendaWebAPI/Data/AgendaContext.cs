using AgendaWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaWebAPI.Data
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
