using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SZR
{
    public class DiscountDbContext : DbContext
    {
        public DbSet<Discount> Discounts { get; set; }

        public DiscountDbContext(DbContextOptions<DiscountDbContext> options) : base(options)
        {

        }

        public void AddDiscount(Discount discount)
        {
            Discounts.Add(discount);
            this.SaveChanges();
            return;
        }


        public void IncrementPropagation(Discount discount)
        {

            var entity = Discounts.FirstOrDefault(item => item.Id == discount.Id);

            // Validate entity is not null
            if (entity != null)
            {
                if (entity.Propagations == null)
                {
                    entity.Propagations = 1;
                }
                else
                {
                    entity.Propagations = entity.Propagations + 1;
                }

              
                this.SaveChanges();
            }

            return;
        }

        public List<Discount> getDiscounts() => Discounts.ToList<Discount>();

    }
}



