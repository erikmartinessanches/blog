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
            return View("Edit", new BlogPost());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var blogpost = context.BlogPosts.Find(id);
            return View(blogpost);
        }

        [HttpPost]
        public IActionResult Edit(BlogPost blogpost)
        {
            if (ModelState.IsValid)
            {
                if (blogpost.BlogPostId == 0)
                {
                    context.BlogPosts.Add(blogpost);
                }
                else
                {
                    context.BlogPosts.Update(blogpost);
                }

                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (blogpost.BlogPostId == 0) ? "Add" : "Edit";
                return View(blogpost);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var blogpost = context.BlogPosts.Find(id);
            return View(blogpost);
        }

        [HttpPost]
        public IActionResult Delete(BlogPost blogpost)
        {
            context.BlogPosts.Remove(blogpost);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
