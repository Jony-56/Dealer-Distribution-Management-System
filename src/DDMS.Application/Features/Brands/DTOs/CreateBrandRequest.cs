using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Application.Features.Brands.DTOs
{
    public class CreateBrandRequest
    {
        public string Name { get; set; }=string.Empty;
        public string? Description { get; set; }

        public string Code { get; set; } = string.Empty;
    }
}
