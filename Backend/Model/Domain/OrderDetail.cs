using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdityaSERA.Backend.Model.Domain
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [Column("TransactionDetail_ID")]
        public string TransactionDetail_ID { get; set; }

        [ForeignKey("Order")]
        public string TransactionID { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public double TotalPrice { get; set; }

        public Product Product { get; set; }
        public Category Categories { get; set; }

    }
}
