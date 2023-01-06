using AutoMapper;
using DomainModel.Content;
using Interfaces.Content;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models.Content;

namespace WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BlockController : Controller
    {
        private readonly IBlockService _blockService;
        private readonly IMapper _mapper;
        private readonly IBlockListService _blockListService;
        private readonly IWebHostEnvironment _hostEnvironment;


        public BlockController(IBlockService blockService, IMapper mapper, IWebHostEnvironment hostEnvironment, IBlockListService blockListService)
        {
            _blockService = blockService;
            _mapper = mapper;
            _blockListService = blockListService;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Blocks(bool  isActive = true)
        {
            var block = _blockService.GetAll(isActive);
            var blocks = _mapper.Map<List<BlockViewModel>>(block);
            return View(blocks);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var block = new BlockViewModel
            {
                BlockLists = _mapper.Map<List<BlockListViewModel>>(_blockListService.GetAll().ToList())
            };
            return View(block);
        }
        [HttpPost]
        public IActionResult Add(BlockViewModel model)
        {

            string filePath = $@"{_hostEnvironment.WebRootPath}\img\Blocks\{model.Icon.FileName}";
            using (FileStream fs = System.IO.File.Create(filePath))
            {
                model.Icon.CopyTo(fs);
                fs.Flush();
            }

            var block = new Block
            {
                 Title=model.Title,
                 Description= model.Description,
                 StringKey = model.StringKey,
                 IsHidden = model.IsHidden,
                 IsContent = model.IsContent,
                 BlockListId = model.BlockListId,
                 BlockList = model.BlockList,
                 Img = "/img/Blocks/" + model.Icon.FileName,
                 Pozition = _blockService.GetPosition() + 1
                 

            };

            _blockService.Add(block);
            return RedirectToAction("Blocks");
        }
        [HttpGet]
        public IActionResult Edit (int id)
        {
            var block = _mapper.Map<BlockViewModel>(_blockService.GetById(id));
            block.BlockLists= _mapper.Map<List<BlockListViewModel>>(_blockListService.GetAll().ToList());
            return View(block);
        }
        [HttpPost]
        public IActionResult Edit (BlockViewModel model)
        {
            var block = new Block
            {
                Id=model.Id,
                Title = model.Title,
                Description = model.Description,
                StringKey = model.StringKey,
                IsHidden = model.IsHidden,
                IsContent = model.IsContent,
                BlockListId = model.BlockListId,
                BlockList = model.BlockList,
                Img = "/img/Blocks/" + model.Icon.FileName,
                Pozition= model.Pozition

            };

            if (model.Icon != null)
            {
                string filePath = $@"{_hostEnvironment.WebRootPath}\img\Blocks\{model.Icon.FileName}";
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    model.Icon.CopyTo(fs);
                    fs.Flush();
                }
                block.Img = "/img/Blocks/" + model.Icon.FileName;
            }
            else block.Img = model.Img;

            _blockService.Update(block);
            return RedirectToAction("Blocks");

        }

        public IActionResult Delete (int id)
        {
            _blockService.Delete(id);
            return RedirectToAction("Blocks");
        }
    }
}
