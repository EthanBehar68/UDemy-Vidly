using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
            _context.Dispose();
        }


        public ViewResult Index()
        {
            // the use of Include statment is called Eager Loading
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); // Immediately query DB; if not ToList it is deferred until iteration(in View(c) - Called Deferred Execution in Identity Framework

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id); // Query is immediately executed b/c SingleOfDefault

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost] // Actions that modify data should never be accessed by HttpGet so add attribute to make it explicity a Post Action
        //public ActionResult Create(NewCustomerViewModel viewModel) // Model Minding - MVC automatically binds this model to the request data
        [ValidateAntiForgeryToken] // Prevents CSRF attacks - MAKE SURE TO IMPLEMENT IN VIEW TOO!
        public ActionResult Save(Customer customer) // B/c all of our keys in teh form data of New.cshtml are prefixed with Customer
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                // Opens security issues
                // TryUpdateModel(customer, "", new string[] { "Name", "Email" });

                //Mapper.Map(customer, customerInDb); to avoid security issues use a Dto(Data Transfer Object) in parameter - Example (UpdateCustomerDto customer)
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}