using AutoMapper;
using DomainModel.Content;
using Interfaces.Content;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models.Content;

namespace WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BlockListController : Controller
    {
        private readonly IBlockListService _blockList;
        private readonly IMapper _mapper;
        

        public BlockListController(IBlockListService blockList, IMapper mapper)
        {
            _blockList = blockList;
            _mapper = mapper;
           
        }
        public IActionResult BlocksList()
        {
            var blocklist = _blockList.GetAll();
            var blockslists = _mapper.Map<List<BlockListViewModel>>(blocklist);
            return View(blockslists);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View (new BlockListViewModel());

        }
        [HttpPost]
        public IActionResult Add (BlockListViewModel model)
        {
            var blocklist = new BlockList
            {
                Name = model.Name,
                Blocks = model.Blocks,
                StringKey= model.StringKey,
                Pozition = _blockList.GetPosition()+1
            };
            _blockList.Add(blocklist);
            return RedirectToAction("BlocksList");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bloclist = _blockList.GetById(id);
            return View(_mapper.Map<BlockListViewModel>(bloclist));
        }
        [HttpPost]
        public IActionResult Edit (BlockListViewModel model)
        {
            var blocklist = new BlockList
            {
                Id= model.Id,
                Name = model.Name,
                Blocks = model.Blocks,
                StringKey = model.StringKey,
                Pozition = model.Pozition
            };
            _blockList.Edite(blocklist);
            return RedirectToAction("BlocksList");
        }

        public IActionResult Delete (int Id)
        {
            _blockList.Delete(Id);
            return RedirectToAction("BlocksList");
        }
    }
}
