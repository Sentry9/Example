namespace ConsoleApp1;

public class Garage
{
    public List<Car> cars = new List<Car>();

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public void WashAllCars(Action<Car> washAction)
    {
        foreach (var car in cars)
        {
            washAction(car);
        }
    }
}