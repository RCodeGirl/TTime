using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Content;
using Interfaces.Content;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.IO;



namespace Services.Content
{
    public class SliderService : ISliderService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SliderService(ApplicationDbContext dbContext, IWebHostEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
        }
        public Slider GetById(int? id)
        {
            Slider result = _dbContext.Sliders.FirstOrDefault(_ => _.Id == id);
            return result;
        }

        public IList<Slider> GetAll(bool onlyActive = false)
        {
            IQueryable<Slider> result = _dbContext.Sliders.AsQueryable();
            if (onlyActive)
            {
                result = result.Where(_ => !_.IsHidden);
            }
            return result.ToList();
        }

        public Slider Update(Slider entity)
        {
            _dbContext.Sliders.Update(entity);
            _dbContext.SaveChanges();
            return entity;

        }

        public Slider Add(Slider entity)
        {
                       
            _dbContext.Sliders.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            Slider entity = _dbContext.Sliders.FirstOrDefault(_ => _.Id == id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Sliders.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }
    }
}