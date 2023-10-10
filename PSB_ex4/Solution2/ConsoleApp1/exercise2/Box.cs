namespace ConsoleApp1;

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
    
    public bool Compare<TFruit>(Box<TFruit> box) where TFruit : Fruit, new()
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
        return $"Коробка<{typeof(T).Name}> с весом: {GetWeight()}, содержит {_fruits.Count} фруктов";
    }
}