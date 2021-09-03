using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuyAndRead.Models
{
    public class Book
    {   
        [Column("BookId")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        /// <summary>
        /// isbn number of book
        /// </summary>
        [MaxLength(13), MinLength(13)]
        public string Isbn { get; set; } 
        public Guid? Picture { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public ICollection<Order> Orders { get; set; }
        public List<BookOrder> BookOrders { get; set; }
    }
}