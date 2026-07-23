using DDMS.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Domian.Entities
{
    public class StockEntry:AuditableEntity
    {
        private readonly List<StockEntryItem> _items = new();

        // EF Core
        private StockEntry()
        {
        }

        private StockEntry(
            DateTime entryDate,
            string invoiceNo,
            string? remarks)
        {
            EntryDate = entryDate;
            InvoiceNo = invoiceNo;
            Remarks = remarks;
        }

        public DateTime EntryDate { get; private set; }

        public string InvoiceNo { get; private set; } = string.Empty;

        public string? Remarks { get; private set; }

        public IReadOnlyCollection<StockEntryItem> Items => _items.AsReadOnly();

        public static StockEntry Create(
            DateTime entryDate,
            string invoiceNo,
            string? remarks)
        {
            if (string.IsNullOrWhiteSpace(invoiceNo))
                throw new ArgumentException("Invoice number is required.");

            return new StockEntry(
                entryDate,
                invoiceNo.Trim(),
                remarks?.Trim());
        }

        public void Update(
            DateTime entryDate,
            string invoiceNo,
            string? remarks)
        {
            EntryDate = entryDate;

            InvoiceNo = invoiceNo.Trim();

            Remarks = remarks?.Trim();
        }

        public void AddItem(StockEntryItem item)
        {
            _items.Add(item);
        }
    }
}
