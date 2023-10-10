namespace PSB_ex3
{
    interface IRunnable
    {
        void Run(uint distance);
    }

    interface IJumpable
    {
        void Jump(uint height);
    }

    interface ISwimmable
    {
        void Swim(uint distance);
    }

    abstract class Animal
    {
        protected string name;
        public string Name => name;

        public Animal(string name)
        {
            this.name = name;
        }

        public virtual void PrintResults(Course course)
        {
            Console.WriteLine($"Результаты для {GetType().Name} по имени {Name}:");
            foreach (var obstacle in course.Obstacles)
            {
                Console.WriteLine($"Препятствие: {obstacle.Name} (Размеры: {obstacle.Distance} м)");

                if (obstacle.Name == "Бег")
                {
                    if (this is IRunnable runnable)
                    {
                        runnable.Run(obstacle.Distance);
                    }
                    else
                    {
                        Console.WriteLine($"{Name} не умеет бегать");
                    }
                }
                else if (obstacle.Name == "Прыжок")
                {
                    if (this is IJumpable jumpable)
                    {
                        jumpable.Jump(obstacle.Distance);
                    }
                    else
                    {
                        Console.WriteLine($"{Name} не умеет прыгать");
                    }
                }
                else if (obstacle.Name == "Плаванье")
                {
                    if (this is ISwimmable swimmable)
                    {
                        swimmable.Swim(obstacle.Distance);
                    }
                    else
                    {
                        Console.WriteLine($"{Name} не умеет плавать");
                    }
                }
            }
            Console.WriteLine();
        }
    }

    class Cat : Animal, IRunnable, IJumpable
    {
        public Cat() : this("Бродячий кот") { }

        public Cat(string name) : base(name)
        {
            Console.WriteLine($"Создана кошка {name}");
        }

        public int RunDistance => 200;
        public int JumpDistance => 2;
        public void Run(uint distance)
        {
            if (distance <= RunDistance && distance > 0)
                Console.WriteLine($"{name} пробежал(а) {distance} м");
            else if (distance > 0)
                Console.WriteLine($"{name} не смог(ла) пробежать {distance} м");
            else
                Console.WriteLine($"Нельзя пробежать {distance} м");
        }

        public void Jump(uint height)
        {
            if (height <= JumpDistance && height > 0)
                Console.WriteLine($"{name} прыгнул(а) на {height} м");
            else if (height > 0)
                Console.WriteLine($"{name} не смог(ла) прыгнуть на {height} м");
            else
                Console.WriteLine($"Нельзя прыгнуть на {height} м");
        }
    }

    class Dog : Animal, IRunnable, ISwimmable
    {
        public Dog() : this("Бродячий пёс") { }
        public Dog(string name) : base(name)
        {
            Console.WriteLine($"Создана собака {name}");
        }

        public int SwimDistance => 10;
        public int RunDistance => 500;
        public void Swim(uint distance)
        {
            if (distance <= SwimDistance && distance > 0)
                Console.WriteLine($"{name} проплыл(а) {distance} м");
            else if (distance > 0)
                Console.WriteLine($"{name} не смог(ла) проплыть {distance} м");
            else
                Console.WriteLine($"Нельзя проплыть {distance} м");
        }

        public void Run(uint distance)
        {
            if (distance <= RunDistance && distance > 0)
                Console.WriteLine($"{name} пробежал(а) {distance} м");
            else if (distance > 0)
                Console.WriteLine($"{name} не смог(ла) пробежать {distance} м");
            else
                Console.WriteLine($"Нельзя пробежать {distance} м");
        }
    }

    class Team
    {
        private string teamName;
        public string TeamName => teamName;
        private List<Animal> members;
        public List<Animal> Members => members;

        public Team(string teamName, List<Animal> members)
        {
            this.teamName = teamName;
            this.members = members;
        }

        public void PrintMembersInfo()
        {
            Console.WriteLine($"Участники команды {teamName}:");
            foreach (var member in members)
            {
                Console.WriteLine($"{member.GetType().Name} по имени {member.Name}");
            }
        }
    }

    class Course
    {
        public Obstacle[] Obstacles { get; }

        public Course(params Obstacle[] obstacles)
        {
            Obstacles = obstacles;
        }
    }

    class Obstacle
    {
        public string Name { get; set; }
        public uint Distance { get; set; }

        public Obstacle(string name, uint distance)
        {
            Name = name;
            Distance = distance;
        }
    }

    class EX3
    {
        public static void ex3()
        {
            var cat1 = new Cat("Мурзик");
            var cat2 = new Cat("Барсик");
            var dog1 = new Dog("Шарик");

            var team = new Team("Команда А", new List<Animal> { cat1, cat2, dog1 });

            team.PrintMembersInfo();

            var course = new Course(
                new Obstacle("Бег", 200),
                new Obstacle("Прыжок", 1),
                new Obstacle("Плаванье", 5)
            );

            foreach (var member in team.Members)
            {
                member.PrintResults(course);
            }
        }
    }
}
