using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;
using Interfaces.Content;
using Services;
using DomainModel.Content;
using WebSite.Models.Content;
using DomainModel.Framework.Email;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebSite.Controllers
{
    public class CallBackController : Controller
    {
        private readonly ICallbackService _callbackService;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public IActionResult CallbackClient()
        {
            return View();
        }
        public CallBackController(ICallbackService callbackService, ApplicationDbContext dbContext, IEmailSender emailSender, IWebHostEnvironment hostingEnvironment)
        {
            _callbackService = callbackService;
            _emailSender = emailSender;
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(CallBackViewModelcs model)
        {
                var calBack = new Callback
                {
                    Name = model.Name,
                    Phone = model.Phone,
                    Email = model.Email,
                    LanguageOrig = model.LanguageOrig,
                    LanguageTarget = model.LanguageTarget,
                    Comment = model.Comment
                };

                _callbackService.Add(calBack);
                 _emailSender.SendEmailAsync(calBack, model.Document);
            

            return RedirectToAction("CallbackClient");
        }

        
    }
}
