using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TT_Education_webAPI.API.Models
{

    public class DbFilmsContext: DbContext
    {
        private readonly IConfiguration _config;

        public DbFilmsContext(DbContextOptions<DbFilmsContext> options, IConfiguration config)
        : base(options)
        {
            _config = config; 
        }

        public DbSet<FilmModel> FilmModels { get; set; }
        public DbSet<GenreModel> GenreModels { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config["ConnectionString"]);
            }
        }
    }
}
