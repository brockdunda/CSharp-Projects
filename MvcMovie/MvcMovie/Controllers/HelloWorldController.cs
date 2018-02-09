using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        //public string Index()
        //{
        //    return "This is my <b>default</b> action.";
        //}

        // Update the index method to return a view
        public ActionResult Index()
        {
            return View();
        }

        // Get: /HelloWorld/Welcome/
        //public string Welcome(string name, int ID = 1)
        //{
        //    // Given a parameter this returns the parameter based string.
        //    //return HttpUtility.HtmlEncode("Hello " + name + ", NumTimes is: " + numTimes);
        //    // Again given a parameter, update the html using the parameters. The ID parameter is contained as a segment in the route parameter.
        //    return HttpUtility.HtmlEncode("Hello " + name + ", ID: " + ID);
        //}

        // Update the welcome method to include the parameters passed in to viewbags
        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }
    }
}