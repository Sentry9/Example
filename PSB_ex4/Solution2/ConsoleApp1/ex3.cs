namespace ConsoleApp1;

public class Car
{
    public string Name { get; set; }
    public Car(string name)
    {
        Name = name;
    }
}

public class Garage
{
    public List<Car> cars = new List<Car>();

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public void WashAllCars(WashDelegate washDelegate)
    {
        foreach (var car in cars)
        {
            washDelegate(car);
        }
    }
}

public delegate void WashDelegate(Car car);

public class Washer
{
    public void Wash(Car car)
    { 
        Console.WriteLine("Машина " + car.Name + " помыта");
    }
}


public class ex3
{
    public static void EX3()
    {
        Car car1 = new Car("Toyota");
        Car car2 = new Car("Audi");
        Car car3 = new Car("BMW");
        Garage garage = new Garage();
        garage.AddCar(car1);
        garage.AddCar(car2);
        garage.AddCar(car3);
        Washer washer = new Washer();
        WashDelegate washDelegate = new WashDelegate(washer.Wash);
        garage.WashAllCars(washDelegate);
    }
}