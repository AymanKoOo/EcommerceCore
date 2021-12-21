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
    public class SpecificationAttributeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISpecificationAttributeModelFactory specificationAttributeModelFactory;

        public SpecificationAttributeController(IUnitOfWork unitOfWork, IMapper mapper, ISpecificationAttributeModelFactory specificationAttributeModelFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.specificationAttributeModelFactory = specificationAttributeModelFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        //    GROUP ATTRIBUTE   //
        [HttpGet("CreateAttributeGroupAsync")]

        public IActionResult CreateAttributeGroupAsync()
        {
            return View();
        } 

        [HttpPost("CreateAttributeGroupAsync")]

        public IActionResult CreateAttributeGroupAsync(SpecificationAttributeGroup model)
        {
            _unitOfWork.SpecificationAttributes.AddSpecificationAttributeGroup(model);
            _unitOfWork.Save();
            return View();
        }

        //    GROUP SpecificationAttribute   //
        [HttpGet("CreateSpecificationAttribute")]
        public async Task<IActionResult> CreateSpecificationAttribute()
        {
            var model = await specificationAttributeModelFactory.PrepareSpecificationAttributeModel();
            return View(model);
        }

        [HttpPost("CreateSpecificationAttribute")]
        public IActionResult CreateSpecificationAttribute(SpecificationAttribute model)
        {
            var modelSp = _mapper.Map<SpecificationAttribute>(model);
            _unitOfWork.SpecificationAttributes.CreateSpecificationAttribute(modelSp);
            _unitOfWork.Save();
            return View("/");
        }


        //  Option ATTRIBUTE   //
        [HttpGet("CreateAttributeOption")]
        public async Task<IActionResult> CreateAttributeOption()
        {
            var model = await specificationAttributeModelFactory.PrepareSpecificationAttributeOptionModel();
            return View(model);
        }

        [HttpPost("CreateAttributeOption")]
        public IActionResult CreateAttributeOption(ASpecificationAttributeOptionModel model)
        {
            var modelSp = _mapper.Map<SpecificationAttributeOption>(model);
            _unitOfWork.SpecificationAttributes.CreateSpecificationAttributeOption(modelSp);
            _unitOfWork.Save();
            return View("/");
        }
    }
}
