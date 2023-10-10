namespace ConsoleApp1;

public class BowlLimiter
{
    private SemaphoreSlim catCountLimiter;
    private Bowl bowl;
    private object locker = new object();

    public BowlLimiter(Bowl bowl, int catCountLimiterCapacity)
    {
        catCountLimiter = new SemaphoreSlim(catCountLimiterCapacity, catCountLimiterCapacity);
        this.bowl = bowl;
    }

    public async Task CheckBowl()
    {
        await catCountLimiter.WaitAsync();

        lock (locker)
        {
            if (bowl.Current < Cat.CatCapacity)
            {
                Console.WriteLine("Бабуся наполняет миску");
                bowl.Current = bowl.BowlCapacity;
            }
            bowl.Current -= Cat.CatCapacity;
        }

        catCountLimiter.Release();
    }
}