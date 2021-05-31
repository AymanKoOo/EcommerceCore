using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.DTOs;

namespace Web.Controllers
{
    [Route("[Controller]")]
    public class ProductsController : Controller
    {

        readonly private IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Route("AddProduct")]
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [Route("AddProduct")]
        [HttpPost]
        public IActionResult AddProduct(ProductDTO productDTO)
        {


            return View();
        }

    }
}