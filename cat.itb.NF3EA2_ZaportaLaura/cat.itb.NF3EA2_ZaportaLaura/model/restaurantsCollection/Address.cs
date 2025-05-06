using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA1.model.restaurantsCollection
{
    public class Address
    {
        public string? building { get; set; }
        public IList<double>? coord { get; set; }
        public string? street { get; set; }
        public string? zipcode { get; set; }
    }
}
