using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EA1.model.gradesBD
{
    [Serializable]
    public class Score
    {
        public string? type { get; set; }

        [JsonProperty("$numberDouble")]
        public double? score { get; set; }
    }
}