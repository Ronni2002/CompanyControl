using ControlCompany.Entities.Companies;
using Microsoft.EntityFrameworkCore;

namespace ControlCompany.Repositories.Context;

public class ControlDbContext: DbContext
{
    public ControlDbContext(DbContextOptions<ControlDbContext> options): base(options) { }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }
}