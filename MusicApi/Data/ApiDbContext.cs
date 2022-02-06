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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    Id = 1,
                    Title = "Willow",
                    Language = "English",
                    Duration = "4:56"
                },
                new Song
                {
                    Id = 2,
                    Title = "Arijit",
                    Language = "Hindi",
                    Duration = "4:56"
                },
                new Song
                {
                    Id = 3,
                    Title = "KK",
                    Language = "Hindi",
                    Duration = "4:56"
                });
        }
    }
}
