using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EA1.model.restaurantsCollection
{
    public class DateRes
    {
        [JsonProperty("$date")]
        public long? Date { get; set; }
    }
}
