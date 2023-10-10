namespace ConsoleApp1;
class Exercise1
{
    public static void Change<T>(T[] array)
    {
        for (int i = 0; i < array.Length - 1; i += 2)
        {
            var a = array[i];
            array[i] = array[i + 1];
            array[i + 1] = a;
        }
    }

    public static void PrintIntArray(int[] array)
    {
        foreach (var number in array)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }

    public static void LaunchExercise1()
    {
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9};
        Console.WriteLine("Первоначальный массив: ");
        PrintIntArray(array);
        Change(array);
        Console.WriteLine("Изменённый массив: ");
        PrintIntArray(array);
    }
}
