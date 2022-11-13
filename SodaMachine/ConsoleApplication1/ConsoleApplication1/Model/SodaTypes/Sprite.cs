namespace ConsoleApplication1.Model.SodaTypes
{
    public class Sprite : ISoda
    {
        public string Name { get; private set; } = "sprite";
        public int Nr { get; set; }

        public int Price { get; private set; } = 15;
    }
}
