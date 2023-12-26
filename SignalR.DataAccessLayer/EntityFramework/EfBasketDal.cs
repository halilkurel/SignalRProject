﻿using Microsoft.EntityFrameworkCore;
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
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context): base(context)
        {
            
        }
        public List<Basket> GetBasketByTableNumber(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Where(x => x.MenuTableId == id).Include(y =>y.Product).ToList();
            return values;
        }
    }
}
