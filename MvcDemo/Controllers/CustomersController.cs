using MvcDemo.Models;
using MvcDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MvcDemo.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();
            var viewModel = new CustomerViewModel();
            viewModel.Customers = customers;

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);
            var lowerCaseMembershipNameSubstr = customer.MembershipType.Name.Substring(1).ToLower();
            var upperCaseFirstLetter = customer.MembershipType.Name[0].ToString().ToUpper();
            customer.MembershipType.Name = $"{upperCaseFirstLetter}{lowerCaseMembershipNameSubstr}";
            return View(customer);
        }
    }
}