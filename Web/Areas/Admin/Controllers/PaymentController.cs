using AutoMapper;
using Core.Entites.Payments;
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
    public class PaymentController : Controller
    {
        readonly private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var model = _unitOfWork.paymentRepo.getAllPaymentMethodsAsync();
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
        public IActionResult Create(PaymentMethods model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.paymentRepo.Add(model);
                _unitOfWork.Save();
            }
            return Redirect("/failed");
        }

    }
}
