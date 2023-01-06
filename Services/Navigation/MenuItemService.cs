using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Content;
using DomainModel.Navigation;
using Interfaces.Navigation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Services.Navigation
{
    public class MenuItemService : IMenuItemService
    {
        private readonly ApplicationDbContext _dbContext;
       
        
        public MenuItemService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  IList<MenuItem> GetByParentId(int ParentId)
        {
            var result = _dbContext.MenuItems.Include(_ => _.Parent)
                .Include(_ => _.Childs)
                //.Include(_ => _.Childs.Select(child => child.Page))
                .Include(_ => _.Page)
                .Where(_ => _.ParentId.Equals(ParentId));
            return result.ToList();

        }
        public IList<MenuItem> GetByMenuKey(string stringKey, bool onlyActive = true)
        {

            var result = _dbContext.MenuItems.Include(_ => _.Parent)
                .Include(_ => _.Childs)
                //.Include(_ => _.Childs.Select(child => child.Page))
                .Include(_ => _.Page)
                .Where(_ => _.Menu.StringKey.Equals(stringKey))
                .OrderBy(_=>_.Position);
            if (onlyActive)
            {
                result = (IOrderedQueryable<MenuItem>)result.Where(_ => !_.IsHidden);
            }
            return result.ToList();

        }
        public int GetPosition()
        {
            return _dbContext.MenuItems.Max(_ => _.Position);
        }

        public IList<MenuItem> GetAll(bool onlyActive = false)
        {
            var result = _dbContext.MenuItems.Where(_ => !onlyActive || !_.IsHidden).AsQueryable();
          
            return result.ToList();
        }

        public IList<MenuItem> GetByKey(string Key)
        {
            return (from menuItem in _dbContext.MenuItems.Where(_ => _.StringKey == Key)
                                   
                    select new MenuItem
                    {
                        Id = menuItem.Id,
                        Name = menuItem.Name,
                        Action = menuItem.Action,
                        Controller = menuItem.Controller,
                        CustomUrl = menuItem.CustomUrl,
                        IsHidden = menuItem.IsHidden,
                        StringKey = menuItem.Page.StringKey,
                        MenuId = menuItem.MenuId,
                        PageId = menuItem.PageId

                    }).ToList();
        }
        public MenuItem GetById(int Id)
        {
            //return (from menuItem in _dbContext.MenuItems.Where(_ => _.Id == Id)
            //      select new MenuItem
            //        {
            //            Id = menuItem.Id,
            //            Name = menuItem.Name,
            //            Action = menuItem.Action,
            //            Controller = menuItem.Controller,
            //            CustomUrl = menuItem.CustomUrl,
            //            IsHidden = menuItem.IsHidden,
            //            StringKey = menuItem.Page.StringKey,
            //            MenuId = menuItem.MenuId,
            //            PageId = menuItem.PageId,
            //            Position = menuItem.Position,
            //            IconClass = menuItem.IconClass,
            //            ParentId=menuItem.ParentId,
            //            Parent = menuItem.Parent,

            //            Page = (from page in _dbContext.Pages.Where(_ => _.Id == menuItem.PageId)                                
            //                    select new Page
            //                    {
            //                        Id = page.Id,
            //                        Name = page.Name,
            //                        Content = page.Content,
            //                        MetaDescription = page.MetaDescription,
            //                        MetaKeywords = page.MetaKeywords,
            //                        MetaTitle = page.MetaTitle


            //                    }).FirstOrDefault()
            //        }).FirstOrDefault();
            var menu = _dbContext.MenuItems.FirstOrDefault(_ => _.Id == Id);
            return menu;
        }
       
        public IList<MenuItem> GetByParentId(int? Id)
        {
            var menuParent = _dbContext.MenuItems.Where(_ => _.ParentId == Id).ToList();
            return menuParent;
        }

        public MenuItem Update(MenuItem model)
        {

            _dbContext.MenuItems.Update(model);
            _dbContext.SaveChanges();
            return model;

        }

        public MenuItem Add(MenuItem entity)
        {
            _dbContext.MenuItems.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _dbContext.MenuItems.FirstOrDefault(_ => _.Id == id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.MenuItems.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }
    }
}