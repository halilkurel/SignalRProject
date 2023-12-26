using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        public List<Product> GetProductWithCategories();
        public int ProductCount();
        public int ProductCountbyCategoryNameDrink();
        public int ProductCountbyCategoryNameHamburger();
        public decimal ProductPriceAvg();
        public decimal ProductPriceAvgHamburger();
        public string ProductPricebyMax();
        public string ProductNamebyMaxPrice();
        public string ProductNamebyMinPrice();
    }
}

