using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BussinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        public List<Product> TGetProductWithCategories();
        int TProductCount();
        public int TProductCountbyCategoryNameDrink();
        public int TProductCountbyCategoryNameHamburger();
        public decimal TProductPriceAvg();
        public string TProductNamebyMaxPrice();
        public string TProductNamebyMinPrice();
        public decimal TProductPriceAvgHamburger();


    }
}
