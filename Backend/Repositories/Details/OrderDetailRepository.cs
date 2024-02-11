using AdityaSERA.Backend.Model.Domain;
using AdityaSERA.Backend.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdityaSERA.Backend.Repositories.Details
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly AdityaSERADbContext _dbContext;

        public OrderDetailRepository(AdityaSERADbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<OrderDetail> addOrderDetail(OrderDetail orderDetails)
        {
            await _dbContext.OrderDetails.AddAsync(orderDetails);
            await _dbContext.SaveChangesAsync();
            return orderDetails;
        }

        public async Task<IEnumerable<OrderDetail>> getOrderDetails(string transactionID)
        {
            var orderDetailInfo = await _dbContext.OrderDetails
                .Where(ors => ors.TransactionID == transactionID)
                .ToListAsync();

            return orderDetailInfo;
        }
    }
}
