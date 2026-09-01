namespace Kutuphane.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public int BookStock { get; set; }
        public ICollection<Loan> Loans { get; set; }
        // bir kitabin zaman  içinde  birden fazla ödünc alma kaydı olabilir.


    }
}
