using AutoMapper;
using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]")]
    public class CustomerController : Controller
    {
        readonly private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var customer = _unitOfWork.Customer.GetAllCustomers();
            return View(customer);
        }

        //[Route("EditCustomer")]
        //public IActionResult EditCustomer(string cutomerID)
        //{
        //}


        [HttpGet]
        [Route("EditCustomer")]
        public IActionResult EditCustomer(string customerID)
        {
            var customer = _unitOfWork.Customer.GetCustomerAndRoleById(customerID);
            return View(customer);
        }

        [HttpPost]
        [Route("EditCustomer")]
        public async Task<IActionResult> EditCustomer(CustomerDTO customer)
        {
            var user = _unitOfWork.Customer.GetCustomerById(customer.UserId);
            var role = _unitOfWork.Customer.GetRole(customer.roles);
            
            user.UserName = customer.UserName;
            user.Email = customer.Email;
            _unitOfWork.Customer.Update(user);
            _unitOfWork.Save();

            await _userManager.AddToRoleAsync(user, role.Name);

            return Redirect("/");
        }


        [Route("DeleteCustomer")]
        public IActionResult DeleteCustomer(string cutomerID)
        {
           var customer = _unitOfWork.Customer.GetCustomerById(cutomerID);
            _unitOfWork.Customer.Delete(customer);
            _unitOfWork.Save();
            return Redirect("/");
        }

    }
}
