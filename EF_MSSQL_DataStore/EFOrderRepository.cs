using System.Collections.Generic;
using System.Linq;

using EasyMealCore.DomainModel;
using EasyMealCore.DomainServices;

namespace EF_MSSQL_DataStore
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;

        public EFOrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Order> Orders => context.Orders;

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Meal));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
