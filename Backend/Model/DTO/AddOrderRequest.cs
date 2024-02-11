using System;

namespace AdityaSERA.Backend.Model.DTO
{
    public class AddOrderRequest
    {
        public string TransactionID { get; set; }
        public string TransactionNumber { get; set; }
        public string CashierName { get; set; }
    }
}
