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
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderdal;

        public OrderManager(IOrderDal orderdal)
        {
            _orderdal = orderdal;
        }

        public int TActiveOrderCount()
        {
            return _orderdal.ActiveOrderCount();
        }

        public void TAdd(Order entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Order entity)
        {
            throw new NotImplementedException();
        }

        public List<Order> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Order TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public decimal TLastOrderPriceCount()
        {
            return _orderdal.LastOrderPriceCount();
        }

        public int TTotalOrderCount()
        {
            return _orderdal.TotalOrderCount();
        }

        public decimal TTotalTodayPrice()
        {
            return _orderdal.TodayTotaalPrice();
        }

        public void TUpdate(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
