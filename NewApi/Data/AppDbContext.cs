using Microsoft.EntityFrameworkCore;
using NewApi.Models;

namespace NewApi.Data          //db
{
    public class AppDbContext:DbContext
    {
                    //constructor
           public AppDbContext(DbContextOptions<AppDbContext> options):base(options )
        {


        }

        //Category table
        public DbSet<Category> categories { get; set; }
        public DbSet<item> items { get; set; }
        public DbSet<User> cats { get; set; }

        

    }
}
