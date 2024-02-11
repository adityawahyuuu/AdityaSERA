using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdityaSERA.Backend.Model.Domain
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public string TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionNumber { get; set; }
        public string CashierName { get; set; }
        public double TotalAmount { get; set; }
    }
}
