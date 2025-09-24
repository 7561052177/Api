using EntitywithAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EntitywithAPI.Data
{
    public class appdbcontxt:DbContext
    {
       
        public appdbcontxt(DbContextOptions<appdbcontxt> options)
           : base(options)
        {


        }
        public DbSet<Product> Products { get; set; }
    }
}
