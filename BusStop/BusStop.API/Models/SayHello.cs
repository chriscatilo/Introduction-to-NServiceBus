namespace BusStop.API.Models
{
    public interface ISayHello
    {
        string Hello { get; }
    }

    public class SayHello : ISayHello
    {
        public string Hello { get; } = "Hello There";
    }
}