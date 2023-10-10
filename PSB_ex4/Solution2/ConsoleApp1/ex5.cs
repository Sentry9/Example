namespace ConsoleApp1;

public class Bowl
{
    // Вместительность миски
    public int M { get; }
    
    // Текущая наполненность
    internal int Current { get; set; }

    public Bowl(int m)
    {
        M = m;
        Current = m;
    }
}
public class Cat
{
    private Thread _thread;
    public string Name { get; }
    internal static Semaphore sem;
    internal static object locker;
    private int _b;
    internal static Bowl bowl;

    public Cat(int id, ref object locker, int b, Bowl bowl)
    {
        if (sem == null)
        {
            sem = new Semaphore(1, 1);
        }

        Cat.bowl = bowl;
        Cat.locker = locker;
        Name = $"Cat#{id}";
        _b = b;
        _thread = new Thread(Eat);
        _thread.Name = Name;
        _thread.Start();
    }

    public void Eat()
    {
        sem.WaitOne();
        Console.WriteLine($"{Name} подходит к миске");
        lock (locker)
        {
            if (bowl.Current < _b)
            {
                Console.WriteLine("Бабушка наполняет миску до краев");
                bowl.Current = bowl.M;
            }

            bowl.Current = bowl.Current - _b;
            Console.WriteLine($"{Name} жует корм");
        }
        
        Thread.Sleep(3000);
        Console.WriteLine($"{Name} поел и уходит");
        sem.Release();
    }
}

public class ex5
{
    public static int N = 10;  // Количество котиков
    public static int B = 1;  // Количество корма, которое съедает один котик
    public static int K = 2;  // Максимальное количество котиков у миски
    public static Bowl Bowl = new Bowl(2);  // Миска
    public static object Locker = new();  // Объект для синхронизации доступа к миске
    

    public static void EX5()
    {
        Cat.sem = new Semaphore(K, K);
        
        for (int i = 1; i <= N; i++)
        {
            Cat cat = new Cat(i, ref Locker, B, Bowl);
        }
    }
}
