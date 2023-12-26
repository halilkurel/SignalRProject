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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactdal;

        public ContactManager(IContactDal contactdal)
        {
            _contactdal = contactdal;
        }

        public void TAdd(Contact entity)
        {
            _contactdal.Add(entity);
        }

        public void TDelete(Contact entity)
        {
            _contactdal.Delete(entity);
        }

        public List<Contact> TGetAll()
        {
            return _contactdal.GetAll();
        }

        public Contact TGetById(int id)
        {
            return _contactdal.GetById(id);
        }

        public void TUpdate(Contact entity)
        {
            _contactdal.Update(entity);
        }
    }
}
