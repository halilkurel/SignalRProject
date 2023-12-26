using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concreate;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context): base(context)
        {
            
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(x => x.Description =="Aktif").Count();
        }

        public decimal LastOrderPriceCount()
        {
            using var ctx = new SignalRContext();
            return (decimal)ctx.Orders.OrderByDescending(x => x.OrderId).Take(1).Select(y =>y.TotalPrice).FirstOrDefault();
        }

        public decimal TodayTotaalPrice()
        {
            using var context = new SignalRContext();

            // DateTime.Now.ToShortDateString() ile gün başlangıcını alır.
            DateTime todayStart = DateTime.Parse(DateTime.Now.ToShortDateString());

            // DateTime.Now.AddDays(1).AddTicks(-1) ile gün bitişini alır.
            DateTime todayEnd = DateTime.Now.AddDays(1).AddTicks(-1);

            // LINQ sorgusunda Where ve null kontrolü ekleyerek hatayı düzelt
            return context.Orders
                          .Where(x => x.Date >= todayStart && x.Date <= todayEnd)
                          .Select(y => y.TotalPrice ?? 0m) // null kontrolü eklenmiş
                          .Sum();
        }



        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();
        }
    }
}
