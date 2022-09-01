//using Core.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Web.Controllers
//{
//    [Route("/")]
//    public class DiscountController : Controller
//    {
//        private IUnitOfWork _unitOfWork;

//        public DiscountController(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }


//        [HttpGet()]
//        public async Task<IActionResult> Discount(string discountSlug)
//        {
//           var discount = _unitOfWork.discount.GetDiscountBySlug(discountSlug);

//           return View(discount);
//        }
//    }
//}
