using AutoMapper;
using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]")]
    public class RolesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RolesController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var roles = _unitOfWork.role.GetAll();
            return View(roles);
        }

        [HttpGet]
        [Route("AddRole")]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        [Route("AddRole")]
        public IActionResult AddRole(ApplicationRole roleVN)
        {
            _unitOfWork.role.Add(roleVN);
            _unitOfWork.Save();
            return Redirect("/");
        }

        [HttpGet]
        [Route("DeleteRole")]
        public IActionResult DeleteRole(string roleID)
        {
            var role  =_unitOfWork.role.GetByID(roleID);
            _unitOfWork.role.Delete(role);
            _unitOfWork.Save();
            return Redirect("/");
        }


    }
}
