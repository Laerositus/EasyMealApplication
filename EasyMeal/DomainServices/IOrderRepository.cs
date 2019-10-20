using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EasyMealCore.DomainModel;

namespace EasyMealCore.DomainServices
{
    public interface IOrderRepository 
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
