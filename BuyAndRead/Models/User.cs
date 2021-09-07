using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BuyAndRead.Models
{
    public class User
    {
        [Column("UserId")]
        [Required]
        public int Id { get; set; }
        public Guid Promocode { get; set; }
        public List<Order> Orders { get; set; }
    }
}