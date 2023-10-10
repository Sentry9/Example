namespace ConsoleApp1;

public class Cat
{
    public string Name { get; }
    public static int CatCapacity;

    public Cat(int id, int catCapacity)
    {
        Name = $"КОТ-{id}";
        CatCapacity = catCapacity;
    }

    public async Task Eat(BowlLimiter limiter)
    {
        Console.WriteLine($"{Name} подходит к миске");
        await limiter.CheckBowl();
        Console.WriteLine($"{Name} давится кормом");
        await Task.Delay(3000);
        Console.WriteLine($"{Name} поел и ушёл");
    }
}