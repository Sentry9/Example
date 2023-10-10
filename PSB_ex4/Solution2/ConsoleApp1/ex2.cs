namespace ConsoleApp1;
public abstract class Fruit
{
    protected double weight;
 
    public double Weight => weight;
 
    protected Fruit(double weight)
    {
        this.weight = weight;
    }
}
 
public class Apple: Fruit
{
    public Apple() : base(0.5)
    {
    }
}
 
public class Orange : Fruit
{
    public Orange() : base(0.3)
    {
    }
}
 
public class Box<T> where T: Fruit, new()
{
    private List<T> _fruits;
 
    public Box()
    {
        _fruits = new List<T>();
    }
    
    public void Add(T fruit)
    {
        _fruits.Add(fruit);
    }
    
    public double GetWeight()
    {
        return _fruits.Select(t => t.Weight).Sum();
    }
    
    public bool Compare<TF>(Box<TF> box) where TF : Fruit, new()
    {
        return this.GetWeight() == box.GetWeight();
    }
    
    public void AddFruits(Box<T> box)
    {
        if (box == this)
        {
            return;
        }
        this._fruits.AddRange(box._fruits);
        box._fruits.Clear();
    }
 
    public override string ToString()
    {
        return $"Box<{typeof(T).Name}> weight: {GetWeight()}, contains {_fruits.Count} fruits";
    }
}

public class ex2
{
    public static void EX2()
    {
        Box<Orange> orangeBox = new Box<Orange>();
        Console.WriteLine("Первая коробка с апельсинами: {0}", orangeBox);
        orangeBox.Add(new Orange());
        orangeBox.Add(new Orange());
        orangeBox.Add(new Orange());
        orangeBox.Add(new Orange());
        orangeBox.Add(new Orange());
        Console.WriteLine("Добавили 5 апельсинов: {0}", orangeBox);

        Box<Orange> orangeBox2 = new Box<Orange>();
        Console.WriteLine("Вторая коробка с апельсинами: {0}", orangeBox2);
        orangeBox2.Add(new Orange());
        orangeBox2.Add(new Orange());
        Console.WriteLine("\n Добавили 2 апельсина: {0}", orangeBox2);

        orangeBox.AddFruits(orangeBox2);
        Console.WriteLine("\nПосле пересыпания:");
        Console.WriteLine($"отсюда {orangeBox2} \nсюда {orangeBox}");

        Box<Apple> appleBox = new Box<Apple>();
        Console.WriteLine("\nКоробка с яблоками: {0}", appleBox);
        appleBox.Add(new Apple());
        appleBox.Add(new Apple());
        appleBox.Add(new Apple());
        Console.WriteLine("\nДобавили 3 яблока: {0}", appleBox);
        Console.WriteLine($"Равен ли вес {appleBox.GetWeight()} \nвесу {orangeBox.GetWeight()}?");
        Console.WriteLine(appleBox.Compare(orangeBox));
    }
}