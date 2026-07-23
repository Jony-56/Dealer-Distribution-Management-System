using DDMS.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Domian.Entities
{
    public class ProductGroup:AuditableEntity
    {
        private readonly List<Product> _products = new();

        private ProductGroup() { }

        private ProductGroup( string name, string?  description)
        {
            Name = name;
            Description = description;
            IsActive = true;
        }
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public bool IsActive { get; private set; }

        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
        public static ProductGroup Create(string name, string? description) 
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Product Group Name is required");
            }
            return new ProductGroup(name.Trim(), description?.Trim());
            
        }

        public void Update (string  name, string? description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product Group Name is Required");
            }
            
            Name = name.Trim();
            Description = description?.Trim();
        }
       public void SetStatus (bool isactive)
        {
            IsActive = isactive;
        }

    }
}
