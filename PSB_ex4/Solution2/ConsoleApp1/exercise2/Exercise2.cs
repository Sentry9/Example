namespace ConsoleApp1;
public class Exercise2
{
    public static void LaunchExercise2()
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