using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductInfoController : ControllerBase
    {
        private static readonly ProductInfo[] TheMenu = new[]
        {
            new ProductInfo { Name = "Poblano Pepper", Description = "green pepper, spiciness between bell and jalapeno", EligibleQuantity = "1 each", InventoryLevel = 0, Price = 40},
            new ProductInfo { Name = "Jasmine Rice", Description = "white rice", EligibleQuantity = "1 lb", InventoryLevel = 3, Price = 2},
            new ProductInfo { Name = "Tomato", Description = "yum", EligibleQuantity = "1 lb", InventoryLevel = 0, Price = 3},
            new ProductInfo { Name = "Black Beans", Description = "black beans", EligibleQuantity = "1 each", InventoryLevel = 12, Price = 1},
            new ProductInfo { Name = "Pepperjack Cheese", Description = "spicy cheese", EligibleQuantity = "1 lb", InventoryLevel = 0, Price = 10},
            new ProductInfo { Name = "Salsa Verde", Description = "green salsa", EligibleQuantity = "1 each", InventoryLevel = 0, Price = 4}
        };

        private readonly ILogger<ProductInfoController> _logger;

        public ProductInfoController(ILogger<ProductInfoController> logger)
        {
            _logger = logger;
        }

         [HttpGet]
         public IEnumerable<ProductInfo> Get()
         {
             return TheMenu;
         }
    }
}
