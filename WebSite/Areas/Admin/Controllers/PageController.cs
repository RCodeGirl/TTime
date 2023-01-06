using Interfaces.Content;
using Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;
using DomainModel.Content;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PageController : Controller
    {
        private readonly IPageService pageService;
        public readonly IMapper _mapper;


        public PageController(IPageService pageService, IMapper _mapper)
        {
            this.pageService = pageService;
            this._mapper = _mapper;
        }
        [HttpGet]
        public IActionResult Pages()
        {
            var page = pageService.GetAll();
            var pages = _mapper.Map<List<PageViewModel>>(page);
            return View(pages);
        }

        [HttpGet]
        public IActionResult AddPage()
        {
            
            return View(new PageViewModel());
        }
        [HttpPost]
        public IActionResult AddPage(PageViewModel model)
        {
            var page = new Page
            {
                Id = model.Id,
                //IsHidden = model.IsHidden,
                StringKey = model.StringKey,
                Name = model.Name,
                Content = model.Content,
                IsSection = model.IsSection,
                MetaTitle = model.MetaTitle,
                MetaKeywords = model.MetaKeywords,
                MetaDescription = model.MetaDescription
            };
            pageService.Add(page);

            return RedirectToAction("Pages");
        }
        [HttpGet]
       public IActionResult Edit (int id)
        {
           
            var page = pageService.GetById(id);
            return View(_mapper.Map<PageViewModel>(page));
        }
        [HttpPost]
        public IActionResult Edit(  PageViewModel model)
        {
            var page = new Page
            {
                Id = model.Id,
                //IsHidden = model.IsHidden,
                StringKey = model.StringKey,
                Name = model.Name,
                Content = model.Content,
                IsSection = model.IsSection,
                MetaTitle = model.MetaTitle,
                MetaKeywords = model.MetaKeywords,
                MetaDescription = model.MetaDescription
            };
            pageService.UpdatePage( page);

            return RedirectToAction("Pages");
        }

        public IActionResult Details (int id)
        {
            var page = pageService.GetById(id);
            return View(_mapper.Map<PageViewModel>(page));
        }

        public IActionResult Delete(int id)
        {
            pageService.Delete(id);
            return RedirectToAction("Pages");
        }
    }       

 }

