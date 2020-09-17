using Newtonsoft.Json;

namespace FantaAsta.Shared
{
    public class Squadra
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("bonus_casa")]
        public string BonusCasa { get; set; }

        [JsonProperty("bonus_punti")]
        public string BonusPunti { get; set; }

        [JsonProperty("giornata")]
        public string Giornata { get; set; }

        [JsonProperty("img")]
        public string Img { get; set; }

        [JsonProperty("abbr")]
        public string Abbr { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("background")]
        public string Background { get; set; }

        [JsonProperty("border")]
        public string Border { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("id_user_insert")]
        public string IdUserInsert { get; set; }

        [JsonProperty("id_user_update")]
        public string IdUserUpdate { get; set; }

        [JsonProperty("date_insert")]
        public string DateInsert { get; set; }

        [JsonProperty("date_update")]
        public string DateUpdate { get; set; }

        [JsonProperty("deleted")]
        public string Deleted { get; set; }
    }
}