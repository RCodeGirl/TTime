using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using DomainModel.Content;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models.Navigation;
using Interfaces.Navigation;
using AutoMapper;
using DomainModel.Navigation;
using Interfaces.Content;
using WebSite.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MenuItemController : Controller
    {
        private readonly IMenuItemService _menuItemService;
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;
        private readonly IPageService _pageService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public MenuItemController(IMenuItemService menuItemService, IWebHostEnvironment hostingEnvironment, IMapper mapper, IPageService pageService, IMenuService menuService)
        {
            _menuItemService = menuItemService;
            _menuService = menuService;
            _mapper = mapper;
            _pageService = pageService;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult MenuItems()
        {
            var menuItem = _menuItemService.GetAll();
            var menuItems = _mapper.Map<List<MenuItemViewModel>>(menuItem);
            return View(menuItems);

        }
        [HttpGet]
        public IActionResult AddMenuItem(int menuId)
        {
            var menuItem = new MenuItemViewModel
            {
                MenuId = menuId,
                Pages = _mapper.Map<List<PageViewModel>>(_pageService.GetAll().ToList()),
                MenuItems = _mapper.Map<List<MenuItemViewModel>>(_menuItemService.GetAll().ToList()),
                Menus = _mapper.Map<List<MenuViewModel>>(_menuService.GetAll().ToList())
            };
            return View(menuItem);
        }
        [HttpPost]
        public IActionResult AddMenuItem(MenuItemViewModel model)
        {
            var menuItem = new MenuItem
            {
                Id = model.Id,
                Name = model.Name,
                StringKey = model.StringKey,
                MenuId = model.MenuId,
                PageId = model.PageId,
                ParentId = model.ParentId,
                Controller = model.Controller,
                Action = model.Action,
                CustomUrl = model.CustomUrl,
                IsHidden = model.IsHidden,
                isExternal = model.isExternal,
                Description = model.Description,
                Type = model.Type,
                Position = _menuItemService.GetPosition() + 1
            };
            if (model.Icon != null)
            {
                string filePath = $@"{_hostingEnvironment.WebRootPath}\img\MenuItem\{model.Icon.FileName}";
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    model.Icon.CopyTo(fs);
                    fs.Flush();
                }

                menuItem.IconClass = "/img/MenuItem/" + model.Icon.FileName;
            }
            else menuItem.IconClass = null;




            _menuItemService.Add(menuItem);

            return RedirectToAction("MenuItems"/*new { Id = model.MenuId }*/);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var menu = _menuItemService.GetById(id);
            var menuItem = _mapper.Map<MenuItemViewModel>(menu);
            menuItem.Pages = _mapper.Map<List<PageViewModel>>(_pageService.GetAll().ToList());
            menuItem.Menus = _mapper.Map<List<MenuViewModel>>(_menuService.GetAll().ToList());
            menuItem.MenuItems = _mapper.Map<List<MenuItemViewModel>>(_menuItemService.GetAll().ToList());
            return View(menuItem);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(MenuItemViewModel model)
        {
            var menuItem = new MenuItem
            {
                Id = model.Id,
                Name = model.Name,
                StringKey = model.StringKey,
                MenuId=model.MenuId,
                PageId = model.PageId,
                ParentId = model.ParentId,
                Controller = model.Controller,
                Action = model.Action,
                CustomUrl=model.CustomUrl,
                IsHidden=model.IsHidden,
                isExternal = model.isExternal,
                Type = model.Type,
                Description = model.Description,
                Position = model.Position
            };
            if (model.Icon != null)
            {
                string filePath = $@"{_hostingEnvironment.WebRootPath}\img\MenuItem\{model.Icon.FileName}";
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    model.Icon.CopyTo(fs);
                    fs.Flush();
                }
                menuItem.IconClass = "/img/MenuItem/" + model.Icon.FileName;
            }
            else menuItem.IconClass = model.IconClass;          

            _menuItemService.Update(menuItem);

            return RedirectToAction("MenuItems"/*new { Id = model.MenuId }*/);

        }

        public IActionResult Delete(int id)
        {
            _menuItemService.Delete(id);
            return RedirectToAction("MenuItems");
        }
    }
}
