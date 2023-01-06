using AutoMapper;
using Interfaces.Content;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;
using WebSite.Models.Content;
using WebSite.Models.Home;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISliderService _sliderService;
        private readonly IBlockListService _blockListService;
        private readonly IBlockService _blockService;
        private readonly IMapper _mapper;
        private readonly IPageService _pageService;
        private readonly IArticleService _articleService;
        private readonly IPartnersService _partnersService;

        public HomeController(ILogger<HomeController> logger, IPageService pageService, IPartnersService partnersService, IArticleService articleService, ISliderService sliderService, IMapper mapper, IBlockListService blockListService, IBlockService blockService)
        {
            _logger = logger;
            _sliderService = sliderService;
            _mapper = mapper;
            _blockListService = blockListService;
            _blockService = blockService;
            _articleService = articleService;
            _partnersService = partnersService;
            _pageService = pageService;
        }

        public IActionResult Index()
        {
            var pageHomeEntity= _pageService.GetByKey("Home");
            var pageHome = _mapper.Map<PageViewModel>(pageHomeEntity);
            var entity = _sliderService.GetAll();
            var sliders = _mapper.Map<List<SliderViewModel>>(entity);
            var article = _articleService.GetAll();
            var articles = _mapper.Map<List<ArticleViewModel>>(article);
            var partner = _partnersService.GetAll();
            var partners = _mapper.Map<List<PartnersViewModel>>(partner);          
            return View(new HomeViewModel { Sliders = sliders,Articles = articles, Partners = partners, PageView= pageHome });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      
    }
}
