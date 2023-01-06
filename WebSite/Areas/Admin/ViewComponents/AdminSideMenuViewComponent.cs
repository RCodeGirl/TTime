using System;
using System.Collections.Generic;

using System.Linq;

using Interfaces.Content;
using Microsoft.AspNetCore.Mvc;

using WebSite.Models.Common;


namespace WebSite.Areas.Admin.ViewComponents
{
    public class AdminSideMenuViewComponent : ViewComponent
    {

        private readonly ISettingService _settingService;

        public AdminSideMenuViewComponent(ISettingService settingService)
        {

            _settingService = settingService;
        }

        public IViewComponentResult Invoke()
        {
            var items = GetItems();
            return View(items);
        }

        #region PrivateMethods

        private List<SideMenuItemViewModel> GetItems()
        {
            #region AdminSideMenu


            var model = new List<SideMenuItemViewModel>
                {
                    new SideMenuItemViewModel
                    {
                        Title = "Main",
                        Action = "Index",
                        Controller = "Home"
                    },
                    new SideMenuItemViewModel
                    {
                        Title = "Меню",
                        Childs = new List<SideMenuItemViewModel>
                        {
                            new SideMenuItemViewModel {Title = "Все меню", Controller = "Menu", Action = "Menus"},
                            new SideMenuItemViewModel {Title = "Создать меню", Controller = "Menu", Action = "Create"}
                        },
                        Controller = "Menu"

                    },
                    new SideMenuItemViewModel
                    {
                        Title = "Страницы",
                        Childs = new List<SideMenuItemViewModel>
                        {
                            new SideMenuItemViewModel {Title = "Все страницы", Controller = "Page", Action = "Pages"},
                            new SideMenuItemViewModel {Title = "Создать страницу", Controller = "Page", Action = "AddPage"}
                        },
                        Controller = "Page"
                    },
                    new SideMenuItemViewModel
                    {
                        Title = "Пункты меню",
                        Childs = new List<SideMenuItemViewModel>
                        {
                            new SideMenuItemViewModel {Title = "Все пункты меню", Controller = "MenuItem", Action = "MenuItems"},
                            new SideMenuItemViewModel {Title = "Создать пункт меню", Controller = "MenuItem", Action = "AddMenuItem"}

                        },
                        Controller = "MenuItem"
                    },
                    new SideMenuItemViewModel
                    {
                        Title = "Слайдеры",
                        Childs = new List<SideMenuItemViewModel>
                        {
                            new SideMenuItemViewModel {Title = "Все слайдеры", Controller = "Slider", Action = "Sliders"},
                            new SideMenuItemViewModel {Title = "Добавить слайдер", Controller = "Slider", Action = "Add"}

                        },
                       Controller = "Slider"
                    },

                     new SideMenuItemViewModel
                    {
                        Title = "Партнеры",
                        Childs = new List<SideMenuItemViewModel>
                        {
                            new SideMenuItemViewModel {Title = "Все партнеры", Controller = "Partner", Action = "Partners"},
                            new SideMenuItemViewModel {Title = "Добавить партнера", Controller = "Partner", Action = "Add"}

                        },
                       Controller = "Partner"
                    },
                       new SideMenuItemViewModel
                       {
                          Title = "Пункты блоков",
                          Childs = new List<SideMenuItemViewModel>
                          {
                            new SideMenuItemViewModel {Title = "Пункты блока", Controller = "Block", Action = "Blocks"},
                            new SideMenuItemViewModel {Title = "Добавить пункт блока ", Controller = "Block", Action = "Add"}

                          },
                          Controller = "Block"
                       },
                    new SideMenuItemViewModel
                    {
                       Title = "Блок",
                      Childs = new List<SideMenuItemViewModel>
                      {
                       new SideMenuItemViewModel {Title = "Блоки", Controller = "BlockList", Action = "BlocksList"},
                       new SideMenuItemViewModel {Title = "Добавить блок ", Controller = "BlockList", Action = "Add"}

                      },
                      Controller = "BlockList"
                    },

                     new SideMenuItemViewModel
                    {
                       Title = "Причины работы",
                      Childs = new List<SideMenuItemViewModel>
                      {
                       new SideMenuItemViewModel {Title = "Причины", Controller = "Article", Action = "Articles"},
                       new SideMenuItemViewModel {Title = "Добавить причину ", Controller = "Article", Action = "Add"}

                      },
                      Controller = "Articles"
                    },
                     new SideMenuItemViewModel
                     {
                         Title = "Отзывы",
                         Childs = new List<SideMenuItemViewModel>
                         {
                             new SideMenuItemViewModel {Title = "Отзывы", Controller = "Sale", Action = "reviews"},
                             new SideMenuItemViewModel {Title = "Добавить отзыв ", Controller = "Sale", Action = "Add"}

                         },
                         Controller = "Sale"
                     },
                     new SideMenuItemViewModel
                     {
                         Title = "Вопросы",
                         Childs = new List<SideMenuItemViewModel>
                         {
                             new SideMenuItemViewModel {Title = "Вопросы", Controller = "Question", Action = "Questions"},
                             new SideMenuItemViewModel {Title = "Добавить вопрос ", Controller = "Question", Action = "Add"}

                         },
                         Controller = "Question"
                     }



                };
            SetIsActiveFotSelectedItem(model);
            return model;


            #endregion


            //return new List<SideMenuItemViewModel>();
        }

        private void SetIsActiveFotSelectedItem(List<SideMenuItemViewModel> model)
        {
            var currentController = ViewContext.RouteData.Values["Controller"].ToString();
            var currentAction = ViewContext.RouteData.Values["Action"].ToString();
            foreach (var item in model)
            {
                if (item.Controller != null &&
                    item.Controller.Equals(currentController, StringComparison.InvariantCultureIgnoreCase) ||
                    item.Childs.Any(
                        _ =>
                            _.Controller != null &&
                            _.Controller.Equals(currentController, StringComparison.InvariantCultureIgnoreCase)))
                    item.IsActive = true;

                if (item.Childs.Count <= 0)
                    continue;
                foreach (var child in item.Childs)
                    if (child.Controller != null &&
                        child.Controller.Equals(currentController, StringComparison.InvariantCultureIgnoreCase)
                        && child.Action.Equals(currentAction, StringComparison.InvariantCultureIgnoreCase))
                        child.IsActive = true;
            }
        }

        #endregion
    }
}