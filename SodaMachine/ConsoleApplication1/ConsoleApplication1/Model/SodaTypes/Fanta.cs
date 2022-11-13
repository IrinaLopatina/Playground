namespace ConsoleApplication1.Model.SodaTypes
{
    public class Fanta : ISoda
    {
        public string Name { get; private set; } = "fanta";
        public int Nr { get; set; }

        public int Price { get; private set; } = 15;
    }
}
