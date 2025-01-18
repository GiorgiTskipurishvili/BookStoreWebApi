namespace BookStoreWebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsConfirmed { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
