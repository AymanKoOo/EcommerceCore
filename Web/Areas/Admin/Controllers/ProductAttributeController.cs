using AutoMapper;
using Core.Entites.Catalog;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.ViewModels.Catalog;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]")]
    public class ProductAttributeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductAttributeModelFactory productAttributeModelFactory;

        public ProductAttributeController(IUnitOfWork unitOfWork, IMapper mapper, IProductAttributeModelFactory productAttributeModelFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.productAttributeModelFactory = productAttributeModelFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("CreateProductAttribute")]
        public async Task<IActionResult> CreateProductAttribute()
        {
            return View();
        }

        [HttpPost("CreateProductAttribute")]
        public IActionResult CreateProductAttribute(AProductAttributeModel model)
        {
            var modelPAttribute = _mapper.Map<ProductAttribute>(model);
            _unitOfWork.productAttributes.Add(modelPAttribute);
            _unitOfWork.Save();
            return View("");
        }

        //  Option ATTRIBUTE  //
        [HttpGet("CreateAttributeOption")]
        public async Task<IActionResult> CreateAttributeOption()
        {
            var model = await productAttributeModelFactory.PrepareProductAttributeOptionModel();
            return View(model);
        }

        [HttpPost("CreateAttributeOption")]
        public IActionResult CreateAttributeOption(AProductAttributeOptionModel model)
        {
            var ProductAttribute = _unitOfWork.productAttributes.GetProductAttrByID(model.ProductAttributeId);
            model.productAttribute = ProductAttribute.Result;
            var modelAttr = _mapper.Map<ProductAttributeOption>(model);
            _unitOfWork.productAttributes.CreateProductAttributeOption(modelAttr);
            _unitOfWork.Save();
            return View("");
        }
    }
}
