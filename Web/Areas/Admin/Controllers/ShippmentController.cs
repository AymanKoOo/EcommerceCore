using AutoMapper;
using Core.Entites.Shipping;
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
    public class ShippmentController : Controller
    {
        readonly private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShippmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var model = _unitOfWork.shippingRepo.getAllShippingMethods();
            return View(model);
        }
        [HttpGet]
        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ShippingMethods model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.shippingRepo.Add(model);
                _unitOfWork.Save();
            }
            return Redirect("/failed");
        }

    }
}
