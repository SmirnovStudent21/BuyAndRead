using BuyAndRead.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyAndRead.Controllers
{
    public class OrderController
    {
        private readonly BuyAndReadDbContext _dbContext;
        public OrderController(BuyAndReadDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        
        
    }
}