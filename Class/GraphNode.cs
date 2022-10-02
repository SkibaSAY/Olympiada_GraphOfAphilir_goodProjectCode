using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GrafOfOphilir.Class
{
    public class GraphNode
    {
        #region Properties
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public char Symbol { get; set; }

        [JsonProperty(PropertyName = "mass")]
        public double Mass { get; set; }

        [JsonProperty(PropertyName = "thickness")]
        public double Thickness { get; set; }

        [JsonProperty(PropertyName = "diameter")]
        public double Diameter { get; set; }

        [JsonProperty(PropertyName = "width")]
        public double Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public double Height { get; set; }

        [JsonProperty(PropertyName = "shelf_width")]
        public int ShelfWidth { get; set; }

        [JsonProperty(PropertyName = "reference_id")]
        public IEnumerable<int> ReferenceIds { get; set; }
        #endregion

        public GraphNode()
        {

        }
    }
}
