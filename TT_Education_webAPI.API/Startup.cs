using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT_Education_webAPI.API.Models;

namespace TT_Education_webAPI.API
{
    public class Startup
    {
        private string _securityKey = null;
        private string _validIssuer = null;
        private string _validAudience = null;
        private string _connectionString = null;



        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _securityKey = Configuration["SecurityKey"];
            _validIssuer = Configuration["ValidIssuer"];
            _validAudience = Configuration["ValidAudience"];
            _validAudience = Configuration["ConnectionString"];


            services.Configure<Config>(Configuration);


            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TT_Education_webAPI.API", Version = "v1" });
            });

            var connectionString = $"Server=tcp:webapijz.database.windows.net,1433;Initial Catalog=Web_Api_DB;Persist Security Info=False;User ID=jz;Password={_connectionString};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

            services.AddDbContext<DbFilmsContext>(options => options.UseSqlServer(connectionString));
            //services.AddDbContext<DbFilmsContext>(options => options.UseSqlServer("Server=(localdb)\\MSSqlLocalDb;Database=FilmDB;Trusted_Connection=True;"));

            services.AddAuthentication().AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = _validIssuer,
                    ValidateAudience = true,
                    ValidAudience = _validAudience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey)),

                };
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TT_Education_webAPI.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors(builder => builder
               .AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod());
        }


    }
}
