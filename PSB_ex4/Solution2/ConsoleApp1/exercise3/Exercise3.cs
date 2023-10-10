namespace ConsoleApp1;
public class Exercise3
{
    public static void LaunchExercise3()
    {
        Car car1 = new Car("Toyota");
        Car car2 = new Car("Audi");
        Car car3 = new Car("BMW");
        Garage garage = new Garage();
        garage.AddCar(car1);
        garage.AddCar(car2);
        garage.AddCar(car3);
        Washer washer = new Washer();
        Action<Car> washAction = washer.Wash;
        garage.WashAllCars(washAction);
    }
}