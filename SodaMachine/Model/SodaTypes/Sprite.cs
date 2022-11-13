namespace SodaMachine.Model.SodaTypes
{
    public class Sprite : ISoda
    {
        public string Name { get; private set; } = "sprite";

        public int Price { get; private set; } = 15;
    }
}
