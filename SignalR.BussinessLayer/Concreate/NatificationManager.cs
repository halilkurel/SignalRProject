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
    public class NatificationManager : INatificationService
    {
        private readonly INatificationDal _natificationDal;

        public NatificationManager(INatificationDal natificationDal)
        {
            _natificationDal = natificationDal;
        }

        public int NotificationCountByStatusFalse()
        {
            return _natificationDal.NotificationCountByStatusFalse();
        }

        public void TAdd(Natification entity)
        {
            _natificationDal.Add(entity);
        }

        public void TDelete(Natification entity)
        {
            _natificationDal.Delete(entity);
        }

        public List<Natification> TGetAll()
        {
            return _natificationDal.GetAll();
        }

        public List<Natification> TGetAllNatificationByFalse()
        {
            return _natificationDal.GetAllNatificationByFalse();
        }

        public Natification TGetById(int id)
        {
            return _natificationDal.GetById(id);
        }

        public void TNatificationChangeStatusToFalse(int id)
        {
            _natificationDal.NatificationChangeStatusToFalse(id);
        }

        public void TNatificationChangeStatusToTrue(int id)
        {
            _natificationDal.NatificationChangeStatusToTrue(id);
        }

        public void TUpdate(Natification entity)
        {
            _natificationDal.Update(entity);
        }
    }
}
