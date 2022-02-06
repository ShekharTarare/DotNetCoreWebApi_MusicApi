using Microsoft.EntityFrameworkCore;
using MusicApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApi.Data
{
    public class ApiDbContext: DbContext
    {
        //We are passing the connection strings details through the below constructor. The connection string
        //will be passed through the Startup.cs file
        public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
        {

        }

        public DbSet<Song> Songs { get; set; }
    }
}
