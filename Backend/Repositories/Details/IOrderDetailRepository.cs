using AdityaSERA.Backend.Model.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdityaSERA.Backend.Repositories.Details
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> addOrderDetail(OrderDetail orderDetails);
        Task<IEnumerable<OrderDetail>> getOrderDetails(string transactionID);
    }
}
