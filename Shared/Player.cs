using Newtonsoft.Json;

namespace FantasyAuction.Shared
{
    public class Player
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("nome")] public string Nome { get; set; }

        [JsonProperty("ruolo")] public string Ruolo { get; set; }

        [JsonProperty("ruolo_mantra")] public string RuoloMantra { get; set; }

        [JsonProperty("img")] public string Img { get; set; }

        [JsonProperty("codice")] public string Codice { get; set; }

        [JsonProperty("costo")] public string Costo { get; set; }

        [JsonProperty("costo_fg")] public string CostoFg { get; set; }

        [JsonProperty("costo_ff")] public string CostoFf { get; set; }

        [JsonProperty("deviazione_standard")] public string DeviazioneStandard { get; set; }

        [JsonProperty("napoli_media_solo_voti")]
        public string NapoliMediaSoloVoti { get; set; }

        [JsonProperty("napoli_media_con_bonus")]
        public string NapoliMediaConBonus { get; set; }

        [JsonProperty("napoli_media_pesata")] public string NapoliMediaPesata { get; set; }

        [JsonProperty("napoli_media_3giornate")]
        public string NapoliMedia3giornate { get; set; }

        [JsonProperty("napoli_deviazione_standard")]
        public string NapoliDeviazioneStandard { get; set; }

        [JsonProperty("roma_media_solo_voti")] public string RomaMediaSoloVoti { get; set; }

        [JsonProperty("roma_media_con_bonus")] public string RomaMediaConBonus { get; set; }

        [JsonProperty("roma_media_pesata")] public string RomaMediaPesata { get; set; }

        [JsonProperty("roma_media_3giornate")] public string RomaMedia3giornate { get; set; }

        [JsonProperty("roma_deviazione_standard")]
        public string RomaDeviazioneStandard { get; set; }

        [JsonProperty("napoli_stat_media_solo_voti")]
        public string NapoliStatMediaSoloVoti { get; set; }

        [JsonProperty("napoli_stat_media_con_bonus")]
        public string NapoliStatMediaConBonus { get; set; }

        [JsonProperty("napoli_stat_media_pesata")]
        public string NapoliStatMediaPesata { get; set; }

        [JsonProperty("napoli_stat_media_3giornate")]
        public string NapoliStatMedia3giornate { get; set; }

        [JsonProperty("napoli_stat_deviazione_standard")]
        public string NapoliStatDeviazioneStandard { get; set; }

        [JsonProperty("italia_media_solo_voti")]
        public string ItaliaMediaSoloVoti { get; set; }

        [JsonProperty("italia_media_con_bonus")]
        public string ItaliaMediaConBonus { get; set; }

        [JsonProperty("italia_media_pesata")] public string ItaliaMediaPesata { get; set; }

        [JsonProperty("italia_media_3giornate")]
        public string ItaliaMedia3giornate { get; set; }

        [JsonProperty("italia_deviazione_standard")]
        public string ItaliaDeviazioneStandard { get; set; }

        [JsonProperty("id_squadra")] public string IdSquadra { get; set; }

        [JsonProperty("media_con_bonus")] public string MediaConBonus { get; set; }

        [JsonProperty("media_solo_voti")] public string MediaSoloVoti { get; set; }

        [JsonProperty("media_pesata")] public string MediaPesata { get; set; }

        [JsonProperty("media_3giornate")] public string Media3giornate { get; set; }

        [JsonProperty("ultima_giornata")] public string UltimaGiornata { get; set; }

        [JsonProperty("n_giornate")] public string NGiornate { get; set; }

        [JsonProperty("giornata_inizio")] public string GiornataInizio { get; set; }

        [JsonProperty("stato_tv")] public string StatoTv { get; set; }

        [JsonProperty("stato_giornale")] public string StatoGiornale { get; set; }

        [JsonProperty("stato_mediaset")] public string StatoMediaset { get; set; }

        [JsonProperty("stato_corriere")] public string StatoCorriere { get; set; }

        [JsonProperty("time_stato_web")] public string TimeStatoWeb { get; set; }

        [JsonProperty("time_stato_tv")] public string TimeStatoTv { get; set; }

        [JsonProperty("time_stato_giornale")] public string TimeStatoGiornale { get; set; }

        [JsonProperty("time_stato_mediaset")] public string TimeStatoMediaset { get; set; }

        [JsonProperty("time_stato_corriere")] public string TimeStatoCorriere { get; set; }

        [JsonProperty("stato_web")] public string StatoWeb { get; set; }

        [JsonProperty("motivo")] public string Motivo { get; set; }

        [JsonProperty("rientro")] public string Rientro { get; set; }

        [JsonProperty("note")] public string Note { get; set; }

        [JsonProperty("gol_fatti_subiti")] public string GolFattiSubiti { get; set; }

        [JsonProperty("rigori_tirati_parati")] public string RigoriTiratiParati { get; set; }

        [JsonProperty("rigori_segnati")] public string RigoriSegnati { get; set; }

        [JsonProperty("assist")] public string Assist { get; set; }

        [JsonProperty("ammonizioni")] public string Ammonizioni { get; set; }

        [JsonProperty("espulsioni")] public string Espulsioni { get; set; }

        [JsonProperty("titolare")] public string Titolare { get; set; }

        [JsonProperty("alias")] public string Alias { get; set; }

        [JsonProperty("alias2")] public string Alias2 { get; set; }

        [JsonProperty("alias3")] public string Alias3 { get; set; }

        [JsonProperty("alias4")] public string Alias4 { get; set; }

        [JsonProperty("alias5")] public string Alias5 { get; set; }

        [JsonProperty("anno_scorso_media_solo_voti")]
        public string AnnoScorsoMediaSoloVoti { get; set; }

        [JsonProperty("anno_scorso_media_con_bonus")]
        public string AnnoScorsoMediaConBonus { get; set; }

        [JsonProperty("anno_in_corso")] public string AnnoInCorso { get; set; }

        [JsonProperty("id_user_insert")] public string IdUserInsert { get; set; }

        [JsonProperty("id_user_update")] public string IdUserUpdate { get; set; }

        [JsonProperty("date_insert")] public string DateInsert { get; set; }

        [JsonProperty("date_update")] public string DateUpdate { get; set; }

        [JsonProperty("deleted")] public string Deleted { get; set; }

        [JsonProperty("squadra")] public Team Squadra { get; set; }
    }
}