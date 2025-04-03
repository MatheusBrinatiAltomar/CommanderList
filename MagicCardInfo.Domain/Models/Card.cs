using System.Text.Json.Serialization;
using MagicCardInfo.Domain.ValueObjects;

namespace MagicCardInfo.Domain.Models
{
    public class Card 
    {
        [JsonPropertyName("id")]
        public Guid Id { get; private set; }

        [JsonPropertyName("name")]
        public string Name { get; private set; }

        [JsonPropertyName("oracle_text")]
        public string OracleText { get; private set; }

        [JsonPropertyName("mana_cost")]
        public string ManaCost { get; private set; }

        [JsonPropertyName("type_line")]
        public string TypeLine { get; private set; }

        [JsonPropertyName("scryfall_uri")]
        public string ScryfallURI { get; private set; }

        [JsonPropertyName("image_uris")]
        public ImageURI? ImageURIs { get; private set; }

        private Card () {}

        public Card (Guid id, string name, string oracleText, string manaCost, string typeLine, string scryfallURI, ImageURI imageURIs) 
        {
            Id = id;
            Name = name;
            OracleText = oracleText;
            ManaCost = manaCost;
            TypeLine = typeLine;
            ScryfallURI = scryfallURI;
            ImageURIs = imageURIs;
        }
    }
}