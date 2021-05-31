using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    [Route("api/[Controller]")]
    public class AdminContoller : Controller
    {

        private IUnitOfWork _unitOfWork;

        public AdminContoller(IUnitOfWork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        //// Intialize unit of work ////
        public IActionResult Index()
        {
            return View();
        }


        [Route("GetUsers")]
        [HttpGet]
        public IEnumerable<ApplicationUser> GetAllUseers()
        {
            return _unitOfWork.Admin.GetAllUsers();

        }

    }
}