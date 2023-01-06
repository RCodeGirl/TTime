using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DomainModel.Navigation;
using Interfaces.Navigation;
using Microsoft.EntityFrameworkCore;

namespace Services.Navigation
{
    public class MenuService : IMenuService
    {
        private readonly ApplicationDbContext _dbContext;

        public MenuService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Menu GetByKey(string stringKey)
        {
            Menu result = _dbContext.Menus.FirstOrDefault(_ => _.StringKey.Equals(stringKey));
            return result;
        }

        public Menu GetById(int id)
        {
            Menu result = _dbContext.Menus.FirstOrDefault(_ => _.Id == id);
            return result;
        }
        public Menu Create(Menu entity)
        {
            _dbContext.Menus.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            Menu entity = _dbContext.Menus.FirstOrDefault(_ => _.Id == id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Menus.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public Menu Edite( Menu model)
        {
            _dbContext.Menus.Update(model);
            _dbContext.SaveChanges();
            return model;
        }

        
        public List<Menu> GetAll()
        {
            return (from menu in _dbContext.Menus
                   
                    select new Menu
                    {
                        Id = menu.Id,
                        Name = menu.Name,
                        Items = (from menuItem in _dbContext.MenuItems.Where(_ => _.MenuId == menu.Id)
                                 
                                 select new MenuItem
                                 {
                                     Id = menuItem.Id,
                                     Name = menuItem.Name,
                                     Action = menuItem.Action,
                                     Controller = menuItem.Controller,
                                     CustomUrl = menuItem.CustomUrl,
                                     IsHidden = menuItem.IsHidden,
                                     StringKey = menuItem.Page.StringKey,
                                     ParentId = menuItem.ParentId,
                                     MenuId = menuItem.MenuId,
                                     PageId = menuItem.PageId
                                     

                                 }).ToList()
                    }).ToList();
        }

        public IList<TResult> GetAll<TResult>(Expression<Func<Menu, TResult>> selector)
        {
            IQueryable<TResult> result =
                _dbContext.Menus.Include(_ => _.Items.Select(i => i.Page))
                        .Include(_ => _.Items.Select(i => i.Childs))
                        .Select(selector);
            return result.ToList();
        }

        
    }
}