using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CoreStart.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreStart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostController : Controller
    {
        private BlogContext context { get; set; }

        public BlogPostController(BlogContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = await context.Categories.OrderBy(c => c.Name).ToListAsync();
            return View("Edit", new BlogPost());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var blogpost = await context.BlogPosts.FindAsync(id);
            ViewBag.Action = (blogpost.BlogPostId == 0) ? "Add" : "Edit";
            ViewBag.Categories = await context.Categories.OrderBy(c => c.Name).ToListAsync();
            return View(blogpost);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BlogPost blogpost)
        {
            if (ModelState.IsValid)
            {
                if (blogpost.BlogPostId == 0)
                {
                    await context.BlogPosts.AddAsync(blogpost);
                }
                else
                {
                    context.BlogPosts.Update(blogpost);
                }
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (blogpost.BlogPostId == 0) ? "Add" : "Edit";
                ViewBag.Categories = await context.Categories.OrderBy(c => c.Name).ToListAsync();
                return View(blogpost);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.Action = "Delete";
            var blogpost = await context.BlogPosts.FindAsync(id);
            blogpost.Category = await context.Categories.FindAsync(blogpost.CategoryId); 
            return View(blogpost);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BlogPost blogpost)
        {
            context.BlogPosts.Remove(blogpost);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> BlogPost(int id)
        {
            var blogpost = await context.BlogPosts.FindAsync(id);
            //TODO Find the category of the blogpost with this id.
            blogpost.Category = await context.Categories.FindAsync(blogpost.CategoryId); 
            return View(blogpost);
        }
    }
}
;