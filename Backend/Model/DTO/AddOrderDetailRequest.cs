namespace AdityaSERA.Backend.Model.DTO
{
    public class AddOrderDetailRequest
    {
        public string TransactionDetail_ID { get; set; }
        public string TransactionID { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public double TotalPrice { get; set; }
    }
}
