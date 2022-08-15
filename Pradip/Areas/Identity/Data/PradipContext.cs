using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pradip.Areas.Identity.Data;
using Pradip.Models;

namespace Pradip.Data;

public class PradipContext : IdentityDbContext<PradipUser>
{
    public PradipContext(DbContextOptions<PradipContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<clientRecord> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
