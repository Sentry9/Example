using static PSB_ex3.EX1;
using static PSB_ex3.EX2;
using static PSB_ex3.EX3;

class Program
{
    private static void EX0()
    {
        void WriteList(List<int> numbersList)
        {
            foreach (int number in numbersList)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }

        List<int> numbers = new List<int>() { 2, 3 };
        Console.WriteLine(
            "Создан пустой список под названием numbers с 2-мя элементами(Чтобы обозначить начало и конец)");
        WriteList(numbers);
        numbers.Add(5);
        Console.WriteLine("Добавлено число 5 в конец");
        WriteList(numbers);
        numbers.Insert(0, 1);
        Console.WriteLine("Добавлено число 1 в начало");
        WriteList(numbers);
        numbers.Insert(3, 4);
        Console.WriteLine("Добавлено число 4 на 4 позицию");
        WriteList(numbers);
        numbers.RemoveAt(numbers.Count - 1);
        Console.WriteLine("Удалён последний элемент");
        WriteList(numbers);
        numbers.RemoveAt(0);
        Console.WriteLine("Удалён первый элемент");
        WriteList(numbers);
        numbers.RemoveAt(1);
        Console.WriteLine("Удалён второй элемент");
        WriteList(numbers);
        List<int> numbers1 = new List<int>() { 6, 8, 10, 12, 14, 16, 18, 20, 22 };
        Console.WriteLine("Созданный новый список");
        WriteList(numbers1);
        List<int> mergedNumbers = new List<int>(numbers);
        mergedNumbers.AddRange(numbers1);
        Console.WriteLine("Объединённый список");
        WriteList(mergedNumbers);
        int max = mergedNumbers[0];
        foreach (var number in mergedNumbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine("Максимальный элемент : " + max);
        Console.WriteLine("Весь список");
        WriteList(mergedNumbers);
        List<int> numbers2 = new List<int>() { 1, 2, 3, 4, 5, 6 };
        Console.WriteLine("Создан новый список numbers2");
        WriteList(numbers2);
        //List<int> evenNumbers = numbers2.Where(num => num % 2 == 0).ToList();
        List<int> evenNumbers = new List<int>();
        foreach (var number in numbers2)
        {
            if (number % 2 == 0)
            {
                evenNumbers.Add(number);
            }
        }
        Console.WriteLine("numbers2 преобразован в список с чётными числами");
        WriteList(evenNumbers);
        //List<int> sqrNumbers = numbers2.Select(num => num * num).ToList();
        List<int> sqrNumbers = new List<int>();
        foreach (var number in numbers2)
        {
            sqrNumbers.Add(number * number);
        }
        Console.WriteLine("numbers2 преобразован в список с квадратами");
        WriteList(sqrNumbers);
        int sum = 0;
        foreach (var number in numbers2)
        {
            sum += number;
        }
        Console.WriteLine("Сумма чисел в numbers2");
        Console.WriteLine(sum);
        //int product = numbers2.Aggregate((acc, num) => acc * num);
        int product = 1;
        foreach (var number in numbers2)
        {
            product *= number;
        }
        Console.WriteLine("Произведение чисел в numbers2");
        Console.WriteLine(product);
    }
    
    


    static void Test()
    {
        Console.WriteLine("Введите номер задания(от 0 до 3) или 4 для завершения работы программы");
        int a = Convert.ToInt32(Console.ReadLine());
        if (a == 0)
        {
            Console.WriteLine("\n Задание 0: \n");
            Program.EX0();
            Test();
        }
        else if (a == 1)
        {
            Console.WriteLine("\n Задание 1: \n");
            ex1();
            Test();
        }
        else if (a == 2)
        {
            Console.WriteLine("\n Задание 2: \n");
            ex2();
            Test();
        }
        else if (a == 3)
        {
            Console.WriteLine("\n Задание 3: \n");
            ex3();
            Test();
        }
        else
        {
            return;
        }
    }

    static void Main()
    {
        Test();
    }
    
    
}