using DDMS.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Domian.Entities
{
    public class ProductPriceHistory : AuditableEntity
    {
        private ProductPriceHistory() { }

        private ProductPriceHistory(Guid productId , decimal oldPrice, decimal newPrice, DateTime effectiveDate)
        {
            ProductId = productId;
            OldPrice = oldPrice;
            NewPrice = newPrice;
            EffectiveDate = effectiveDate;
          
        }

        public Guid ProductId { get; private set; }
        public decimal OldPrice { get; private set; }
        public decimal NewPrice { get; private set; }

        public DateTime EffectiveDate { get; private set; }

        //Navigation
        public Product Product { get; private set; } = null!;

        public static ProductPriceHistory Create
            (
               Guid productId, decimal oldPrice, decimal newPrice, DateTime effectiveDate

            )
        {
            if (productId == Guid.Empty)
            {
                throw new ArgumentNullException("Product must be required");
            }
            if (newPrice <= 0)
            {
                throw new ArgumentException("New Price Must be Greater than 0");
            }

            return new ProductPriceHistory
            (
                productId,
                oldPrice,
                newPrice,
                effectiveDate

                );
        }

      


    }
}
