using Newtonsoft.Json;

namespace cat.itb.NF3EA3_ZaportaLaura.model
{
    [Serializable]
    public class PublishedDate
    {
        [JsonProperty("$date")]
        public String Date { get; set; }
    }
}