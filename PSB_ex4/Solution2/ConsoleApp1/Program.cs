using ConsoleApp1;

class ex1
{
    public static void Change<T>(T[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i += 2)
        {
            T a = arr[i];
            arr[i] = arr[i + 1];
            arr[i + 1] = a;
        }
    }

    public static void PrintArr(int[] arr)
    {
        foreach (var number in arr)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }

    public static void EX1()
    {
        int[] arr = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9};
        Console.WriteLine("Первоначальный массив: ");
        PrintArr(arr);
        Change(arr);
        Console.WriteLine("Изменённый массив: ");
        PrintArr(arr);
    }
}

class Program
{
    static void Test()
    {
        Console.WriteLine("Введите номер задания(от 1 до 5) или 0 для завершения работы программы");
       int a = Convert.ToInt32(Console.ReadLine());
       if (a == 1)
       {
           Console.WriteLine("\n Задание 1: \n");
           ex1.EX1();
           Test();
       }
       else if (a == 2)
       {
           Console.WriteLine("\n Задание 2: \n");
           ex2.EX2();
           Test();
       }
       else if (a == 3)
       {
           Console.WriteLine("\n Задание 3: \n");
           ex3.EX3();
           Test();
       }
       else if (a == 4)
       {
           Console.WriteLine("\n Задание 4: \n");
           ex4.EX4();
           Test();
       }
       else if (a == 5)
       {
           Console.WriteLine("\n Задание 5 \n");
           ex5.EX5();
           Test();
       }
       else
       {
           return;
       }
    }
    public static void Main()
    {
        Test();
    }
}