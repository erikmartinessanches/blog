using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreStart.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

namespace CoreStart.Controllers
{
    public class BlogPostController : Controller
    {
        private BlogContext context { get; set; }

        public BlogPostController(BlogContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit",new BlogPost());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //ViewBag.Action = "Edit";

            var blogpost = await context.BlogPosts.FindAsync(id);
            ViewBag.Action = (blogpost.BlogPostId == 0) ? "Add" : "Edit";
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
                //ViewBag.Action = (blogpost.BlogPostId == 0) ? "Add" : "Edit";
                return View(blogpost);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.Action = "Delete";
            var blogpost = await context.BlogPosts.FindAsync(id);
            return View(blogpost);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BlogPost blogpost)
        {
            context.BlogPosts.Remove(blogpost);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
