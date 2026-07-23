using DDMS.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Domian.Entities
{
    public class Dispatch:AuditableEntity
    {
        private readonly List<DispatchItem> _items = new();

        // EF Core
        private Dispatch()
        {
        }

        private Dispatch(
            Guid salesmanId,
            DateTime dispatchDate,
            string? remarks)
        {
            SalesmanId = salesmanId;
            DispatchDate = dispatchDate;
            Remarks = remarks;
            IsCompleted = false;
        }

        public Guid SalesmanId { get; private set; }

        public DateTime DispatchDate { get; private set; }

        public string? Remarks { get; private set; }

        public bool IsCompleted { get; private set; }

        public Salesman Salesman { get; private set; } = null!;

        public DailyClosing? DailyClosing { get; private set; }

        public IReadOnlyCollection<DispatchItem> Items => _items.AsReadOnly();

        public static Dispatch Create(
            Guid salesmanId,
            DateTime dispatchDate,
            string? remarks)
        {
            if (salesmanId == Guid.Empty)
                throw new ArgumentException("Salesman is required.");

            return new Dispatch(
                salesmanId,
                dispatchDate,
                remarks?.Trim());
        }

        public void AddItem(DispatchItem item)
        {
            _items.Add(item);
        }

        public void Complete()
        {
            IsCompleted = true;
        }
    }
}
