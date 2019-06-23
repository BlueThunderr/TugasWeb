using Microsoft.EntityFrameworkCore;

namespace backEnd.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options)
            : base(options)
        {
        }        

        public DbSet<User> Users { get; set; }
        public DbSet<LaporanHeader> LaporanHeaders { get; set; }
        public DbSet<LaporanItem> LaporanItems { get; set; }
    }
}