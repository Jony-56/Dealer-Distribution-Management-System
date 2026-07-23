using DDMS.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Domian.Entities
{
    public class StockAdjustment :AuditableEntity
    {
        private StockAdjustment()
        {
        }

        private StockAdjustment(
            Guid productId,
            int cartonAdjustment,
            int pieceAdjustment,
            string reason)
        {
            ProductId = productId;
            CartonAdjustment = cartonAdjustment;
            PieceAdjustment = pieceAdjustment;
            Reason = reason;
            AdjustmentDate = DateTime.UtcNow;
        }

        public Guid ProductId { get; private set; }

        public int CartonAdjustment { get; private set; }

        public int PieceAdjustment { get; private set; }

        public string Reason { get; private set; } = string.Empty;

        public DateTime AdjustmentDate { get; private set; }

        public Product Product { get; private set; } = null!;

        public static StockAdjustment Create(
            Guid productId,
            int cartonAdjustment,
            int pieceAdjustment,
            string reason)
        {
            if (productId == Guid.Empty)
                throw new ArgumentException("Product is required.");

            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("Reason is required.");

            return new StockAdjustment(
                productId,
                cartonAdjustment,
                pieceAdjustment,
                reason.Trim());
        }
    }
}
