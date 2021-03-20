using System.Linq;
using System.Threading.Tasks;
using CoreStart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreStart.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            /**Like the OrderBy() method, the Include() method doesn't execute at the database,
             * instead it helps build up the query expression that the ToList() method eventually
             * executes.
             *
             * If we would only need the CategoryId value, not the data for the entire category
             * entity, then we would not have to use the Include() method since the BlogPost
             * enteties contain a FK property named CategoryId. So CategoryId is automatically
             * included when we select a BlogPost. However, here we want to get all the Category
             * data, hence we use the Include() method.
             */
            var blogposts = await context.BlogPosts
                .Include(m => m.Category)
                .OrderByDescending(m => m.Time)
                .ToListAsync();
            /*Returns a ViewResult object for the view associated with the action method.
             *ViewResult is a type of IActionResult. */
            return View(blogposts);
        }
    }
}
