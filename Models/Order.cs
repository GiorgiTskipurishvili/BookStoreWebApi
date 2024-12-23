namespace BookStoreWebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int OrderQuantity { get; set; }

        public int BookId { get; set; }
    }
}
