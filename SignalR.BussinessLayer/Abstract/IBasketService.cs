using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BussinessLayer.Abstract
{
    public interface IBasketService : IGenericService<Basket>
    {
        public List<Basket> GetBasketByTableNumber(int id);
    }
}
