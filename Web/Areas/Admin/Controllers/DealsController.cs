using AutoMapper;
using Core.Entites;
using Core.Entites.Catalog;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Deals;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]")]
    public class DealsController : Controller
    {
        private IUnitOfWork _unitOfWork { get; }
        public IMapper _mapper { get; }
        public IWebHostEnvironment _environment { get; }

        private readonly IPictureService _pictureService;
        private readonly ISlugService _slugService;

        public DealsController(IUnitOfWork unitOfWork,IMapper mapper ,IWebHostEnvironment environment , IPictureService picture,ISlugService slugService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _environment = environment;
            _pictureService = picture;
            _slugService = slugService;
        }

        public IActionResult Index()
        {
            var deals = _unitOfWork.dealRepo.getallDeals();
            return View(deals);
        }


        [HttpGet("Add")]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(DealVM model)
        {

            var picName = await _pictureService.UploadPictureAsync(model.Picture, _environment.WebRootPath);

            var picObj = new Picture
            {
                MimeType = picName,
            };

            await _unitOfWork.picture.Add(picObj);

            var deal = _mapper.Map<Deal>(model);


            string DealSlug = _slugService.createSlug(deal.Name);

            string uniqueSlug = _unitOfWork.dealRepo.MakeDealSlugUnique(DealSlug);

            deal.Slug = uniqueSlug;
            
            await _unitOfWork.dealRepo.Add(deal);

            _unitOfWork.Save();

            var addedpic = await _unitOfWork.picture.getPicByName(picName);

            var addedDeal =  _unitOfWork.dealRepo.geBySlug(deal.Slug);

            await _unitOfWork.dealRepo.AddPicture(addedDeal.Id, addedpic.Id);

            _unitOfWork.Save();
            return Redirect("/");
        }


        [HttpGet("Edit")]
        public IActionResult Edit(int id)
        {
            var deal = _unitOfWork.dealRepo.geById(id);
            var dealVm = _mapper.Map<DealVM>(deal);
            return View(dealVm);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(DealVM model)
        {

            var deal = _unitOfWork.dealRepo.geById(model.Id);
            //
            var picName = await _pictureService.UploadPictureAsync(model.Picture, _environment.WebRootPath);

            var picObj = new Picture
            {
                MimeType = picName,
            };
            await _unitOfWork.picture.Add(picObj);
            _unitOfWork.Save();

            //
            var pic = await _unitOfWork.picture.getPicByName(picName);

            await _unitOfWork.dealRepo.AddPicture(deal.Id, pic.Id);

            deal.Name = model.Name;
            deal.Description = model.Description;
            //mapping
            _unitOfWork.dealRepo.Update(deal);
            _unitOfWork.Save();
            return Redirect("/");
        }


        [HttpGet("AddDiscounts")]
        public IActionResult AddDiscounts(int dealID)
        {
            var discounts = _unitOfWork.discount.GetAll();
            var deal = _unitOfWork.dealRepo.geById(dealID);

            DealDiscountVM model = new DealDiscountVM
            {
                DealID = deal.Id,
                discounts = discounts
            };
            return View(model);
        }

        [HttpPost("AddDiscounts")]
        public async Task<IActionResult> AddDiscounts(DealDiscountVM model)
        {
            var dealDiscount = _mapper.Map<DealDiscount>(model);
            await _unitOfWork.dealRepo.AddDealDiscount(dealDiscount);
            _unitOfWork.Save();
            return Redirect("/");
        }


        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var deal = _unitOfWork.dealRepo.geById(id);
            _unitOfWork.dealRepo.Delete(deal);
            _unitOfWork.Save();
            return Redirect("/");
        }
    }
}
