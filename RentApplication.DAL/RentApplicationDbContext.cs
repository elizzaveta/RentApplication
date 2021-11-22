using Microsoft.EntityFrameworkCore;
using RentApplication.DAL.Models;

namespace RentApplication.DAL
{
    public sealed class RentApplicationDbContext : DbContext
    {
        private RentApplicationDbContext _context;

        public RentApplicationDbContext(DbContextOptions<RentApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public RentApplicationDbContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new RentApplicationDbContext(new DbContextOptions<RentApplicationDbContext>());
                }

                return _context;
            }
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Realtor> Realtors { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
    }
}