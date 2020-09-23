using Newtonsoft.Json;
using System.Collections.Generic;

namespace FantasyAuction.Shared
{
    public class EndpointResponse
    {
        [JsonProperty("draw")] public int Draw { get; set; }

        [JsonProperty("recordsTotal")] public int RecordsTotal { get; set; }

        [JsonProperty("recordsFiltered")] public int RecordsFiltered { get; set; }

        [JsonProperty("pag")] public int Pag { get; set; }

        [JsonProperty("order_col")] public bool OrderCol { get; set; }

        [JsonProperty("order_dir")] public bool OrderDir { get; set; }

        [JsonProperty("data")] public IEnumerable<Player> Data { get; set; }
    }
}