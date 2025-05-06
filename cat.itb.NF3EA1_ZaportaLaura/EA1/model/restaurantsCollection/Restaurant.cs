using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA1.model.restaurantsCollection
{
    public class Restaurant
    {
        public Address? address { get; set; }
        public string? borough { get; set; }
        public string? cuisine { get; set; }
        public IList<Grade> grades { get; set; }
        public string? name { get; set; }
        public string? restaurant_id { get; set; }
    }
}
