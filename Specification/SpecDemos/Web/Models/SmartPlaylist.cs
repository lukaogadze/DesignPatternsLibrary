using Newtonsoft.Json;
using Web.Models.Specs;

namespace Web.Models
{
    public class SmartPlaylist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GlobalSongSpecification Specification { get; set; }

        [JsonIgnore]
        public string Json
        {
            get { return JsonConvert.SerializeObject(Specification); }
            set { Specification = JsonConvert.DeserializeObject<GlobalSongSpecification>(value); }
        }
    }
}
