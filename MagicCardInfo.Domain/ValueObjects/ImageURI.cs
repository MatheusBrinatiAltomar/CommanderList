using System.Text.Json.Serialization;

namespace MagicCardInfo.Domain.ValueObjects
{
    public class ImageURI 
    {   
        [JsonPropertyName("normal")]
        public string Normal { get; private set; }

        private ImageURI () {}

        public ImageURI(string normal)
        {
            Normal = normal;
        }
    }
}