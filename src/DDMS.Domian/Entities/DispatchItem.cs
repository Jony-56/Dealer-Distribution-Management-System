using DDMS.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Domian.Entities
{
    public class DispatchItem:AuditableEntity
    {
        private DispatchItem()
        {
        }

        private DispatchItem(
            Guid dispatchId,
            Guid productId,
            int cartonQty,
            int pieceQty)
        {
            DispatchId = dispatchId;
            ProductId = productId;
            CartonQty = cartonQty;
            PieceQty = pieceQty;
        }

        public Guid DispatchId { get; private set; }

        public Guid ProductId { get; private set; }

        public int CartonQty { get; private set; }

        public int PieceQty { get; private set; }

        public Dispatch Dispatch { get; private set; } = null!;

        public Product Product { get; private set; } = null!;

        public static DispatchItem Create(
            Guid dispatchId,
            Guid productId,
            int cartonQty,
            int pieceQty)
        {
            if (dispatchId == Guid.Empty)
                throw new ArgumentException("Dispatch is required.");

            if (productId == Guid.Empty)
                throw new ArgumentException("Product is required.");

            if (cartonQty < 0 || pieceQty < 0)
                throw new ArgumentException("Quantity cannot be negative.");

            return new DispatchItem(
                dispatchId,
                productId,
                cartonQty,
                pieceQty);
        }
    }
}
