namespace ConsoleApp1;
public class Exercise4
{
    public static void PrintCollection<T>(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine();
    }
    public static void LaunchExercise4()
    {
        List<Student> students = new List<Student>
        {
            new Student
            {
                Name = "Олег", Courses = new List<Course>
                {
                    new Course { Name = "Математика" }
                }
            },
            new Student
            {
                Name = "Дима", Courses = new List<Course>
                {
                    new Course { Name = "Математика" },
                    new Course { Name = "Физика" }
                }
            },
            new Student
            {
                Name = "Юля", Courses = new List<Course>
                {
                    new Course { Name = "Математика" },
                    new Course { Name = "Химия" }
                }
            },
            new Student
            {
                Name = "Катя", Courses = new List<Course>
                {
                    new Course { Name = "Математика" },
                    new Course { Name = "Информатика" },
                    new Course { Name = "Инженерия" }
                }
            }
        };


        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name} учит ");
            PrintCollection(student.Courses);
        }
        Console.Write($"Уникальные курсы:\t\t");
        var list = Methods
            .GetUniqueCourses(students)
            .Select(t => t.Name)
            .ToList();
        PrintCollection(list);

        Console.Write($"Топ 3 студента по курсам:\t");
        list = Methods
            .Top3Students(students)
            .Select(t => t.Name)
            .ToList();
        PrintCollection(list);

        Console.Write($"Студенты с Инженерией:\t\t");
        list = Methods
            .GetStudentsByCourse(students, new Course { Name = "Инженерия" })
            .Select(t => t.Name)
            .ToList();
        PrintCollection(list);


    }
}