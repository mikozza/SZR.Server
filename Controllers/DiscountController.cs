using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Dialogflow.V2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SZR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscountController : ControllerBase
    {

        private readonly ILogger<DiscountController> _logger;
        private readonly DiscountDbContext _context;

        public DiscountController(ILogger<DiscountController> logger, DiscountDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet("GetAllDiscounts")]
        public IEnumerable<Discount> GetAllDiscounts()
        {

            DiscountManager dscManager = new DiscountManager(_context);
            return dscManager.GetAllDiscounts();

        }

        [HttpPost("GetMyDiscount")]
        public string GetMyDiscount()
        {

            DiscountManager dscManager = new DiscountManager(_context);
            return dscManager.GetMyDiscount();
        }

        [HttpPost("AddDiscount")]
        public Discount AddDiscount(Discount discount)
        {

            DiscountManager dscManager = new DiscountManager(_context);
            return dscManager.AddDiscount(discount);
        }

    }
}
