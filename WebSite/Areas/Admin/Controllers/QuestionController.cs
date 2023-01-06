using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DomainModel.Content;
using Interfaces.Content;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSite.Models.Content;

namespace WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private IMapper _mapper;

        public QuestionController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;

        }
        public IActionResult Questions()
        {
            var model = _questionService.GetAll();
            var models = _mapper.Map<List<QuestionViewModel>>(model);
            return View(models);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View (new QuestionViewModel());
        }

        [HttpPost]
        public IActionResult Add(QuestionViewModel model)
        {
            var question = new Question
            {
                question = model.question,
                Answer = model.Answer,
                StringKey = model.StringKey
            };
            _questionService.Add(question);
            return RedirectToAction("Questions");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
           var model= _questionService.GetById(id);
           var models = _mapper.Map<QuestionViewModel>(model);
           return View(model);
        }

        [HttpPost]
        public IActionResult Update(QuestionViewModel model)
        {
            var question = new Question
            { 
                question = model.question,
                Answer = model.Answer,
                StringKey = model.StringKey

            };
            return RedirectToAction("Questions");
        }

        public IActionResult Delete(int id)
        {
            _questionService.Delete(id);
            return RedirectToAction("Questions");
        }
    }
}
