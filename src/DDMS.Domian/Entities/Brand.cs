using DDMS.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Domian.Entities
{
    public class Brand:AuditableEntity
    {
        private readonly List<Product> _products = new();

        private Brand()
        {

        }
        private Brand(string name , string code , string? description)
        {
            Name = name;
            Code = code;
            Description = description;
            IsActive = true;
        }
        public string Name { get; private set; }= string.Empty;
        public string Code { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public bool  IsActive { get; private set; }

        public IReadOnlyCollection<Product> products => _products.AsReadOnly();

        public static Brand Create (string name , string code , string? description)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Brand name is required");
            }
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException("Brand Code is required");
            }
            return new Brand(
                name.Trim() ,
                code.Trim().ToUpper() ,
                description?.Trim()
                );

        }
        public void Update (string name , string code , string? description)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Brand name is required");
            }
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException("Brand Code is required");
            }

            Name = name.Trim();
            Code = code.Trim().ToUpper();
            Description = description?.Trim();
        }
        public void SetStatus(bool isactive)
        {
            IsActive = isactive;
        }
    }
}
