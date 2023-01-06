using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using Interfaces.Content;
using Interfaces.Navigation;
using Microsoft.AspNetCore.Mvc;
using WebSite.Models.Content;
using WebSite.Models.Home;
using WebSite.Models.Navigation;

namespace WebSite.Components
{
    public class PageMenu : ViewComponent
    {
        private readonly IMenuItemService _menuItemService;
        private readonly IMapper _mapper;
        private readonly IBlockService _blockService;
        public  PageMenu(IMenuItemService menuItemService,  IBlockService blockService, IMapper mapper  )
        {
            _menuItemService = menuItemService;
            _mapper = mapper;
            _blockService = blockService;

        }

        public IViewComponentResult Invoke()
        {
           var menuItem = _menuItemService.GetByMenuKey("TopMenu");
           var menuItems= _mapper.Map<List<MenuItemViewModel>>(menuItem);

            var bloc = _blockService.GetAll(); 
           var blocs = _mapper.Map<List<BlockViewModel>>(bloc);

            return View(new HomeMenuViewModel { Blocks = blocs, MenuItems = menuItems });
        }
    }

}
