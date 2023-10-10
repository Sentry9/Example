namespace ConsoleApp1;

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