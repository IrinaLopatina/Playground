namespace ConsoleApplication1.Model.SodaTypes
{
    public class Coke : ISoda
    {
        public string Name { get; private set; } = "coke";

        public int Price { get; private set; } = 20;
    }
}
