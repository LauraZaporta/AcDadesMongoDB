using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EA1.model.countriesCollection
{
    [Serializable]
    public class Country
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string? Name { get; set; }
        public IList<string>? TopLevelDomain { get; set; }
        public string? Alpha2Code { get; set; }
        public string? Alpha3Code { get; set; }
        public IList<string?>? CallingCodes { get; set; }
        public string? Capital { get; set; }
        public IList<string>? AltSpellings { get; set; }
        public string? Region { get; set; }
        public string? Subregion { get; set; }
        public int? Population { get; set; }
        public IList<double>? Latlng { get; set; }
        public string? Demonym { get; set; }
        public double? Area { get; set; }
        public double? Gini { get; set; }
        public IList<string>? Timezones { get; set; }
        public IList<string>? Borders { get; set; }
        public string? NativeName { get; set; }
        public int? NumericCode { get; set; }
        public IList<Currency>? Currencies { get; set; }
        public IList<Language>? Languages { get; set; }
        public Dictionary<string, string>? Translations { get; set; }
        public string? Flag { get; set; }
        public IList<RegionalBloc>? RegionalBlocs { get; set; }
        public string? Cioc { get; set; }
    }
}