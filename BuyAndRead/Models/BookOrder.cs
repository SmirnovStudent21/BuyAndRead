using System;

namespace BuyAndRead.Models
{
    /// <summary>
    /// Таблица для косвенного объединения
    /// </summary>
    public class BookOrder
    {
        public DateTime OrderingDate { get; set; }
        
        public int BookId { get; set; }
        public Book Book { get; set; }
        
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}