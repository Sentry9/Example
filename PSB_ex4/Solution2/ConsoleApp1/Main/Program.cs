using ConsoleApp1;
class Program
{
    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Введите номер задания (от 1 до 5) или 0 для завершения работы программы");
            int a = Convert.ToInt32(Console.ReadLine());

            if (a == 1)
            {
                Console.WriteLine("\n Задание 1: \n");
                Exercise1.LaunchExercise1();
            }
            else if (a == 2)
            {
                Console.WriteLine("\n Задание 2: \n");
                Exercise2.LaunchExercise2();
            }
            else if (a == 3)
            {
                Console.WriteLine("\n Задание 3: \n");
                Exercise3.LaunchExercise3();
            }
            else if (a == 4)
            {
                Console.WriteLine("\n Задание 4: \n");
                Exercise4.LaunchExercise4();
            }
            else if (a == 5)
            {
                Console.WriteLine("\n Задание 5 \n");
                await Exercise5.LaunchExercise5();
            }
            else if (a == 0)
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
