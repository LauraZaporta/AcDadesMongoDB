using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EA1.model.restaurantsCollection
{
    public class Grade
    {
        public Date? date { get; set; }
        public string? grade { get; set; }
        public int? score { get; set; }
    }
}
