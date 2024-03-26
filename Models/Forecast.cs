namespace ForeflightExercise.Models
{
    public class Forecast
    {
        public Period Period { get; set; }
        public List<Conditions> Conditions { get; set; }
    }
}
