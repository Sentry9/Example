namespace ConsoleApp1;
public class Student
{
    public string Name { get; set; }
    public List<Course> Courses { get; set; }
}
public class Course
{
    public string Name { get; set; }
    public override string ToString()
    {
        return Name;
    }
    
}

public class Methods
{
    public static List<Course> GetUniqueCourses(List<Student> students)
    {
        return students
            .SelectMany(s => s.Courses)
            .DistinctBy(c => c.Name)
            .ToList();
    }
    
    public static List<Student> Top3Students(List<Student> students)
    {
        return students
            .OrderByDescending(s => s.Courses.Count)
            .Take(3)
            .ToList();
    }
    
    public static List<Student> GetStudentsByCourse(List<Student> students, Course course)
    {
        return students
            .Where(s => s.Courses.Any(c => c.Name == course.Name))
            .ToList();
    }
}

public class ex4
{
    public static void PrintCollection<T>(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine();
    }
    public static void EX4()
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

        Console.Write($"Студенты с химией:\t\t");
        list = Methods
            .GetStudentsByCourse(students, new Course { Name = "Химия" })
            .Select(t => t.Name)
            .ToList();
        PrintCollection(list);


    }
}