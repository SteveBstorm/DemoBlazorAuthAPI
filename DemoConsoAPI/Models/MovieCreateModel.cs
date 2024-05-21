namespace DemoConsoAPI.Models
{
    public class MovieCreateModel : SimpleMovieModel
    {
        public List<Actor> Casting { get; set; }
        public MovieCreateModel()
        {
            Casting = new List<Actor>();
        }
    }
}
