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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public int TProductCountbyCategoryNameDrink()
        {
            return _productDal.ProductCountbyCategoryNameDrink();
        }

        public int TProductCountbyCategoryNameHamburger()
        {
            return _productDal.ProductCountbyCategoryNameHamburger();
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> TGetAll()
        {
            return _productDal.GetAll();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetProductWithCategories()
        {
            return _productDal.GetProductWithCategories();
        }

        public int TProductCount()
        {
            return _productDal.ProductCount();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

        public decimal TProductPriceAvg()
        {
            return _productDal.ProductPriceAvg();
        }

        public string TProductNamebyMaxPrice()
        {
            return _productDal.ProductNamebyMaxPrice();
        }

        public string TProductNamebyMinPrice()
        {
            return _productDal.ProductNamebyMinPrice();
        }

        public decimal TProductPriceAvgHamburger()
        {
            return _productDal.ProductPriceAvgHamburger();
        }
    }
}
