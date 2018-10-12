namespace Pluralsight.Mediator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var yytCenter = new YytCenter();
            
            var flight1 = new Airbus321("AC159", yytCenter);
            var flight2 = new Boeing737200("WS203", yytCenter);
            var flight3 = new Embraer190("AC602", yytCenter);

            flight1.Altitude += 1000;

        }
    }
}