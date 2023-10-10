using PSB_ex6.Checkpoint;
using PSB_ex6.Refactor;

namespace PSB_ex6;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Введите номер задания (от 1 до 3) или 0 для завершения работы программы");
            int ExerciseNumber = Convert.ToInt32(Console.ReadLine());

            if (ExerciseNumber == 1)
            {
                Console.WriteLine(Environment.NewLine + "Задание 1:" + Environment.NewLine);
                MatrixMultiplication.Launch();
            }
            else if (ExerciseNumber == 2)
            {
                Console.WriteLine(Environment.NewLine + "Задание 2:" + Environment.NewLine);
                LogMessages.Launch();
            }
            else if (ExerciseNumber == 3)
            {
                Console.WriteLine(Environment.NewLine + "Задание 3:" + Environment.NewLine);
                TripStart.Launch();
            }
            else if (ExerciseNumber == 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Некорректный номер задания. Попробуйте снова.");
            }
        }
    }
}