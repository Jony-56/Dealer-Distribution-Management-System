using DDMS.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Domian.Entities
{
    public class StockEntryItem:AuditableEntity
    {
        private StockEntryItem()
        {
        }

        private StockEntryItem(
            Guid stockEntryId,
            Guid productId,
            int cartonQty,
            int pieceQty,
            decimal unitPrice)
        {
            StockEntryId = stockEntryId;
            ProductId = productId;
            CartonQty = cartonQty;
            PieceQty = pieceQty;
            UnitPrice = unitPrice;
        }

        public Guid StockEntryId { get; private set; }

        public Guid ProductId { get; private set; }

        public int CartonQty { get; private set; }

        public int PieceQty { get; private set; }

        public decimal UnitPrice { get; private set; }

        public StockEntry StockEntry { get; private set; } = null!;

        public Product Product { get; private set; } = null!;

        public static StockEntryItem Create(
            Guid stockEntryId,
            Guid productId,
            int cartonQty,
            int pieceQty,
            decimal unitPrice)
        {
            if (stockEntryId == Guid.Empty)
                throw new ArgumentException("Stock Entry is required.");

            if (productId == Guid.Empty)
                throw new ArgumentException("Product is required.");

            if (cartonQty < 0 || pieceQty < 0)
                throw new ArgumentException("Quantity cannot be negative.");

            if (unitPrice < 0)
                throw new ArgumentException("Unit price cannot be negative.");

            return new StockEntryItem(
                stockEntryId,
                productId,
                cartonQty,
                pieceQty,
                unitPrice);
        }
    }
}
