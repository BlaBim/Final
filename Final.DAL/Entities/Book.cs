namespace Final.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Loan> Loans { get; set; }
        public ICollection<BookRating> Ratings { get; set; }
    }
}
