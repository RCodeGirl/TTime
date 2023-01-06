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
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleServices;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public ArticleController(IArticleService articleServices, IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
            _articleServices = articleServices;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        
        public IActionResult Articles()
        {
            var article =  _articleServices.GetAll();
            var atricles = _mapper.Map<List<ArticleViewModel>>(article);
            return View(atricles);

        }
        [HttpGet]
        public IActionResult Add()
        {
          return View(new ArticleViewModel());
        }
        [HttpPost]
        public IActionResult Add(ArticleViewModel model)
        {
            
            string filePath = $@"{_hostingEnvironment.WebRootPath}\img\Articles\{model.Photo.FileName}";
            using (FileStream fs = System.IO.File.Create(filePath))
            {
                model.Photo.CopyTo(fs);
                fs.Flush();
            }
            var article = new Article
            {
                Id = model.Id,
                StringKey = model.StringKey,
                Description = model.Description,
                ImgPreview = "/img/Articles/" + model.Photo.FileName,
                MetaTitle = model.MetaTitle,
                MetaDescription = model.MetaDescription,
                MetaKeywords = model.MetaKeywords,
                Title = model.Title

            };

            _articleServices.Add(article);
            return RedirectToAction("Articles");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var article = _articleServices.GetById(id);
            return View(_mapper.Map<ArticleViewModel>(article)); 
        }
        [HttpPost]
        public IActionResult Edit (ArticleViewModel model)
        {
            var artcile = new Article
            {
                Id=model.Id,
                StringKey = model.StringKey,
                Description = model.Description,                
                MetaTitle = model.MetaTitle,
                MetaDescription = model.MetaDescription,
                MetaKeywords = model.MetaKeywords,
                Title = model.Title
            };
            if (model.Photo != null)
            {
                string filePath = $@"{_hostingEnvironment.WebRootPath}\img\Articles\{model.Photo.FileName}";
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    model.Photo.CopyTo(fs);
                    fs.Flush();
                }
                artcile.ImgPreview = "/img/Articles/" + model.Photo.FileName;
            }
            else artcile.ImgPreview = model.ImgPreview;
            _articleServices.Update(artcile);
            return RedirectToAction("Articles");
        }
        public IActionResult Delete (int id)
        {
            _articleServices.Delete(id);
            return RedirectToAction("Articles");
        }

    }
}
