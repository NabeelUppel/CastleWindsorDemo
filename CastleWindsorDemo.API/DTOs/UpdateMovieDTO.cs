namespace CastleWindsorDemo.API.DTOs
{
    public class UpdateMovieDTO : MediaBaseDTO
    {
        public int Id { get; set; }
        public int RunTime { get; set; }
    }
}
