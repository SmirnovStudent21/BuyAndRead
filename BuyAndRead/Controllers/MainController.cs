using System;
using System.Linq;
using BuyAndRead.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuyAndRead.Controllers
{
    [Route("api/main")]
    [ApiController]
    public class MainController : Controller
    { 

        private readonly BuyAndReadDbContext _dbContext;
        public MainController(BuyAndReadDbContext dbContext)
        {
            this._dbContext = dbContext;
            if (!_dbContext.Books.Any())
            {
                _dbContext.Books.Add(new Book{Id = 1, Title = "a", Author = "A. C. Cobra", ///вот здесь нужно разобраться с добавлением изображения
                    Year = 1958, Isbn = "9780529072245", Price  = 1350, Quantity = 2});
            }
        }

        [HttpGet]
        
        public IActionResult GetAvailableBooks()
        {
            return Ok();
        }
        
        
    }
}