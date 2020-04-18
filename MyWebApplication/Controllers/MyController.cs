using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApplication.Domain.Models;

namespace MyWebApplication.Controllers
{
    public class MyController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Random()
        {
            Random rnd = new Random();
            int number = rnd.Next();
            string model = $"Update this page for a new random number: {number}";
            return View("Random", model);
        }

        public IActionResult Area([FromQuery]int side)
        {
            double area = Math.Pow(side, 2);
            string model = $"The area of the square is {area}";
            return View("Area", model);
        }
    }
}