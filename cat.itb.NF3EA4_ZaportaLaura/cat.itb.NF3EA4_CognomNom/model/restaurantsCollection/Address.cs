using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA1.model.restaurantsCollection
{
    public class Address
    {
        public string? Building { get; set; }
        public IList<double>? Coord { get; set; }
        public string? Street { get; set; }
        public string? Zipcode { get; set; }
    }
}