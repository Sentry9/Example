using System.Diagnostics;

class Employee
{
    private string fullName;
    private string position;
    private string email;
    private string phoneNumber;
    private decimal salary;
    private uint age;
    public uint Age => age;

    public Employee(string fullName, string position, string email, string phoneNumber, decimal salary, uint age)
    {
        this.fullName = fullName;
        this.position = position;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.salary = salary;
        this.age = age;
    }

    public void PrintEmployeeInfo()
    {
        Console.WriteLine("Имя: " + fullName);
        Console.WriteLine("Должность: " + position);
        Console.WriteLine("Email: " + email);
        Console.WriteLine("Телефон: " + phoneNumber);
        Console.WriteLine("Зарплата: " + salary);
        Console.WriteLine("Возраст: " + age);
    }
}

abstract class Animal
{
    protected string name;
    protected uint RunLimit { get; set; }
    
    public Animal(string name)
    {
        this.name = name;
    }

    public virtual void Run(uint distance)
    {
        if (distance <= RunLimit && distance > 0)
            Console.WriteLine($"{name} пробежал(а) {distance} м");
        else if (distance > 0)
            Console.WriteLine($"{name} не смог(ла) пробежать {distance} м");
        else
            Console.WriteLine($"Нельзя пробежать {distance} м");
    }
    public abstract void Swim(uint distance);
    public abstract void Jump(uint height);
    
}

class Cat : Animal
{
    public static uint CatCount;

    public Cat() : this("Бродячий кот") {}

    public Cat(string name) : base(name)
    {
        CatCount++;
        Console.WriteLine($"Создана кошка {name}");
        RunLimit = 200;
    }
    public override void Swim(uint distance)
    {
        Console.WriteLine($"{name} не умеет плавать");
    }

    public override void Jump(uint height)
    {
        if (height <= 2 && height > 0)
            Console.WriteLine($"{name} прыгнул(а) на {height} м");
        else if (height > 0)
            Console.WriteLine($"{name} не смог(ла) прыгнуть на {height} м");
        else 
            Console.WriteLine($"Нельзя прыгнуть на {height} м");
    }
}
class Dog : Animal
{
    public static uint DogCount;

    public Dog() : this("Бродячий пёс") {}
    public Dog(string name) : base(name)
    {
        DogCount++;
        Console.WriteLine($"Создана собака {name}");
        RunLimit = 500;
    }

    public override void Swim(uint distance)
    {
        if (distance <= 10 && distance > 0)
            Console.WriteLine($"{name} проплыл(а) {distance} м");
        else if (distance > 0)
            Console.WriteLine($"{name} не смог(ла) проплыть {distance} м");
        else
            Console.WriteLine($"Нельзя прплыть {distance} м");
    }

    public override void Jump(uint height)
    {
        Console.WriteLine($"{name} не умеет прыгать");
    }
}

class Test
{
    static void Process(Animal animal, uint RunDistance, uint JumpHeight, uint SwimDistance)//функция для избежания повторения кода
    {
        animal.Run(RunDistance); 
        animal.Swim(SwimDistance);
        animal.Jump(JumpHeight);
        Console.WriteLine();
    }

    static void test()
    {
        Console.WriteLine("Выберете номер задания(1 или 2), для завершения нажмите 0");
        int a = Convert.ToInt32(Console.ReadLine());
        if (a == 1)
        {
            Console.Clear();
            Employee[] employees = new Employee[3];
            employees[0] = new Employee("Иван Иванович Иванов", "Дизайнер", "ivanii@gmail.com", "+7(999)888-77-66",
                123456.32m, 43);
            employees[1] = new Employee("Андрей Андреев Андреевич", "Разработчик", "andreyaa@yandex.ru", "+7(111)222-33-44",
                98765.43m, 24);
            employees[2] = new Employee("Степан Степанов Степанович", "PR-менеджер", "stepanss@mail.ru", "+7(555)555-55-55",
                73526.11m, 32);
            Console.WriteLine("Созданны 3 сотрудника: \n");
            foreach (Employee employee in employees)
            {
                employee.PrintEmployeeInfo();
                Console.WriteLine();
            }
            Console.WriteLine("Сотрудники которым больше 30: \n");
            foreach (Employee employee in employees)
            {
                if (employee.Age > 30)
                {
                    employee.PrintEmployeeInfo();
                    Console.WriteLine();
                }
            }
            test();
        }
        else if (a == 2)
        {
            Console.Clear();
            Animal cat1 = new Cat();
            Animal cat2 = new Cat("Муся");
            Animal cat3 = new Cat("Пирожок");
            Animal dog1 = new Dog("Шарик");
            Animal dog2 = new Dog();
            Animal dog3 = new Dog("Бобик");
            Console.WriteLine();
            Process(cat1, 150, 5, 1);
            Process(cat2, 500, 1, 3);
            Process(cat3, 0, 0, 0);
            Process(dog1, 450, 5, 3);
            Process(dog2, 1000, 60, 76);
            Process(dog3, 0, 0, 0);
            Console.WriteLine($"{Dog.DogCount} собаки, {Cat.CatCount} кошки, {Dog.DogCount + Cat.CatCount} животных\n");
            test();
        }
        else
        {
            return;
        }
    }
    static void Main()
    {
        test();
    }
}
