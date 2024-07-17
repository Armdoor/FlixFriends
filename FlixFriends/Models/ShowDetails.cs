using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlixFriends.Models
{
    public class ShowDetails
    {
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("created_by")]
        public List<Creator> CreatedBy { get; set; }

        [JsonProperty("episode_run_time")]
        public List<int> EpisodeRunTime { get; set; }

        [JsonProperty("first_air_date")]
        public DateTime FirstAirDate { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("in_production")]
        public bool InProduction { get; set; }

        [JsonProperty("languages")]
        public List<string> Languages { get; set; }

        [JsonProperty("last_air_date")]
        public DateTime LastAirDate { get; set; }

        [JsonProperty("last_episode_to_air")]
        public Episode LastEpisodeToAir { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("next_episode_to_air")]
        public Episode NextEpisodeToAir { get; set; }

        [JsonProperty("networks")]
        public List<Network> Networks { get; set; }

        [JsonProperty("number_of_episodes")]
        public int NumberOfEpisodes { get; set; }

        [JsonProperty("number_of_seasons")]
        public int NumberOfSeasons { get; set; }

        [JsonProperty("origin_country")]
        public List<string> OriginCountry { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("production_companies")]
        public List<ProductionCompany> ProductionCompanies { get; set; }

        [JsonProperty("production_countries")]
        public List<ProductionCountry> ProductionCountries { get; set; }

        [JsonProperty("seasons")]
        public List<Season> Seasons { get; set; }

        [JsonProperty("spoken_languages")]
        public List<SpokenLanguage> SpokenLanguages { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("credits")]
        public Credits Credits { get; set; }
    }

    public class Creator
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("credit_id")]
        public string CreditId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }
    }

    

    public class Episode
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("air_date")]
        public DateTime AirDate { get; set; }

        [JsonProperty("episode_number")]
        public int EpisodeNumber { get; set; }

        [JsonProperty("episode_type")]
        public string EpisodeType { get; set; }

        [JsonProperty("production_code")]
        public string ProductionCode { get; set; }

        [JsonProperty("runtime")]
        public int? Runtime { get; set; }

        [JsonProperty("season_number")]
        public int SeasonNumber { get; set; }

        [JsonProperty("show_id")]
        public int ShowId { get; set; }

        [JsonProperty("still_path")]
        public string StillPath { get; set; }
    }

    public class Network
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("logo_path")]
        public string LogoPath { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("origin_country")]
        public string OriginCountry { get; set; }
    }
    

    public class Season
    {
        [JsonProperty("air_date")]
        public DateTime AirDate { get; set; }

        [JsonProperty("episode_count")]
        public int EpisodeCount { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("season_number")]
        public int SeasonNumber { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }
    }

    public class SpokenLanguage
    {
        [JsonProperty("english_name")]
        public string EnglishName { get; set; }

        [JsonProperty("iso_639_1")]
        public string Iso6391 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

   

    public class ShowCast
    {
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("known_for_department")]
        public string KnownForDepartment { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }

        [JsonProperty("character")]
        public string Character { get; set; }

        [JsonProperty("credit_id")]
        public string CreditId { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }
    }

    public class ShowCrew
    {
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("known_for_department")]
        public string KnownForDepartment { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }

        [JsonProperty("credit_id")]
        public string CreditId { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }
    }
}
