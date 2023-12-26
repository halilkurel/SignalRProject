using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface INatificationDal : IGenericDal<Natification>
    {
        int NotificationCountByStatusFalse();
        List<Natification> GetAllNatificationByFalse();
        void NatificationChangeStatusToTrue(int id);
        void NatificationChangeStatusToFalse(int id);
    }
}
