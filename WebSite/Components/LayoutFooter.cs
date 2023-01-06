using AutoMapper;
using Interfaces.Content;
using Interfaces.Navigation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;
using WebSite.Models.Content;
using WebSite.Models.Home;
using WebSite.Models.Navigation;

namespace WebSite.Components
{
    public class LayoutFooter : ViewComponent
    {
        private readonly IBlockListService _blockListService;
        private readonly IBlockService _blockService;
        private readonly IMenuItemService _menuItemService;
        private readonly IPageService _pageService;
        private readonly IMapper _mapper;

        public LayoutFooter(IBlockListService blockListService, IBlockService blockService, IMapper mapper, IMenuItemService menuItemService, IPageService pageService)
        {
            _blockListService = blockListService;
            _blockService = blockService;
            _mapper = mapper;
            _menuItemService = menuItemService;
            _pageService = pageService;
        }

        public IViewComponentResult Invoke()
        {
            var blockList = _blockListService.GetAll();
            var blockLists = _mapper.Map<List<BlockListViewModel>>(blockList);
            var menuItem = _menuItemService.GetByParentId(331);
            var menuItems = _mapper.Map<List<MenuItemViewModel>>(menuItem);
            return View(new FooterViewModel { BlocLists = blockLists, MenuItems = menuItems});
        }


    }
}
