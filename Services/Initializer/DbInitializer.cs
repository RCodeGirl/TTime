using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Content;
using DomainModel.Navigation;
using Interfaces.Initializer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    if (!context.Roles.Any())
                    {
                        var roles = new List<IdentityRole>();
                        roles.Add(new IdentityRole
                        {
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            ConcurrencyStamp = Guid.NewGuid().ToString()
                        });
                        roles.Add(new IdentityRole
                        {
                            Name = "User",
                            NormalizedName = "USER",
                            ConcurrencyStamp = Guid.NewGuid().ToString()
                        });

                        foreach (var role in roles)
                            context.Roles.Add(role);
                    }
                    if (!context.Blocks.Any())
                    {
                        List<Block> blocks = new();

                        var blockAdrdess = new Block
                        {
                            Title = "Адрес и Ориентир",
                            StringKey = "Adrdess",
                            Description = "г. Тирасполь, ул. Свердлова, 74",
                            IsHidden = false
                        };
                        var blockMail = new Block
                        {
                            Title = "Почтовый ящик",
                            StringKey="E-mail",
                            Description = "г. Тирасполь, ул. Свердлова, 74",
                            IsHidden = false
                        };
                        var blockPhone = new Block
                        {
                            Title = "Телефон и «во внерабочее время",
                            StringKey = "Phone",
                            Description = "0 (779) 888 79, Во внерабочее время на связи дежурный менеджер",
                            IsHidden = false
                        };
                        var blockSchedule = new Block
                        {
                            Title = "График работы",
                            StringKey = "Schedule",
                            Description = "Пн.–Пт.:  09:00 – 18:00 Перерыв:  13:00 – 14:00  Сб. – Вс.:        Выходной",
                            IsHidden = false
                        };

                     context.Blocks.Add(blockAdrdess);
                     context.Blocks.Add(blockMail);
                     context.Blocks.Add(blockPhone);
                     context.Blocks.Add(blockSchedule);
                     context.SaveChanges();

                    }
                    if (!context.Sliders.Any())
                    {
                        List<Slider> sliders = new();

                        var Slider1 = new Slider
                        {
                            Title = "МЫ ПЕРЕЕХАЛИ В НОВЫЙ ОФИС!",
                            Image = ""

                        };
                        var Slider2 = new Slider
                        {
                            Title = "ХОТИТЕ УЗНАТЬ СТОИМОСТЬ ПЕРЕВОДА? ПИШИТЕ ИЛИ ЗВОНИТЕ НАМ!",
                            Image = ""
                        };
                        var Slider3 = new Slider
                        {
                            Title = "ПЕРЕВОД ДОКУМЕНТОВ Официальный перевод документов с / на 17 иностранных языков.Нотариальное " +
                            "заверение перевода.Выполнение в срочном порядке и без очереди",
                            Image = ""
                        };
                        var Slider4 = new Slider
                        {
                            Title = "ПЕРЕВОД ТЕКСТОВ ЛЮБОЙ СЛОЖНОСТИ И ТЕМАТИКИ",
                            Image = ""
                        };
                        var Slider5 = new Slider
                        {
                            Title = "",
                            Image = ""
                        };
                        var Slider6 = new Slider
                        {
                            Title = "ПЕРЕВОД ТЕХПАСПОРТА У НАС –ЗАЯВЛЕНИЕ НА УЧЕТ В ГАИ И ЭКЦ!",
                            Image = ""
                        };
                        var Slider7 = new Slider
                        {
                            Title = "ПО ВАШЕМУ ЗАПРОСУ ВОЗМОЖНО ОКАЗАНИЕ УСЛУГ В ВЫХОДНЫЕ И ПРАЗДНИЧНЫЕ ДНИ. ПОЛНАЯ СТОИМОСТЬ ЗАКАЗА ПРИ ЭТОМ" +
                            "ОПЛАЧИВАЕТСЯ В ДВОЙНОМ РАЗМЕРЕ!",
                            Image = ""
                        };

                        context.Sliders.Add(Slider1);
                        context.Sliders.Add(Slider2);
                        context.Sliders.Add(Slider3);
                        context.Sliders.Add(Slider4);
                        context.Sliders.Add(Slider5);
                        context.Sliders.Add(Slider6);
                        context.Sliders.Add(Slider7);

                        context.SaveChanges();

                    }
                    if (!context.Partners.Any())
                    {
                        List<Partner> partners = new();

                        var partnetVivaFarm = new Partner
                        {
                            Name = "ООО «Вивафарм»",
                            Url = "https://vivafarm.md/",
                            Company = "ООО «Вивафарм»",
                            Picture = "~/Img/Partners/Вивафарм.jpg",
                            IsHidden = true


                        };
                        var partnetKeiser = new Partner
                        {
                            Name = "ООО «Кейсер» ",
                            Url = "https://pmr.md/197d42e5f790f95092b389c2a5d42a7a/aptechnaya_set_stoletnik_ooo_keyser.html",
                            Company = "ООО «Кейсер»",
                            Picture = "~/Img/Partners/Кейсер.jpg",
                            IsHidden = false

                        };
                        var partnetSherif = new Partner
                        {
                            Name = "ООО «Шериф» ",
                            Url = "",
                            Company = "ООО «Шериф»",
                            Picture = "~/Img/Partners/шериф.png",
                            IsHidden = false

                        };
                        var partnerProvizor = new Partner
                        {
                            Name = "ООО «Провизор.ком»» ",
                            Url = "",
                            Company = "ООО «Провизор.ком»",
                            Picture = "~/Img/Partners/Провизор.png",
                            IsHidden = false

                        };
                        var partnerEcsimBanc = new Partner
                        {
                            Name = "ОАО «Эксимбанк» ",
                            Url = "",
                            Company = "ОАО «Эксимбанк»",
                            Picture = "~/Img/Partners/эксимбанк.jpg",
                            IsHidden = false

                        };
                        var partnerTirotex = new Partner
                        {
                            Name = "ЗАО «Тиротекс»",
                            Url = "",
                            Company = "ЗАО «Тиротекс»",
                            Picture = "~/Img/Partners/тиротекс.png",
                            IsHidden = false

                        };
                        var partnerRCZ = new Partner
                        {
                            Name = "ЗАО «Рыбницкий цементный комбинат»",
                            Url = "",
                            Company = "ЗАО «Рыбницкий цементный комбинат»",
                            Picture = "~/Img/Partners/РЦЗ.png",
                            IsHidden = false

                        };
                        var partnerMasterMebeli = new Partner
                        {
                            Name = "ООО «Мебели Мастер»",
                            Url = "",
                            Company = "ООО «Мебели Мастер»",
                            Picture = "~/Img/Partners/Мебели Мастер.png",
                            IsHidden = false

                        };
                        var partnerRezultat = new Partner
                        {
                            Name = "ООО «Результатъ»",
                            Url = "",
                            Company = "ООО «Результатъ»",
                            Picture = "~/Img/Partners/Результатъ.png",
                            IsHidden = false

                        };
                        var partnerAlize = new Partner
                        {
                            Name = "ООО «Ализе»",
                            Url = "",
                            Company = "ООО «Ализе»",
                            Picture = "~/Img/Partners/Ализе.png",
                            IsHidden = false

                        };
                        var partnerMedfarm = new Partner
                        {
                            Name = "ООО «Медфарм»",
                            Url = "",
                            Company = "ООО «Медфарм»",
                            Picture = "~/Img/Partners/Медфарм.jpg",
                            IsHidden = false

                        };

                        context.Partners.Add(partnetVivaFarm);
                        context.Partners.Add(partnetKeiser);
                        context.Partners.Add(partnetSherif);
                        context.Partners.Add(partnerProvizor);
                        context.Partners.Add(partnerEcsimBanc);
                        context.Partners.Add(partnerTirotex);
                        context.Partners.Add(partnerRCZ);
                        context.Partners.Add(partnerMasterMebeli);
                        context.Partners.Add(partnerRezultat);
                        context.Partners.Add(partnerAlize);
                        context.Partners.Add(partnerMedfarm);

                    }
                    if (!context.Menus.Any())
                    {
                        #region Page

                        #region AboutUs
                        List<Page> pages = new();
                        var page1 = new Page
                        {
                            Name = "O нас",
                            StringKey = "About",
                            Content = "About",

                        };
                        var page11 = new Page
                        {
                            Name = "O компании",
                            StringKey = "AboutCompany",
                            Content = "AboutCompany",
                        };
                        var page12 = new Page
                        {
                            Name = "Отзывы",
                            StringKey = "Otzivi",
                            Content = "Otzivi",
                        };
                        var page13 = new Page
                        {
                            Name = "Скидки",
                            StringKey = "Sale",
                            Content = "Sale",
                        };
                        

                       
                        #endregion
                        #region Services

                        var pageServices = new Page
                        {
                            Name = "ПЕРЕВОДЫ",
                            StringKey = "Services",
                            Content = "Services",

                        };
                        var pageDocuments= new Page
                        {
                            Name = "Перевод личных документов",
                            StringKey = "Documents",
                            Content = "Documents",

                        };
                        var pageMedical = new Page
                        {
                            Name = "Медицинский перевод",
                            StringKey = "Medical",
                            Content = "Medical",

                        };
                        var pageJudicial = new Page
                        {
                            Name = "Юридический перевод",
                            StringKey = "Judicial",
                            Content = "Judicial",

                        };
                        var pageTehnical = new Page
                        {
                            Name = "Технический перевод",
                            StringKey = "Tehnical",
                            Content = "Tehnical",

                        };
                        var pagePharmaceutical = new Page
                        {
                            Name = "Фармацевтический перевод",
                            StringKey = "Pharmaceutical",
                            Content = "Pharmaceutical",

                        };
                        var pageMarketing = new Page
                        {
                            Name = "Маркетинговый перевод",
                            StringKey = "Marketing",
                            Content = "Marketing",

                        };
                        var pageFinancial = new Page
                        {
                            Name = "Финансовый перевод",
                            StringKey = "Financial",
                            Content = "Financial",

                        };
                        var pageLiterary = new Page
                        {
                            Name = "Литературный перевод",
                            StringKey = "Literary ",
                            Content = "Literary ",

                        };

                        #endregion
                        #region Price
                        var pagePrice = new Page
                        {
                            Name = "ЦЕНЫ",
                            StringKey = "Price",
                            Content = "Price",

                        };
                        #endregion
                        #region Delivery

                        var pageDelivery = new Page
                        {
                            Name = "СПОСОБЫ ПОЛУЧЕНИЯ",
                            StringKey = "Delivery",
                            Content = "Delivery",

                        };
                        var pagePayment = new Page
                        {
                            Name = "СПОСОБЫ ОПЛАТЫ",
                            StringKey = "Payment",
                            Content = "Payment",

                        };

                        #endregion
                        #region Vacancy

                        var pageVacancy = new Page
                        {
                            Name = "ВАКАНСИИ",
                            StringKey = "Vacancy",
                            Content = "Vacancy",

                        };

                        #endregion
                        #region ForClient

                        var pageDetailsPrice = new Page
                        {
                            Name = "Основные нюансы при просчете стоимости перевода",
                            StringKey = "DetailsPrice",
                            Content = "DetailsPrice",

                        };
                        var pageDetailsPrice1 = new Page
                        {
                            Name = "Как формируется цена на услуги перевода",
                            StringKey = "DetailsPrice",
                            Content = "DetailsPrice",

                        };
                        var pageDetailsPrice2 = new Page
                        {
                            Name = "Стандартный документ и учетная страница перевода",
                            StringKey = "DetailsPrice",
                            Content = "DetailsPrice",

                        };
                        var pageDetailsPrice3 = new Page
                        {
                            Name = "Как посчитать количество символов (печатных знаков)",
                            StringKey = "DetailsPrice",
                            Content = "DetailsPrice",

                        };
                        var pageDetailsPrice4 = new Page
                        {
                            Name = "Коэффициенты расширения языковых пар",
                            StringKey = "DetailsPrice",
                            Content = "DetailsPrice",

                        };
                        var pageDetailsPrice5 = new Page
                        {
                            Name = "Как рассчитать стоимость перевода самостоятельно",
                            StringKey = "DetailsPrice",
                            Content = "DetailsPrice",

                        };

                        var pageSecurity = new Page
                        {
                            Name = "Безопасность и защита переводов",
                            StringKey = "Security ",
                            Content = "Security ",

                        };
                        var pageSecurity1 = new Page
                        {
                            Name = "Конфиденциальность информации",
                            StringKey = "Security ",
                            Content = "Security ",

                        };
                        var pageSecurity2 = new Page
                        {
                            Name = "Для чего необходим SSL-сертификат",
                            StringKey = "Security ",
                            Content = "Security ",

                        };
                        var pageSecurity3 = new Page
                        {
                            Name = "Защита электронной почты",
                            StringKey = "Security ",
                            Content = "Security ",

                        };

                        var pageDecorations = new Page
                        {
                            Name = "Правила оформления переводов",
                            StringKey = "Decorations ",
                            Content = "Decorations ",

                        };
                        var pageDecorations1 = new Page
                        {
                            Name = "Как подготовить документы для перевода",
                            StringKey = "Decorations ",
                            Content = "Decorations ",

                        };
                        var pageDecorations2 = new Page
                        {
                            Name = "Заверение печатью бюро переводов",
                            StringKey = "Decorations ",
                            Content = "Decorations ",

                        };
                        var pageDecorations3 = new Page
                        {
                            Name = "Нотариальное заверение перевода",
                            StringKey = "Decorations ",
                            Content = "Decorations ",

                        };

                        var pageHalper = new Page
                        {
                            Name = "В помощь заказчику",
                            StringKey = "Halper",
                            Content = "Halper",

                        };
                        var pageHalper1 = new Page
                        {
                            Name = "Особенности дословного перевода",
                            StringKey = "Halper",
                            Content = "Halper",

                        };
                        var pageHalper2 = new Page
                        {
                            Name = "Срочный перевод и его тонкости",
                            StringKey = "Halper",
                            Content = "Halper",

                        };
                        var pageHalper3 = new Page
                        {
                            Name = "Разница машинного и профессионального перевода",
                            StringKey = "Halper",
                            Content = "Halper",

                        };
                        var pageHalper4 = new Page
                        {
                            Name = "Словарь терминов",
                            StringKey = "Halper",
                            Content = "Halper",

                        };


                        #endregion
                        #region Question

                        var pageQuestions = new Page
                        {
                            Name = "ВОПРОС-ОТВЕТ",
                            StringKey = "Questions",
                            Content = "Questions",

                        };
                        #endregion

                        #region Contacts

                        var pageContacts = new Page
                        {
                            Name = "КОНТАКТЫ",
                            StringKey = "Contacts",
                            Content = "Contacts",

                        };
                        #endregion

                        #region Add
                        
                        context.Pages.Add(pageContacts);
                        context.Pages.Add(pageQuestions);
                        context.Pages.Add(pageHalper); context.Pages.Add(pageHalper1); context.Pages.Add(pageHalper2); context.Pages.Add(pageHalper3); context.Pages.Add(pageHalper4);
                        context.Pages.Add(pageDecorations); context.Pages.Add(pageDecorations1); context.Pages.Add(pageDecorations2); context.Pages.Add(pageDecorations3);
                        context.Pages.Add(pageDetailsPrice); context.Pages.Add(pageDetailsPrice1); context.Pages.Add(pageDetailsPrice2); context.Pages.Add(pageDetailsPrice3); context.Pages.Add(pageDetailsPrice4); context.Pages.Add(pageDetailsPrice5);
                        context.Pages.Add(pageSecurity); context.Pages.Add(pageSecurity1); context.Pages.Add(pageSecurity2); context.Pages.Add(pageSecurity3);
                        context.Pages.Add(page1);
                        context.Pages.Add(page11);
                        context.Pages.Add(page12);
                        context.Pages.Add(page13);
                        context.Pages.Add(pageServices);
                        context.Pages.Add(pageDocuments);
                        context.Pages.Add(pageMedical);
                        context.Pages.Add(pageJudicial);
                        context.Pages.Add(pageTehnical);
                        context.Pages.Add(pagePharmaceutical);
                        context.Pages.Add(pageMarketing);
                        context.Pages.Add(pageFinancial);
                        context.Pages.Add(pageLiterary);
                        context.Pages.Add(pagePrice);
                        context.Pages.Add(pageDelivery);
                        context.Pages.Add(pagePayment);
                        context.Pages.Add(pageVacancy);
                        context.SaveChanges();

                        #endregion

                        #endregion

                        #region menu
                        List<Menu> menus = new();
                        var topMenu = new Menu
                        {
                            Name = "Верхнее Меню",
                            StringKey = "TopMenu"
                        };
                        //var footerMenu = new Menu
                        //{
                        //    Name = "Нижнее Меню",
                        //    StringKey = "FooterMenu"
                        //};
                        context.Menus.Add(topMenu);//, footerMenu
                           
                        context.SaveChanges();
                        #endregion

                        #region menuItems

                        #region AboutUs

                        List<MenuItem> menuItems = new();
                        var topMenuItem1 = new MenuItem
                        {
                            Name = "О НАС",
                            StringKey = "AboutCompany",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = page1.Id
                        };
                        var topMenuItem11 = new MenuItem
                        {
                            Name = "О КОМПАНИИ",
                            StringKey = "AboutCompany",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = page11.Id,
                            Parent = topMenuItem1
                        };
                        var topMenuItem12 = new MenuItem
                        {
                            Name = "ОТЗЫВЫ",
                            StringKey = "Otzivi",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = page12.Id,
                            Parent = topMenuItem1
                        };
                        var topMenuItem13 = new MenuItem
                        {
                            Name = "СКИДКИ И АКЦИИ",
                            StringKey = "Sale",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = page13.Id,
                            Parent = topMenuItem1
                        };

                        #endregion
                        #region Services

                        var menuItemServices = new MenuItem
                        {
                            Name = "ПЕРЕВОДЫ",
                            StringKey = "Services",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageServices.Id

                        };
                        var menuItemDocuments = new MenuItem
                        {
                            Name = "Перевод личных документов",
                            StringKey = "Services",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageDocuments.Id,
                            Parent= menuItemServices
                            // ParentId = menuItemServices.Id

                        };
                        var menuItemMedical = new MenuItem
                        {
                            Name = "Медицинский перевод",
                            StringKey = "Services",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageMedical.Id,
                            Parent = menuItemServices
                            // ParentId = menuItemServices.Id

                        };
                        var menuItemJudicial = new MenuItem
                        {
                            Name = "Юридический перевод",
                            StringKey = "Services",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageJudicial.Id,
                            Parent = menuItemServices
                            // ParentId = menuItemServices.Id

                        };
                        var menuItemTehnical = new MenuItem
                        {
                            Name = "Технический перевод",
                            StringKey = "Services",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageTehnical.Id,
                            Parent = menuItemServices
                            //  ParentId = menuItemServices.Id

                        };
                        var menuItemPharmaceutical = new MenuItem
                        {
                            Name = "Фармацевтический перевод",
                            StringKey = "Services",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pagePharmaceutical.Id,
                            Parent = menuItemServices
                            //ParentId = menuItemServices.Id

                        };
                        var menuItemMarketing = new MenuItem
                        {
                            Name = "Маркетинговый перевод",
                            StringKey = "Services",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageMarketing.Id,
                            Parent = menuItemServices
                            //ParentId = menuItemServices.Id

                        };
                        var menuItemFinancial = new MenuItem
                        {
                            Name = "Финансовый перевод",
                            StringKey = "Services",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageFinancial.Id,
                            Parent = menuItemServices
                            // ParentId = menuItemServices.Id

                        };
                        var menuItemLiterary = new MenuItem
                        {
                            Name = "Финансовый перевод",
                            StringKey = "Services",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageLiterary.Id,
                            Parent = menuItemServices
                            //  ParentId = menuItemServices.Id

                        };

                        #endregion
                        #region Price

                        var menuItemPrice = new MenuItem
                        {
                            Name = "ЦЕНЫ",
                            StringKey = "Price",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pagePrice.Id

                        };

                        #endregion
                        #region Delivery

                        var menuItemDeliveryendPayment = new MenuItem
                        {
                            Name = "ОПЛАТА И ДОСТАВКА ",
                            StringKey = "Delivery",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageDelivery.Id

                        };
                        var menuItemDelivery = new MenuItem
                        {
                            Name = "СПОСОБЫ ПОЛУЧЕНИЯ",
                            StringKey = "Delivery",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageDelivery.Id,
                            Parent= menuItemDeliveryendPayment
                            // ParentId= menuItemDeliveryendPayment.Id

                        };
                        var menuItemPayment = new MenuItem
                        {
                            Name = "СПОСОБЫ ОПЛАТЫ",
                            StringKey = "Delivery",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pagePayment.Id,
                            Parent = menuItemDeliveryendPayment
                            //ParentId = menuItemDeliveryendPayment.Id

                        };

                        #endregion
                        #region Vacancy

                        var menuItemVacancy = new MenuItem
                        {
                            Name = "Вакансии",
                            StringKey = "Vacancy",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageVacancy.Id

                        };

                        #endregion
                        #region ForClient

                        var menuItemForClient = new MenuItem
                        {
                            Name = "ДЛЯ КЛИЕНТА",
                            StringKey = "ForClient",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,

                        };
                        var menuItemDetailsPrice = new MenuItem
                        {
                            Name = "Основные нюансы при просчете стоимости перевода",
                            StringKey = "DetailsPrice",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageDetailsPrice.Id,
                            Parent= menuItemForClient
                            // ParentId= menuItemForClient.Id



                        };
                        var menuItemDetailsPrice1 = new MenuItem
                        {
                            Name = "Как формируется цена на услуги перевода",
                            StringKey = "DetailsPrice",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageDetailsPrice1.Id,
                            Parent= menuItemDetailsPrice
                            //ParentId = menuItemDetailsPrice.Id

                        };
                        var menuItemDetailsPrice2 = new MenuItem
                        {
                            Name = "Стандартный документ и учетная страница перевода",
                            StringKey = "DetailsPrice",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageDetailsPrice2.Id,
                            Parent = menuItemDetailsPrice
                            //  ParentId = menuItemDetailsPrice.Id

                        };
                        var menuItemDetailsPrice3 = new MenuItem
                        {
                            Name = "Как посчитать количество символов (печатных знаков)",
                            StringKey = "DetailsPrice",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageDetailsPrice3.Id,
                            Parent = menuItemDetailsPrice
                            // ParentId = menuItemDetailsPrice.Id
                        };
                        var menuItemDetailsPrice4 = new MenuItem
                        {
                            Name = "Коэффициенты расширения языковых пар",
                            StringKey = "DetailsPrice",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageDetailsPrice4.Id,
                            Parent = menuItemDetailsPrice
                            //ParentId = menuItemDetailsPrice.Id

                        };
                        var menuItemDetailsPrice5 = new MenuItem
                        {
                            Name = "Как рассчитать стоимость перевода самостоятельно",
                            StringKey = "DetailsPrice",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageDetailsPrice5.Id,
                            Parent = menuItemDetailsPrice
                            //ParentId = menuItemDetailsPrice.Id
                        };

                        var menuItemSecurity = new MenuItem
                        {
                            Name = "Безопасность и защита переводов",
                            StringKey = "Security ",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageSecurity.Id,
                            Parent= menuItemForClient
                            // ParentId = menuItemForClient.Id

                        };
                        var menuItemSecurity1 = new MenuItem
                        {
                            Name = "Конфиденциальность информации",
                            StringKey = "Security ",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageSecurity1.Id,
                            Parent= menuItemSecurity
                            // ParentId = menuItemSecurity.Id

                        };
                        var menuItemSecurity2 = new MenuItem
                        {
                            Name = "Для чего необходим SSL-сертификат",
                            StringKey = "Security ",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageSecurity2.Id,
                            Parent = menuItemSecurity
                            //ParentId = menuItemSecurity.Id

                        };
                        var menuItemSecurity3 = new MenuItem
                        {
                            Name = "Защита электронной почты",
                            StringKey = "Security ",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageSecurity3.Id,
                            Parent = menuItemSecurity
                            // ParentId = menuItemSecurity.Id

                        };

                        var menuItemDecorations = new MenuItem
                        {
                            Name = "Правила оформления переводов",
                            StringKey = "Decorations ",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageDecorations.Id,
                            Parent = menuItemForClient
                            // ParentId = menuItemForClient.Id

                        };
                        var menuItemDecorations1 = new MenuItem
                        {
                            Name = "Как подготовить документы для перевода",
                            StringKey = "Decorations ",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageDecorations1.Id,
                            Parent = menuItemDecorations
                            // ParentId = menuItemDecorations.Id

                        };
                        var menuItemDecorations2 = new MenuItem
                        {
                            Name = "Заверение печатью бюро переводов",
                            StringKey = "Decorations ",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageDecorations2.Id,
                            Parent = menuItemDecorations
                            //ParentId = menuItemDecorations.Id

                        };
                        var menuItemDecorations3 = new MenuItem
                        {
                            Name = "Нотариальное заверение перевода",
                            StringKey = "Decorations ",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageDecorations3.Id,
                            Parent = menuItemDecorations
                            // ParentId = menuItemDecorations.Id

                        };

                        var menuItemHalper = new MenuItem
                        {
                            Name = "В помощь заказчику",
                            StringKey = "Halper",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageHalper.Id,
                            Parent= menuItemForClient
                            // ParentId = menuItemForClient.Id

                        };
                        var menuItemHalper1 = new MenuItem
                        {
                            Name = "Особенности дословного перевода",
                            StringKey = "Halper",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageHalper1.Id,
                            Parent= menuItemHalper
                            //ParentId = menuItemHalper.Id
                        };
                        var menuItemHalper2 = new MenuItem
                        {
                            Name = "Срочный перевод и его тонкости",
                            StringKey = "Halper",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageHalper2.Id,
                            Parent = menuItemHalper
                            // ParentId = menuItemHalper.Id

                        };
                        var menuItemHalper3 = new MenuItem
                        {
                            Name = "Разница машинного и профессионального перевода",
                            StringKey = "Halper",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageHalper3.Id,
                            Parent = menuItemHalper
                            // ParentId = menuItemHalper.Id
                        };
                        var menuItemHalper4 = new MenuItem
                        {
                            Name = "Словарь терминов",
                            StringKey = "Halper",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageHalper4.Id,
                            Parent = menuItemHalper
                            //  ParentId = menuItemHalper.Id

                        };

                        #endregion
                        #region Questions

                        var menuItemQuestions = new MenuItem
                        {
                            Name = "ВОПРОС-ОТВЕТ",
                            StringKey = "Services",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageQuestions.Id

                        };
                        #endregion
                        #region Contacts

                        var menuItemContacts = new MenuItem
                        {
                            Name = "КОНТАКТЫ",
                            StringKey = "Contacts",
                            MenuId = topMenu.Id,
                            IconClass = "",
                            Type = MenuItemType.Page,
                            PageId = pageContacts.Id

                        };
                        #endregion

                        #region Add

                        context.MenuItems.Add(menuItemContacts);
                        context.MenuItems.Add(menuItemQuestions);
                        context.MenuItems.Add(menuItemHalper); context.MenuItems.Add(menuItemHalper1); context.MenuItems.Add(menuItemHalper2); context.MenuItems.Add(menuItemHalper3); context.MenuItems.Add(menuItemHalper4);
                        context.MenuItems.Add(menuItemSecurity); context.MenuItems.Add(menuItemSecurity1); context.MenuItems.Add(menuItemSecurity2); context.MenuItems.Add(menuItemSecurity3);
                        context.MenuItems.Add(menuItemForClient);
                        context.MenuItems.Add(menuItemDetailsPrice); context.MenuItems.Add(menuItemDetailsPrice1); context.MenuItems.Add(menuItemDetailsPrice2); context.MenuItems.Add(menuItemDetailsPrice3); context.MenuItems.Add(menuItemDetailsPrice4); context.MenuItems.Add(menuItemDetailsPrice5);
                        context.MenuItems.Add(menuItemDecorations); context.MenuItems.Add(menuItemDecorations1); context.MenuItems.Add(menuItemDecorations2); context.MenuItems.Add(menuItemDecorations3);
                        context.MenuItems.Add(topMenuItem1);
                        context.MenuItems.Add(topMenuItem11);
                        context.MenuItems.Add(topMenuItem12);
                        context.MenuItems.Add(topMenuItem13);
                        context.MenuItems.Add(menuItemServices);
                        context.MenuItems.Add(menuItemDocuments);
                        context.MenuItems.Add(menuItemMedical);
                        context.MenuItems.Add(menuItemJudicial);
                        context.MenuItems.Add(menuItemTehnical);
                        context.MenuItems.Add(menuItemPharmaceutical);
                        context.MenuItems.Add(menuItemMarketing);
                        context.MenuItems.Add(menuItemFinancial);
                        context.MenuItems.Add(menuItemLiterary);
                        context.MenuItems.Add(menuItemPrice);
                        context.MenuItems.Add(menuItemDeliveryendPayment);
                        context.MenuItems.Add(menuItemDelivery);
                        context.MenuItems.Add(menuItemPayment);
                        context.MenuItems.Add(menuItemVacancy);
                        context.SaveChanges();

                        #endregion
                        #endregion
                    }


                   context.SaveChanges();
                }
            }
        }
    }
}