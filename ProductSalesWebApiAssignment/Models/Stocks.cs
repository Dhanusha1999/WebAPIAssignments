namespace ProductSalesWebApiAssignment.Models
{
    public class Stocks
    {
        public Stores store { get; set; }
        public Products product { get; set; }
        public int Quantity {  get; set; }
    }
}
