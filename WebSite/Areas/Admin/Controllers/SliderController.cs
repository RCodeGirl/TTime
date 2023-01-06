using AutoMapper;
using Interfaces.Content;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models.Content;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using DomainModel.Content;

namespace WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        public readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public SliderController(ISliderService sliderService, IMapper mapper, IWebHostEnvironment hostingEnvironment )
        {
            _sliderService = sliderService;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        
        public IActionResult Sliders()
        {
            var slider = _sliderService.GetAll();
            var sliders = _mapper.Map < List <SliderViewModel>>(slider);
            return View(sliders);
        }
         [HttpGet]
        public IActionResult Add()
        {
            return View(new SliderViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(SliderViewModel model)
        {
            string filePath = $@"{_hostingEnvironment.WebRootPath}\img\Sliders\{model.Photo.FileName}";
            using (FileStream fs = System.IO.File.Create(filePath))
            {
                model.Photo.CopyTo(fs);
                fs.Flush();
            }
          
            var slider = new Slider
            {
               IsHidden = model.IsHidden,

               Description = model.Description,

               Title = model.Title,
       
               Url = model.Url,

               Image = "/img/Sliders/" + model.Photo.FileName,
              
            };
            _sliderService.Add(slider);

            return RedirectToAction("Sliders");                     
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var slider = _sliderService.GetById(id);
                return View(_mapper.Map<SliderViewModel>(slider));
            }
            return NotFound();

            
        }
        [HttpPost]
        public IActionResult Edit(SliderViewModel model)
        {

            var slider = new Slider
            {
                Id = model.Id,

                IsHidden = model.IsHidden,

                Title = model.Title,

                Description = model.Description,

                Url = model.Url
            
            };
            if (model.Photo != null)
            {
                string filePath = $@"{_hostingEnvironment.WebRootPath}\img\Sliders\{model.Photo.FileName}";
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    model.Photo.CopyTo(fs);
                    fs.Flush();
                }
               
                
                slider.Image = "/img/Sliders/" + model.Photo.FileName;
            }
            else 
            {
                slider.Image = model.Image;
                

            }                         
                            
            
             _sliderService.Update(slider);
            return RedirectToAction("Sliders");

        }

        public IActionResult Delete (int id)
        {
            _sliderService.Delete(id);
            return RedirectToAction("Sliders");
        }
    }

 }

