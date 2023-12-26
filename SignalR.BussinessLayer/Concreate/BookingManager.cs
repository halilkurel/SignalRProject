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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingdal;

        public BookingManager(IBookingDal bookingdal)
        {
            _bookingdal = bookingdal;
        }

        public void TAdd(Booking entity)
        {
            _bookingdal.Add(entity);
        }

		public void TBookingStatusApproved(int id)
		{
            _bookingdal.BookingStatusApproved(id);
		}

		public void TBookingStatusCansled(int id)
		{
            _bookingdal.BookingStatusCansled(id);
		}

		public void TDelete(Booking entity)
        {
            _bookingdal.Delete(entity);
        }

        public List<Booking> TGetAll()
        {
            return _bookingdal.GetAll();
        }

        public Booking TGetById(int id)
        {
            return _bookingdal.GetById(id);
        }

        public void TUpdate(Booking entity)
        {
            _bookingdal.Update(entity);
        }
    }
}
