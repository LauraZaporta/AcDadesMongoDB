using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA1.model.countriesCollection
{
    public class Country
    {
        public string? name { get; set; }
        public IList<string>? topLevelDomain { get; set; }
        public string? alpha2Code { get; set; }
        public string? alpha3Code { get; set; }
        public IList<string?>? callingCodes { get; set; }
        public string? capital { get; set; }
        public IList<string>? altSpellings { get; set; }
        public string? region { get; set; }
        public string? subregion { get; set; }
        public int? population { get; set; }
        public IList<double>? latlng { get; set; }
        public string? demonym { get; set; }
        public double? area { get; set; }
        public double? gini { get; set; }
        public IList<string>? timezones { get; set; }
        public IList<string>? borders { get; set; }
        public string? nativeName { get; set; }
        public int? numericCode { get; set; }
        public IList<Currency>? currencies { get; set; }
        public IList<Language>? languages { get; set; }
        public Dictionary<string, string>? translations { get; set; }
        public string? flag { get; set; }
        public IList<RegionalBloc>? regionalBlocs { get; set; }
        public string? cioc { get; set; }
    }
}