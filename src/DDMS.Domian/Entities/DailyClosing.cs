using DDMS.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Domian.Entities
{
    public class DailyClosing:AuditableEntity
    {
        private readonly List<DailyClosingItem> _items = new();

        // EF Core
        private DailyClosing()
        {
        }

        private DailyClosing(
            Guid dispatchId,
            decimal collectedAmount,
            decimal dueAmount,
            decimal totalDamageAmount,
            string? remarks)
        {
            DispatchId = dispatchId;
            CollectedAmount = collectedAmount;
            DueAmount = dueAmount;
            TotalDamageAmount = totalDamageAmount;
            Remarks = remarks;
            ClosingDate = DateTime.UtcNow;
        }

        public Guid DispatchId { get; private set; }

        public DateTime ClosingDate { get; private set; }

        public decimal CollectedAmount { get; private set; }

        public decimal DueAmount { get; private set; }

        public decimal TotalDamageAmount { get; private set; }

        public string? Remarks { get; private set; }

        public Dispatch Dispatch { get; private set; } = null!;

        public IReadOnlyCollection<DailyClosingItem> Items => _items.AsReadOnly();

        public static DailyClosing Create(
            Guid dispatchId,
            decimal collectedAmount,
            decimal dueAmount,
            decimal totalDamageAmount,
            string? remarks)
        {
            if (dispatchId == Guid.Empty)
                throw new ArgumentException("Dispatch is required.");

            return new DailyClosing(
                dispatchId,
                collectedAmount,
                dueAmount,
                totalDamageAmount,
                remarks?.Trim());
        }

        public void AddItem(DailyClosingItem item)
        {
            _items.Add(item);
        }
    }
}
