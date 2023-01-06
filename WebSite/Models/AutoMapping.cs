using AutoMapper;
using DomainModel.Content;
using DomainModel.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Models;
using WebSite.Models.Content;
using WebSite.Models.Navigation;

namespace WebSite.Controllers
{
    public class AutoMapping:Profile 
    {
        public AutoMapping()
        {
            CreateMap<Page, PageViewModel>();
            CreateMap<PageViewModel, Page>();

            CreateMap<MenuViewModel, Menu>();
            CreateMap<Menu, MenuViewModel>();

            CreateMap<MenuItemViewModel, MenuItem>();
            CreateMap<MenuItem, MenuItemViewModel>();

            CreateMap<SliderViewModel, Slider>();
            CreateMap<Slider, SliderViewModel>();

            CreateMap<PartnersViewModel, Partner>();
            CreateMap<Partner, PartnersViewModel>();

            CreateMap<BlockViewModel, Block >();
            CreateMap<Block, BlockViewModel>();

            CreateMap<BlockListViewModel, BlockList>();
            CreateMap<BlockList, BlockListViewModel>();

            CreateMap<ArticleViewModel, Article>();
            CreateMap<Article, ArticleViewModel>();


            CreateMap<CallBackViewModelcs, Callback>();
            CreateMap<Callback, CallBackViewModelcs>();

            CreateMap<SaleViewModel, Sale>();
            CreateMap<Sale, SaleViewModel>();

            CreateMap<QuestionViewModel, Question>();
            CreateMap<Question, QuestionViewModel>();


        }
    }
}
