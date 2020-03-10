using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UDemyVidly._CheatSheets
{
    /// <summary>
    /// JUST EXAMPLES OF RANDOM THINGS
    /// </summary>
    public class _IgnoreMe
    {
        // Examples of other ActionResults
        // return Content("Hello World!");
        // return HttpNotFound();
        // return new EmptyResult();
        // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

        //[Route("movies/")]
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return View();
        //}

        // /Movies/Random
        //public ActionResult Random()
        //{
        //    // One way of passing data, argument to view method
        //    var movie = new Movie() { Name = "Shrek!" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name = "Customer1"},
        //        new Customer {Name = "Customer2"}
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    View() handles below so its accessible in the View Model
        //    var viewResult = new ViewResult();
        //    viewResult.ViewData.Model;

        //    return View(viewModel);

        //    
        //    Avoid using ViewData and ViewBag because they are fragile. 
        //    Plus, you have to do extra casting, which makes your code ugly. 
        //    Pass a model (or a view model) directly to a view: return View(movie);

        //    Another way of passing Data - ViewData Dictionary (not ideal b/c of renaming issues - wont update in view)
        //    var movie = new Movie() { Name = "Shrek!" };

        //    ViewData["Movie"] = movie;

        //    return View();

        //    Another way of passing Data - ViewBag (not ideal b/c of renaming issues - wont update in view)
        //    var movie = new Movie() { Name = "Shrek!" };

        //    ViewBag.Movie= movie;

        //    return View();

        //}

        // /Movies/Edit
        // public ActionResult Edit(int id)
        // {
        //     return Content("id=" + id);
        // }
           
        // /Movies/Released (see routing for details on why !ByReleaseDate
        // [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        //  Google ASP.NET MVC Attribute Route Constraints for more info on Attribute Constraints
        // public ActionResult ByReleaseDate(int year, int month)
        // {
        //     return Content(year + "/" + month);
        // }
    }
}