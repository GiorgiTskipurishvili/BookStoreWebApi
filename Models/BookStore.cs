namespace BookStoreWebApi.Models
{
    public class BookStore
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author {  get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }
    }
}
