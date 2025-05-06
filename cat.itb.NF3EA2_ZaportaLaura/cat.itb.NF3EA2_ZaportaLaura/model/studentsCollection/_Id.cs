using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EA1.model.studentsCollection
{
    public class _Id
    {
        [JsonProperty("$oid")]
        public string? _id { get; set; }
    }
}
