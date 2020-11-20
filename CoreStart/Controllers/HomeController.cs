using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreStart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreStart.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext context { get; set; }

        public HomeController(BlogContext ctx)
        {
            this.context = ctx;
        }

        /*Specifying IActionResult interface as the return type allows us to return any type of
         action result, for example a ViewResult.*/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var blogposts = await context.BlogPosts.OrderByDescending(m => m.Time).ToListAsync();
            /*Returns a ViewResult object for the view associated with the action method.
             *ViewResult is a type of IActionResult. */
            return View(blogposts);
        }
    }
}
