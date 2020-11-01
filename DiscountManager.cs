using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using Google.Cloud.Dialogflow.V2;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;

namespace SZR
{
    public class DiscountManager
    {

        public DiscountManager(DiscountDbContext context)
        {
            _context = context;

        }

        private readonly DiscountDbContext _context;


        public IEnumerable<Discount> GetAllDiscounts()
        {

            return _context.getDiscounts();

        }
        public Discount AddDiscount(Discount discount)
        {


            _context.AddDiscount(discount);

            return discount;
        }

        public string GetMyDiscount()
        {

            Discount discount = null;

            var discounts = _context.getDiscounts();
            // discount = discounts.FirstOrDefault();

            // Get those which are still valid
            //discounts = discounts.Where(d => d.ValidTill > DateTime.Now.AddDays(-1)).ToList();

            double latitude = 50.0730903;
            double longitude = 14.4691482;

            // Select location radius
            var coord = new GeoCoordinate(latitude, longitude);
            var nearest = discounts.OrderBy(x => x.GetDistance(coord)).Where(x => x.GetDistance(coord) < 8000);

            // Calculate prioritzation score

            // Select by prioritization score
            discount = nearest.OrderBy(d => d.Propagations).FirstOrDefault();

            // Increment propagation
            _context.IncrementPropagation(discount);


            // Send resposne voie asssitant response
            WebhookResponse webHookResponse = null;
            webHookResponse = DialogFlowManager.GetDialogFlowResponse(null, $"Your discount for today is: " + discount.DiscountName + " for " + (int)discount.Price + " czech crowns, in " + discount.BusinessName);

            return webHookResponse.ToString() ;
        }




    }
}
