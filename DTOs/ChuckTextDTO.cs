namespace EjemploEntity.DTOs
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<ChuckTextDTO>(myJsonResponse);
    public class Result
    {
        public List<string> categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }

    public class ChuckTextDTO
    {
        public int total { get; set; }
        public List<Result> result { get; set; }
    }

}
