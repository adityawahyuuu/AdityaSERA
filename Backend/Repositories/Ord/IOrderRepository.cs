using AdityaSERA.Backend.Model.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdityaSERA.Backend.Repositories.Ord
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order order);
        Task<Order> getOrderInfo(string transactionID);
    }
}
