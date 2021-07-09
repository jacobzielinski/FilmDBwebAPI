using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TT_Education_webAPI.Data;
using TT_Education_webAPI.Models;

namespace TT_Education_webAPI.Controllers

{   [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        readonly ITokenAcquisition tokenAcquisition;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, ITokenAcquisition tokenAcquisition)
        {
            this.tokenAcquisition = tokenAcquisition;
            _dbContext = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var newUser = this.User.Claims;
            var user = GetUser();
            return View();
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public List<IdentityUser> GetUser()
        {
            var user = _dbContext.Users.OrderBy(x => x.Id).ToList();

            return user;
        }
    }
}
