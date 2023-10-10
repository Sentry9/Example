namespace ConsoleApp1;  
public class Exercise5
{
    private static int CatCount = 10;
    private static int CatCapacity = 1;
    private static int BowlCatCount = 3;
    private static int BowlCapacity = 2;
    private static Bowl Bowl = new Bowl(BowlCapacity);
    private static BowlLimiter bowlLimiter = new BowlLimiter(Bowl, BowlCatCount);

    private static CancellationTokenSource cts = new CancellationTokenSource();

    public static async Task LaunchExercise5()
    {
        DateTime start = DateTime.Now;

        List<Cat> cats = new List<Cat>();

        for (int i = 1; i <= CatCount; i++)
        {
            Cat cat = new Cat(i, CatCapacity);
            cats.Add(cat);
        }

        try
        {
            int catIndex = 0;
            while (catIndex < CatCount)
            {
                if (cts.Token.IsCancellationRequested)
                {
                    break; // Отмена выполнения цикла
                }

                List<Cat> catGroup = cats.GetRange(catIndex, Math.Min(BowlCatCount, CatCount - catIndex));
                catIndex += BowlCatCount;

                await Task.WhenAll(catGroup.ConvertAll(cat => cat.Eat(bowlLimiter)));
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Потоки были отменены.");
        }

        DateTime end = DateTime.Now;
        Console.WriteLine("На покормку всех котиков ушло " + (end - start).TotalSeconds);
        
    }

    public static void CancelThreads()
    {
        cts.Cancel();
    }
    
}
