using DDMS.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Domian.Entities
{
    public class Expense:AuditableEntity
    {
        private Expense()
        {
        }

        private Expense(
            DateTime expenseDate,
            string category,
            decimal amount,
            string? description)
        {
            ExpenseDate = expenseDate;
            Category = category;
            Amount = amount;
            Description = description;
        }

        public DateTime ExpenseDate { get; private set; }

        public string Category { get; private set; } = string.Empty;

        public decimal Amount { get; private set; }

        public string? Description { get; private set; }

        public static Expense Create(
            DateTime expenseDate,
            string category,
            decimal amount,
            string? description)
        {
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Expense category is required.");

            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            return new Expense(expenseDate, category.Trim(), amount, description?.Trim());
        }
    }
}
