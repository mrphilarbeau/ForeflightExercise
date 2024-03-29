namespace ForeflightExercise.Models
{
    public class Conditions
    {
        public double TempC {  get; set; }
        public double TempF => 32 + (int)(TempC / 0.5556);
        public double RelativeHumidity { get; set; }
        public List<CloudLayer> CloudLayers { get; set; }
        public Visibility Visibility { get; set; }
        public Wind Wind { get; set; }
        public string DateIssued { get; set; }
    }
}
