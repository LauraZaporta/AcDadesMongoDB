using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EA1.model.gradesCollection
{
    public class Student_id
    {
        [JsonProperty("$numberInt")]
        public int? student_id { get; set; }
    }
}
