namespace ConsoleApp1;

public abstract class Fruit
{
    public double Weight { get; }
 
    protected Fruit(double weight)
    {
        Weight = weight;
    }
}