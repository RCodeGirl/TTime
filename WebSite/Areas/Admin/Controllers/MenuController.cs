using AutoMapper;
using DomainModel.Navigation;
using Interfaces.Navigation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models.Navigation;

namespace WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        
        public readonly IMapper _mapper;

        public MenuController(IMapper mapper, IMenuService menuService)
        {
            _menuService = menuService;
            _mapper = mapper;           
        }
       
        [HttpGet]
        public IActionResult Menus()
        {
            var menu = _menuService.GetAll();
            var menus = _mapper.Map<List<MenuViewModel>>(menu);
            return View(menus);

        }

        public ActionResult Create()
        {
            return View(new MenuViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuViewModel model )
        {
            var menu = new Menu
            {
                Id = model.Id,
                Name = model.Name,

            };
            _menuService.Create(menu);

            return RedirectToAction("Menus");
        }


        public ActionResult Edit(int id)
        {
            var page = _menuService.GetById(id);
            return View(_mapper.Map<MenuViewModel>(page));
        }

        // POST: MenuController/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuViewModel model)
        {
            var menu = new Menu
            {
                Id = model.Id,
                Name = model.Name,
                StringKey = model.StringKey                
               
            };
            _menuService.Edite(menu);

            return RedirectToAction("Menus");
        }
        public IActionResult Delete(int id)
        {
            _menuService.Delete(id);
            return RedirectToAction("Menus");
        }


    }
}
