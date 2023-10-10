void PrintArray(int[] array) //Вспомогательная функция для вывода массива
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i] + " ");
    }
    Console.WriteLine();
}

void PrintTDArray(int[,] array) //Вспомогательная функция для вывода двумерного массива
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
}

void PrintThreeWords() // з2
{
    Console.WriteLine("Hello\nDear\nFriend");
}

void PrintSignOfSum() // з3
{
    Random rand = new Random();
    int a = rand.Next(-1000000000, 1000000000); // диапазон от -миллиарда до миллиарда, чтобы сумма не выходила за пределы int
    int b = rand.Next(-1000000000, 1000000000);
    Console.WriteLine(a + " + " + b);
    string message = a + b >= 0 ? $"{a + b} Сумма положительная" : $"{a + b} Сумма отрицательная"; //Добавлен тернарный оператор после peer-to-peer и вывод суммы после проверки экспертом
    Console.WriteLine(message);
}

void PrintValueRange() // з4
{
    Random rand = new Random();
    int value = rand.Next(-100, 200); //Диапазон от -100 до 200 был выбран для равного шанса для 3-х случаев
    if (value < 0)
    {
        Console.WriteLine(value);
        Console.WriteLine("Отрицательное число");
    }
    else
    {
        if (0 <= value && value <= 99)
        {
            Console.WriteLine(value);
            Console.WriteLine("Положительное число в диапазоне от 0 до 99");
        }
        else
        {
            if (value > 100)
            {
                Console.WriteLine(value);
                Console.WriteLine("Положительное число больше 100");
            }
        }
    }
}

void CompareTwoNumbers() //з5
{
    Random rand = new Random();
    int a = rand.Next();
    int b = rand.Next();
    if (a >= b)
    {
        Console.WriteLine($"a = {a} b = {b}");
        Console.WriteLine("Число a больше или равно числа b");
    }
    else
    {
        Console.WriteLine($"a = {a} b = {b}");
        Console.WriteLine("Число a меньше числа b");
    }
}

bool SumRange(int a, int b) // з6 Укорочен код, после проверки экспертом
{
    return (0 <= a + b && a + b <= 10);
}

void NumSign(int a) // з7 убран вложенный цикл, после проверки экспертом
{
    if (a > 0)
    {
        Console.WriteLine("+");
    }
    else if (a < 0)
    {
        Console.WriteLine("-");
    }
    else
    {
        Console.WriteLine("0");
    }
}
bool PositiveOrNegative(int a) //з8 сокращена функция, после проверки экспертом
{
    return a >= 0;
}

void Duplicate(int a, string s) //з9
{
    if (a < 0)
    {
        Console.WriteLine($"Нельзя вывести строку {a} раз(a)");
    }
    else
    {
        for (int i = 0; i < a; i++)
        {
            Console.WriteLine(s);
        }
    }
}

void IntToShort(int a) //з10
{
    if (short.MinValue <= a && a <= short.MaxValue) //Добавлен min/maxvalue, после проверки экспертом
    {
        short b = Convert.ToInt16(a);
        Console.WriteLine(b);
    }
    else
    {
        Console.WriteLine("Число слишком большое для типа данных short");
    }
}

void ByteToInt(byte a) //з11
{
    int b = a;
    Console.WriteLine(b);
}

bool LeapYear(int a) //з12
{
    if (a < -45 && a < 2024)
    {
        Console.WriteLine("Введён неподходящий год");
        return false;
    }
    else
    {
        return (a % 4 == 0 && a % 100 != 0) || (a % 400 == 0); // укорочен код, после проверки экспертом
    }
}

int[] SwapZeroAndOne(int[] a) //з13
{
    int[] changedArray = new int[a.Length];
    for (int i = 0; i < a.Length; i++)
    {
        if (a[i] == 1)
        {
            changedArray[i] = 0;
        }
        else
        {
            changedArray[i] = 1;
        }
    }

    return changedArray;
}

void CreateArray(int[] a) //з14 исправлена задача, после проверки экспертом
{
    int i = 0;
    do
    {
        i++;
        a[i - 1] = i;
    } while (i != a.Length);
    PrintArray(a);
}

void Less6(int[] a) //з15
{
    int i = 0;
    while(i < a.Length)
    {
        if (a[i] < 6)
        {
            a[i] *= 2;
        }
        i++;
    }
    PrintArray(a);
}

void FillOne(int[,] a) //з16
{
    for (int i = 0; i < a.GetLength(0); i++)
    {
        a[i, i] = 1;
        a[i, a.GetLength(0) - i - 1] = 1;
    }
    PrintTDArray(a);
}

int[] FillArray(int length, int initialValue) //з17
{
    int[] a = new int[length];
    if (length < 0)
    {
        Console.WriteLine("Длина массива не может быть отрицательной");
        return a;
    }
    else
    {
        for (int i = 0; i < length; i++)
        {
            a[i] = initialValue;
        }

        return a;
    }
}

void MinMax(int[] a) //з18
{
    int min = a[0];
    int max = a[0];
    for (int i = 1; i < a.Length; i++)
    {
        if (a[i] < min)
        {
            min = a[i];
        }
        else if (a[i] > max)
        {
            max = a[i];
        }
    }
    Console.WriteLine(min);
    Console.WriteLine(max);
}

bool Balance(int[] a) //з19
{
    int leftsum = 0;
    int rightsum = 0;
    for (int i = 0; i < a.Length; i++)
    {
        rightsum += a[i];
    }

    for (int i = 0; i < a.Length; i++)
    {
        rightsum -= a[i];
        leftsum += a[i];
        if (leftsum == rightsum)
        {
            return true;
            break;
        }
    }

    return false;
}

void MoveArray(int[] a, int n) //з20
{
    if (n > 0)
    {
        for (int j = 0; j < n; j++)
        {
            int b = a[a.Length - 1];
            for (int i = a.Length - 1; i > 0; i--)
            {
                a[i] = a[i - 1];
            }

            a[0] = b;
        }
    }
    else
    {
        n = Int32.Abs(n);
        for (int j = 0; j < n; j++)
        {
            int b = a[0];
            for (int i = 0; i < a.Length - 1; i++)
            {
                a[i] = a[i + 1];
            }

            a[a.Length - 1] = b;
        }
    }
    PrintArray(a);
}

void Test() // Функция отвечающая за тестирование номеров из задания
{
    Console.WriteLine("\nВыберите задание(от 2 до 20) или введите 1 для завершения");
    int a = Convert.ToInt32(Console.ReadLine());
    if (a == 2)
    {
        PrintThreeWords();
        Test();
    }
    else if (a == 3)
    {
        PrintSignOfSum();
        Test();
    }
    else if (a == 4)
    {
        PrintValueRange();
        Test();
    }
    else if (a == 5)
    {
        CompareTwoNumbers();
        Test();
    }
    else if (a == 6)
    {
        Console.WriteLine("Введите 2 числа(построчно)");
        int a6 = Convert.ToInt32(Console.ReadLine());
        int b6 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(SumRange(a6, b6));
        Test();
    }
    else if (a == 7)
    {
        Console.WriteLine("Введите число");
        int a7 = Convert.ToInt32(Console.ReadLine());
        NumSign(a7);
        Test();
    }
    else if (a == 8)
    {
        Console.WriteLine("Введите число");
        int a8 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(PositiveOrNegative(a8));
        Test();
    }
    else if (a == 9)
    {
        Console.WriteLine("Введите число");
        int a9 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите строку");
        string? b9 = Console.ReadLine();
        Duplicate(a9, b9);
        Test();
    }
    else if (a == 10)
    {
        Console.WriteLine("Введите число");
        int a10 = Convert.ToInt32(Console.ReadLine());
        IntToShort(a10);
        Test();
    }
    else if (a == 11)
    {
        Console.WriteLine("Введите число");
        byte a11 = Convert.ToByte(Console.ReadLine());
        ByteToInt(a11);
        Test();
    }
    else if (a == 12)
    {
        Console.WriteLine("Введите год(от -45 до 2023)");
        int a12 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(LeapYear(a12));
        Test();
    }
    else if (a == 13)
    {
        Console.WriteLine("Введите элементы массива(только 0 и 1), разделенные пробелом:");
        string input13 = Console.ReadLine();
        string[] inputArray13 = input13.Split(' ');

        int[] array13 = new int[inputArray13.Length];
        for (int i = 0; i < inputArray13.Length; i++)
        {
            if (int.TryParse(inputArray13[i], out int value))
            {
                array13[i] = value;
            }
            else
            {
                Console.WriteLine("Ошибка ввода! Пожалуйста, введите только целочисленные значения.");
                return;
            }
        }
        PrintArray(SwapZeroAndOne(array13));
        Test();
    }
    else if (a == 14)
    {
        Console.WriteLine("Введите элементы массива, разделенные пробелом:");
        string input14 = Console.ReadLine();
        string[] inputArray14 = input14.Split(' ');

        int[] array14 = new int[inputArray14.Length];
        for (int i = 0; i < inputArray14.Length; i++)
        {
            if (int.TryParse(inputArray14[i], out int value))
            {
                array14[i] = value;
            }
            else
            {
                Console.WriteLine("Ошибка ввода! Пожалуйста, введите только целочисленные значения.");
                return;
            }
        }
        CreateArray(array14);
        Test();
    }
    else if (a == 15)
    {
        Console.WriteLine("Введите элементы массива, разделенные пробелом:");
        string input15 = Console.ReadLine();
        string[] inputArray15 = input15.Split(' ');

        int[] array15 = new int[inputArray15.Length];
        for (int i = 0; i < inputArray15.Length; i++)
        {
            if (int.TryParse(inputArray15[i], out int value))
            {
                array15[i] = value;
            }
            else
            {
                Console.WriteLine("Ошибка ввода! Пожалуйста, введите только целочисленные значения.");
                return;
            }
        }
        Less6(array15);
        Test();
    }
    else if (a == 16)
    {
        Console.WriteLine("Введите размерность квадратного массива:"); // Изменил функцию, чтобы она работала только для квадратного массива
        string sizeInput16 = Console.ReadLine();
        string sizeArray16 = sizeInput16;

        int rows, columns;
        if (sizeArray16.Length == 1 && int.TryParse(sizeArray16, out rows) && int.TryParse(sizeArray16, out columns))
        {
            int[,] array16 = new int[rows, columns];

            Console.WriteLine("Введите элементы массива, разделенные пробелами, построчно:");

            for (int i = 0; i < rows; i++)
            {
                string rowInput = Console.ReadLine();
                string[] rowArray = rowInput.Split(' ');

                if (rowArray.Length != columns)
                {
                    Console.WriteLine("Ошибка ввода! Количество элементов в строке не соответствует заданному количеству столбцов.");
                    return;
                }

                for (int j = 0; j < columns; j++)
                {
                    if (int.TryParse(rowArray[j], out int value))
                    {
                        array16[i, j] = value;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода! Пожалуйста, введите только целочисленные значения.");
                        return;
                    }
                }
            }
            Console.WriteLine("\n");
            FillOne(array16);
        }
        else
        {
            Console.WriteLine("Ошибка ввода! Пожалуйста, введите два целочисленных значения, разделенных пробелом.");
        }
        Test();
    }
    else if (a == 17) // добавлена проверка на отрицательную длину массива
    {
        Console.WriteLine("Введите длину массива");
        int a17 = Convert.ToInt32(Console.ReadLine());
        if (a17 < 0)
        {
            Console.WriteLine("Длина массива не может быть отрицательной");
            Test();
        }
        else
        {
            Console.WriteLine("Введите число");
            int b17 = Convert.ToInt32(Console.ReadLine());
            PrintArray(FillArray(a17, b17));
            Test();
        }
    }
    else if (a == 18)
    {
        Console.WriteLine("Введите элементы массива, разделенные пробелом:");
        string input18 = Console.ReadLine();
        string[] inputArray18 = input18.Split(' ');

        int[] array18 = new int[inputArray18.Length];
        for (int i = 0; i < inputArray18.Length; i++)
        {
            if (int.TryParse(inputArray18[i], out int value))
            {
                array18[i] = value;
            }
            else
            {
                Console.WriteLine("Ошибка ввода! Пожалуйста, введите только целочисленные значения.");
                return;
            }
        }
        MinMax(array18);
        Test();
    }
    else if (a == 19)
    {
        Console.WriteLine("Введите элементы массива, разделенные пробелом:");
        string input19 = Console.ReadLine();
        string[] inputArray19 = input19.Split(' ');

        int[] array19 = new int[inputArray19.Length];
        for (int i = 0; i < inputArray19.Length; i++)
        {
            if (int.TryParse(inputArray19[i], out int value))
            {
                array19[i] = value;
            }
            else
            {
                Console.WriteLine("Ошибка ввода! Пожалуйста, введите только целочисленные значения.");
                return;
            }
        }
        Console.WriteLine(Balance(array19));
        Test();
    }
    else if (a == 20)
    {
        Console.WriteLine("Введите элементы массива, разделенные пробелом:");
        string input20 = Console.ReadLine();
        string[] inputArray20 = input20.Split(' ');

        int[] array20 = new int[inputArray20.Length];
        for (int i = 0; i < inputArray20.Length; i++)
        {
            if (int.TryParse(inputArray20[i], out int value))
            {
                array20[i] = value;
            }
            else
            {
                Console.WriteLine("Ошибка ввода! Пожалуйста, введите только целочисленные значения.");
                return;
            }
        }
        Console.WriteLine("Введите сдвиг: ");
        int a20 = Convert.ToInt32(Console.ReadLine());
        MoveArray(array20, a20);
        Test();
    }
    else if (a == 1)
    {
        return;
    }
}
Test();