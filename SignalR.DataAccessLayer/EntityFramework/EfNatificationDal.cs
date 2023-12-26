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
    public class EfNatificationDal : GenericRepository<Natification>, INatificationDal
    {
        public EfNatificationDal(SignalRContext context) : base(context)
        {

        }

        public List<Natification> GetAllNatificationByFalse()
        {
            using var contexy = new SignalRContext();
            return contexy.Natifications.Where(x => x.Status==false).ToList();
        }

        public void NatificationChangeStatusToFalse(int id)
        {
            using var context = new SignalRContext();
            var value = context.Natifications.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void NatificationChangeStatusToTrue(int id)
        {
            using var context = new SignalRContext();
            var value = context.Natifications.Find(id);
            value.Status = true;
            context.SaveChanges();
        }

        public int NotificationCountByStatusFalse()
        {
            using var context = new SignalRContext();
            return context.Natifications.Where(x => x.Status==false).Count();
        }
    }
}
