using Newtonsoft.Json;

namespace  Fiver.Lib.MongoDB.Client.OtherLayers
{
    public class Movie : MongoEntityBase
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Summary { get; set; }
    }
}
