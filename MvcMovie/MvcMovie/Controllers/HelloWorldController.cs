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
        public string Index()
        {
            return "This is my <b>default</b> action.";
        }

        // Get: /HelloWorld/Welcome/
        public string Welcome(string name, int ID = 1)
        {
            // Given a parameter this returns the parameter based string.
            //return HttpUtility.HtmlEncode("Hello " + name + ", NumTimes is: " + numTimes);
            // Again given a parameter, update the html using the parameters. The ID parameter is contained as a segment in the route parameter.
            return HttpUtility.HtmlEncode("Hello " + name + ", ID: " + ID);
        }
    }
}