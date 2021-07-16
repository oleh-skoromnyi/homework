using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            this.RequestPreparingAndLogging();
            return View();
        }

        public IActionResult Hello()
        {
            this.RequestPreparingAndLogging();
            var name = _configuration.GetSection("Author").GetSection("Name").Value;
            ViewBag.HelloString = $"Hello, {name}";
            return View("Hello");
        }

        public IActionResult HelloJson()
        {
            this.RequestPreparingAndLogging();
            var name = _configuration.GetSection("Author").GetSection("Name").Value;
            ViewBag.HelloString = "{ data: \"Hello, " + name + "\"}";
            return View("Hello");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            this.RequestPreparingAndLogging();
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            string exceptionInfo = $"\n{ DateTime.Now} : " +
                $"{exceptionHandlerPathFeature?.Error.Message }\n" +
                $"{exceptionHandlerPathFeature?.Path }\n";
            System.IO.File.AppendAllText("exceptions.log", exceptionInfo);
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(RegViewModel user)
        {
            if (ModelState.IsValid)
            {
                var path = this._configuration.GetSection("userDbPath").Value;
                System.IO.File.Open(path, FileMode.OpenOrCreate).Close();
                var json = System.IO.File.ReadAllText(path);
                List<User> users = new List<User>();
                try
                {
                    users = JsonSerializer.Deserialize<List<User>>(json);
                }
                catch (Exception e) {}
                if (!users.Any(x => x.Email == user.Email))
                {
                    var newUser = new User
                    {
                        Id = users.Count + 1,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Password = user.Password
                    };
                    users.Add(newUser);
                    System.IO.File.WriteAllText(path, JsonSerializer.Serialize<List<User>>(users));
                }
            }
            HttpContext.Response.Redirect("/");
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult Todos()
        {
            if (this.HttpContext.Request.Cookies.ContainsKey("UserId"))
            {
                var id = Int32.Parse(this.HttpContext.Request.Cookies["UserId"]);
                var path = this._configuration.GetSection("userDbPath").Value;
                System.IO.File.Open(path, FileMode.OpenOrCreate).Close();
                var json = System.IO.File.ReadAllText(path);
                var users = JsonSerializer.Deserialize<List<User>>(json);
                if (users.Any(x => x.Id == id))
                {
                    return View();
                }
            }
            throw new Exception("You are not authorize");
        }

        [HttpPost]
        public IActionResult SignIn(string email, string password)
        {
            var path = this._configuration.GetSection("userDbPath").Value;
            System.IO.File.Open(path, FileMode.OpenOrCreate).Close();
            var json = System.IO.File.ReadAllText(path);
            var users = JsonSerializer.Deserialize<List<User>>(json);
            var user = users.First(x => x.Email == email);
            if (user.Password == password)
            {
                var cookieOption = new Microsoft.AspNetCore.Http.CookieOptions();
                cookieOption.Expires = DateTime.Now.AddDays(30);
                HttpContext.Response.Cookies.Append("UserId", user.Id.ToString(), cookieOption);
            }
            HttpContext.Response.Redirect("/");
            return View();
        }

        private void RequestPreparingAndLogging()
        {
            _logger.LogInformation($"{ DateTime.Now} {this.Request.Path}{this.Request.QueryString}");
        }
    }
}
