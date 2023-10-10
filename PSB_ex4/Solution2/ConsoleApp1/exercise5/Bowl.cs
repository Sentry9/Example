namespace ConsoleApp1;

public class Bowl
{
    public int BowlCapacity { get; }
    
    internal int Current { get; set; }

    public Bowl(int bowlCapacity)
    {
        BowlCapacity = bowlCapacity;
        Current = bowlCapacity;
    }
}