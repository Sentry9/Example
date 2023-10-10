namespace PSB_ex3;

public class EX1
{
    public static void ex1()
    {
        void PrintTDArray(string[,] array) //Вспомогательная функция для вывода двумерного массива
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
        try
        {
            string[,] validArray = new string[5, 5]
            {
                { "1", "2", "3", "4", "5" },
                { "6", "7", "8", "9", "10" },
                { "11", "12", "13", "14", "15" },
                { "16", "17", "18", "19", "20" },
                { "21", "22", "23", "24", "25" }
            };
            Console.WriteLine("Создан массив: ");
            PrintTDArray(validArray);

            int sumValid = CalculateArraySum(validArray);
            Console.WriteLine("Сумма элементов массива: " + sumValid);

            string[,] invalidArray = new string[4, 5]  //тест массива с некоректным колличеством строк
            {
                { "1", "2", "3", "4", "5" },
                { "6", "7", "8", "9", "10" },
                { "11", "12", "13", "14", "15" },
                { "16", "17", "18", "19", "20" }
            };
            Console.WriteLine("Создан массив: ");
            PrintTDArray(invalidArray);

            int sumInvalid = CalculateArraySum(invalidArray);
            Console.WriteLine("Сумма элементов массива: " + sumInvalid);
            
        }
        catch (InvalidArraySizeException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            string[,] invalidArray2 = new string[5, 5] // Тест массива с некорректным элементом
            {
                { "1", "2", "3", "4", "5" },
                { "6", "7", "8", "9", "10" },
                { "11", "12", "13", "14", "15" },
                { "16", "17", "18", "19", "20" },
                { "21", "z", "23", "24", "25" }
            };
            Console.WriteLine("Создан массив: ");
            PrintTDArray(invalidArray2);

            int sumInvalid2 = CalculateArraySum(invalidArray2);
            Console.WriteLine("Сумма элементов массива: " + sumInvalid2);
        }
        catch (InvalidDataException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Некорректные данные в ячейке: [" + ex.Row + ", " + ex.Column + "]");
        }
    }

    static int CalculateArraySum(string[,] array)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);

        if (rows != 5 || columns != 5)
        {
            throw new InvalidArraySizeException("Размер массива должен быть 5x5");
        }

        int sum = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (!int.TryParse(array[i, j], out int value))
                {
                    throw new InvalidDataException("Неверное значение в ячейке", i, j);
                }
                sum += value;
            }
        }

        return sum;
    }
}

// Кастомное исключение для некорректного размера массива
class InvalidArraySizeException : Exception
{
    public InvalidArraySizeException(string message) : base(message)
    {
    }
}

// Кастомное исключение для некорректных данных в массиве
class InvalidDataException : Exception
{
    public int Row { get; }
    public int Column { get; }

    public InvalidDataException(string message, int row, int column) : base(message)
    {
        Row = row;
        Column = column;
    }
}