using AutoMapper;
using Core.Entites.Catalog;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ShopPickerController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShopPickerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

      
    }
}
