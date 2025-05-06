using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EA1.model.restaurantsCollection
{
    public class Date
    {
        [JsonProperty("$date")]
        public long? date { get; set; }
    }
}
