namespace cat.itb.NF3EA3_ZaportaLaura.model
{
    [Serializable]
    public class Book
    {
        //[JsonProperty("_id")]
        public int _id { get; set; }

        //[JsonProperty("title")]
        public String Title { get; set; }

        //[JsonProperty("isbn")]
        public String Isbn { get; set; }

        //[JsonProperty("pageCount")]
        public int PageCount { get; set; }

        //[JsonProperty("publishedDate")]
        public PublishedDate PublishedDate { get; set; }

        //[JsonProperty("thumbnailUrl")]
        public String ThumbnailUrl { get; set; }

        //[JsonProperty("shortDescription")]
        public String ShortDescription { get; set; }

        //[JsonProperty("longDescription")]
        public String LongDescription { get; set; }

        //[JsonProperty("status")]
        public String Status { get; set; }

        //[JsonProperty("authors")]
        public List<String> Authors { get; set; }

        //[JsonProperty("Categories")]
        public List<String> Categories { get; set; }
    }
}