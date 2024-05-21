namespace DemoConsoAPI.Models
{
    public class CompleteMovieModel : SimpleMovieModel
    {
        public Personne Realisator { get; set; }
        public IEnumerable<Actor> Casting { get; set; }
    }
}
