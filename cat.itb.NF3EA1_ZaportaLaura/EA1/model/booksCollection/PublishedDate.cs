using System;
using Newtonsoft.Json;

namespace EA1.model.booksCollection
{

    [Serializable]
    public class PublishedDate
    {
        [JsonProperty("$date")]
        public string date { get; set; }

        public override string ToString()
        {
            return
                "PublishedDate{" +
                "$date = '" + date + '\'' +
                "}";
        }
    }
}
