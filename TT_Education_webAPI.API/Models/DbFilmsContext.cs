using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;


namespace TT_Education_webAPI.API.Models
{
    public class DbFilmsContext: DbContext
    {
        public DbFilmsContext(DbContextOptions<DbFilmsContext> options)
        : base(options)
        {
        }

        public DbSet<FilmModel> FilmModels { get; set; }
        public DbSet<GenreModel> GenreModels { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=FilmDB;Trusted_Connection=True;");
            }
        }
    }
}
