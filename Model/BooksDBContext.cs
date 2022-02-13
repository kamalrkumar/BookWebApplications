using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebAPI.Model
{
    public class BooksDBContext : DbContext
    {

        public BooksDBContext(DbContextOptions<BooksDBContext> options): base(options)
        {

        }

        public DbSet<Books> books { get; set; }
    }
}
