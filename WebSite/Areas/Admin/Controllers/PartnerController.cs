using AutoMapper;
using DomainModel.Content;
using Interfaces.Content;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models.Content;

namespace WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PartnerController : Controller
    {
        private readonly IPartnersService _partnersService;
        public readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PartnerController(IPartnersService partnersService, IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
            _partnersService = partnersService;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Partners()
        {
            var partner = _partnersService.GetAll();
            var partners = _mapper.Map<List<PartnersViewModel>>(partner);
            return View(partners);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new PartnersViewModel());
        }
        [HttpPost]
        public IActionResult Add(PartnersViewModel model)
        {
            string filePath = $@"{_hostingEnvironment.WebRootPath}\img\Partner\{model.Photo.FileName}";
            using (FileStream fs = System.IO.File.Create(filePath))
            {
                model.Photo.CopyTo(fs);
                fs.Flush();
            }

            var partner = new Partner
            {
                IsHidden = model.IsHidden,

                Name = model.Name,

                Url = model.Url,

                Picture = "/img/Partner/" + model.Photo.FileName
            };
            _partnersService.Add(partner);

            return RedirectToAction("Partners");
        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            var partner = _partnersService.GetById(id);
            return View(_mapper.Map<PartnersViewModel>(partner));          

        }
        [HttpPost]
        public IActionResult Edit (PartnersViewModel model)
        {
            var partner = new Partner
            {
                Id = model.Id,

                Name = model.Name,

                Activities = model.Activities,

                Company = model.Company,

                IsHidden = model.IsHidden
            };
            if (model.Photo != null)
            {
                string filePath = $@"{_hostingEnvironment.WebRootPath}\img\Partner\{model.Photo.FileName}";
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    model.Photo.CopyTo(fs);
                    fs.Flush();
                }
                partner.Picture = "/img/Partner/" + model.Photo.FileName;
            }
            else partner.Picture = model.Picture;
            _partnersService.Update(partner);
            return RedirectToAction("Partners");
        }

        public IActionResult Delete (int id)
        {
            _partnersService.Delete(id);
            return RedirectToAction("Partners");
        }
    }
}
