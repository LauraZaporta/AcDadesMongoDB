using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EA1.model.restaurantsCollection
{
    public class GradeRes
    {
        public DateRes? Date { get; set; }
        public string? Grade { get; set; }
        public int? Score { get; set; }
    }
}
