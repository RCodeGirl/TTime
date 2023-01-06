using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Interfaces.Content;
using WebSite.Models;
using Interfaces.Navigation;
using System.Collections.Generic;
using WebSite.Models.Navigation;
using WebSite.Models.Content;
using Microsoft.AspNetCore.Http;
using DomainModel.Content;

namespace WebSite.Controllers
{
    public class PageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPageService _pageService;
        private readonly IMenuItemService _menuItemService;
        private readonly ICallbackService _callbackService;
        private readonly IEmailSender _emailSender;
        private readonly ISaleService _saleService;
        private readonly IQuestionService _questionService;
        private readonly IBlockService _blockList;

        public PageController(IMapper mapper, IBlockService blockList, IPageService pageService, IQuestionService questionService, ISaleService saleService, IMenuItemService menuItemService, ICallbackService callbackService, IEmailSender emailSender)
        {
            _mapper = mapper;
            _pageService = pageService;
            _menuItemService = menuItemService;
            
            _emailSender = emailSender;
            _saleService = saleService;
            _questionService = questionService;
            _blockList = blockList;
        }
       
        public IActionResult Index(string stringKey, string customUrl, int id)
        {
            if(customUrl != null)
               return Redirect(customUrl);

            var page = _pageService.GetByKey(stringKey);
            if (page == null)
            {
                return NotFound();
            }

            var menu = _menuItemService.GetById(id);
            var menus = _mapper.Map<MenuItemViewModel>(menu);
            var otziv = _saleService.GetAll();
            var otzivi = _mapper.Map<List<SaleViewModel>>(otziv);
            var menuItem = _menuItemService.GetByParentId(331);
            var menuItems = _mapper.Map<List<MenuItemViewModel>>(menuItem);
            var question = _questionService.GetAll();
            var questions = _mapper.Map<List<QuestionViewModel>>(question);
            var block = _blockList.GetAll();
            var blocklist = _mapper.Map<List<BlockViewModel>>(block);
            var model = _mapper.Map<PageViewModel>(page);
            return View(new PageMenuItemViewModel { MenuItems= menuItems , Page= model,  Otzivi = otzivi, Question = questions, MenuItem = menus});
        }
    }
}
