namespace CastleWindsorDemo.API.DTOs
{
    public class TVShowDTO : MediaBaseDTO
    {
        public int TotalEpisodes { get; set; }
        public int Seasons { get; set; }
    }
}
