using DDMS.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Domian.Entities
{
    public class Salesman :AuditableEntity
    {
        private readonly List<Dispatch> _dispatches = new();
        private Salesman() { }

        private Salesman (string  name, string phone , string? address) { 
            
            Name = name;
            Phone = phone;
            Address = address;
        }

        public string Name { get; private set; } = string.Empty;

        public string Phone {  get; private set; }= string.Empty;

        public string? Address { get; private set; }
        public bool IsActive { get; private set; }

        public IReadOnlyCollection<Dispatch> dispatches => _dispatches.AsReadOnly();

        public static Salesman Create(string name , string phone , string? address)
        {
            if (string.IsNullOrWhiteSpace(name)){
                throw new ArgumentNullException("name is required");
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentNullException("phone is required");
            }
            return new Salesman(

                name.Trim(),
              phone.Trim(),
              address?.Trim()
       );
        }

        public void Update (String  name, String phone, String? address)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name is required");
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentNullException("phone is required");
            }

            Name = name;
            Phone = phone;
            Address = address;

        }

        public void SetStatus( bool isActive)
        {
            IsActive= isActive;
        }


    }
}
