namespace BookStoreWebApi.Models
{
    public class OrderWithBookDetails
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int OrderQuantity { get; set; }
        public BookDetails Book { get; set; }
    }


    public class BookDetails
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
    }
}
