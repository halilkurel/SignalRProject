using SignalR.BussinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BussinessLayer.Concreate
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public int ActiveCategoryCount()
        {
            return _categorydal.ActiveCategoryCount();
        }

        public int PasiveCategoryCount()
        {
            return _categorydal.PasiveCategoryCount();
        }

        public void TAdd(Category entity)
        {
            _categorydal.Add(entity);
        }

        public int TCategoryCount()
        {
            return _categorydal.CategoryCount();
        }

        public void TDelete(Category entity)
        {
           _categorydal.Delete(entity);
        }

        public List<Category> TGetAll()
        {
            return _categorydal.GetAll();
        }

        public Category TGetById(int id)
        {
            return _categorydal.GetById(id);
        }

        public void TUpdate(Category entity)
        {
            _categorydal.Update(entity);
        }
    }
}
