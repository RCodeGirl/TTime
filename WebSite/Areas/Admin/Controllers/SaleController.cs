using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Content;
using AutoMapper;
using DomainModel.Content;
using Microsoft.AspNetCore.Hosting;
using WebSite.Models.Content;
using Microsoft.AspNetCore.Authorization;

namespace WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SaleController(ISaleService saleService, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _saleService = saleService;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult reviews()
        {
            var review = _saleService.GetAll();
            var reviews = _mapper.Map<List<SaleViewModel>>(review);
            return View(reviews); 
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new SaleViewModel());
        }

        [HttpPost]
        public IActionResult Add(SaleViewModel model)
        {
            string filePath = $@"{_hostEnvironment.WebRootPath}\img\Sale\{model.Photo.FileName}";
            using (FileStream fs = System.IO.File.Create(filePath))
            {
                model.Photo.CopyTo(fs);
                fs.Flush();
            }

            var review = new Sale
            {
                IsHidden = model.IsHidden,

                Name = model.Name,

                ImgPreview = "/img/Sale/" + model.Photo.FileName
            };
           _saleService.Create(review);

            return RedirectToAction("reviews");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var review = _saleService.GetById(id);
            return View(_mapper.Map<SaleViewModel>(review));

        }

        [HttpPost]
        public IActionResult Update(SaleViewModel model)
        {
            var review = new Sale
            {
                Name = model.Name,
                IsHidden =  model.IsHidden
            };

            if (model.Photo != null)
            {
                string filePath = $@"{_hostEnvironment.WebRootPath}\img\Sale\{model.Photo.FileName}";
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    model.Photo.CopyTo(fs);
                    fs.Flush();
                }

                review.ImgPreview = "/img/Sale/" + model.Photo.FileName;
            }
            else review.ImgPreview = model.ImgPreview;

            _saleService.Edite(review);
            return RedirectToAction("reviews");
        }

        public IActionResult Delete(int Id)
        {
            _saleService.Delete(Id);
            return RedirectToAction("reviews");

        }
    }
}
