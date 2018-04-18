using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyAuth.Models;
using VidlyAuth.ViewModels;

namespace VidlyAuth.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageCustomers))
                return View();

            return View("ReadOnlyIndex");
        }

        [Authorize(Roles = RoleName.CanManageCustomers)]
        public ActionResult New()
        {
            var genders = _context.Genders.ToList();
            var membershipTypes = _context.MembershipTypes
                .Include(m => m.MembershipTypeGroup)
                .OrderBy(m => m.MembershipTypeGroup.Name)
                .ToList();

            var viewModel = new CustomerFormViewModel(membershipTypes, genders);

            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var genders = _context.Genders.ToList();
            var membershipTypes = _context.MembershipTypes.Include(m => m.MembershipTypeGroup).ToList();
            var viewModel = new CustomerFormViewModel(customer, membershipTypes, genders);

            if (User.IsInRole(RoleName.CanManageCustomers))
                return View("CustomerForm", viewModel);

            return View("ReadOnlyCustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var genders = _context.Genders.ToList();
                var membershipTypes = _context.MembershipTypes.Include(m => m.MembershipTypeGroup).ToList();
                var viewModel = new CustomerFormViewModel(customer, membershipTypes, genders);

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.FirstName = customer.FirstName;
                customerInDb.LastName = customer.LastName;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.GenderId = customer.GenderId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "customers");
        }
    }
}