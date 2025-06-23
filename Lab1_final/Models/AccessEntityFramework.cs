using System.Data.Entity;

namespace Lab1_final.Models
{
    public class AccessEntityFramework : DbContext
    {
        public AccessEntityFramework() : base("name=mvc1Connection") { }

        public DbSet<Usuario> usuario { get; set; }
    }
}
