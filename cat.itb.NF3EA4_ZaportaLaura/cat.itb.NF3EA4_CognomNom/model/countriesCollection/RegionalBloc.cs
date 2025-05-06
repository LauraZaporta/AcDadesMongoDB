using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA1.model.countriesCollection
{
    public class RegionalBloc
    {
        public string? Acronym { get; set; }
        public string? Name { get; set; }
        public IList<string>? OtherAcronyms { get; set; }
        public IList<string>? OtherNames { get; set; }
    }
}