using AdityaSERA.Backend.Model.Domain;
using AdityaSERA.Backend.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AdityaSERA.Backend.Repositories.Ord
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AdityaSERADbContext _dbContext;

        public OrderRepository(AdityaSERADbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order> getOrderInfo(string transactionID)
        {
            var orderInfo = await _dbContext.Orders
                .FirstOrDefaultAsync(o => o.TransactionID == transactionID);

            return orderInfo;
        }
    }
}
