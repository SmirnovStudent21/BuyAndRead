using System.Collections.Generic;

namespace BuyAndRead.Models
{
    public class Order
    {
        /// <summary>
        /// PK
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ISBN-number of book
        /// </summary>
        public string Isbn { get; set; }
        public double TotalPrice { get; set; } 
        
        /// <summary>
        /// key from BookDb
        /// </summary>
        public int BookId { get; set; } 
        /// <summary>
        /// key from UserDb
        /// </summary>
        public int UserId { get; set; } 
        public User User { get; set; }

        public ICollection<Book> Books { get; set; }
        public List<BookOrder> BookOrders { get; set; } 
    }
}