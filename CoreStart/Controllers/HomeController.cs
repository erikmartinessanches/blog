using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreStart.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreStart.Controllers
{
    public class HomeController : Controller
    {
        /*Specifying IActionResult interface as the return type allows us to return any type of
         action result, for example a ViewResult.*/
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.FV = 0;
            /*Returns a ViewResult object for the view associated with the action method.
             *ViewResult is a type of IActionResult. */
            return View(); 
        }

        [HttpPost]
        public IActionResult Index(BlogPost model)
        {
            if (ModelState.IsValid) //ModelState is a property on the Controller class.
            {
                ViewBag.BlogPost = model.Post + " Written by " + model.Author + " on " + model.Time.ToString() +".";
                //ViewBag.Author = model.Author;
                //ViewBag.Time = model.Time;
            }
            else
            {
                //ViewBag.BlogPost = "";

                
            }
            
            return View(model);
        }
    }
}
