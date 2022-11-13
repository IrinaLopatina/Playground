namespace ConsoleApplication1.Model.SodaTypes
{
    public interface ISoda
    {
        string Name { get; }
        int Nr { get; set; }
        int Price { get; }
    }
}
