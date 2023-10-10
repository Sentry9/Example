namespace PSB_ex3;

public class EX2
{
    static List<string> FindUniqueElements(string[] arr)
    {
        HashSet<string> allElements = new HashSet<string>();
        HashSet<string> uniqueElements = new HashSet<string>();
        
        foreach (string word in arr)
        {
            if (allElements.Contains(word))
            {
                uniqueElements.Remove(word);
            }
            else
            {
                allElements.Add(word);
                uniqueElements.Add(word);
            }
        }

        return new List<string>(uniqueElements);
    }


    
    static Dictionary<string, int> CountWordOccurrences(string[] arr)
    {
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach (string word in arr)
        {
            if (wordCount.ContainsKey(word))
                wordCount[word]++;
            else
                wordCount[word] = 1;
        }
        return wordCount;
    }

    static void PrintContacts(List<string> phoneNumbers)
    {
        if (phoneNumbers != null)
        {
            Console.WriteLine(string.Join(", ", phoneNumbers));
        }
        else
        {
            Console.WriteLine("Контакт не найден");
        }
    }

    public static void ex2()
    {
        // Пример ввода
        string[] inputArray = { "выдра", "яблоко", "хомяк", "яблоко", "апельсин", "лысина", "кошка", "собака", "собака", "кошка", "кошка" };
        for(int i = 0; i < inputArray.Length; i++)
        {
            Console.Write(inputArray[i] + " ");
        }
        Console.WriteLine();

        // Поиск уникальных элементов и вывод результата
        List<string> uniqueElements = FindUniqueElements(inputArray);
        Console.WriteLine("Уникальные элементы:");
        Console.WriteLine(string.Join(", ", uniqueElements));

        // Подсчет повторений слов и вывод результата
        Dictionary<string, int> wordOccurrences = CountWordOccurrences(inputArray);
        Console.WriteLine("\nПодсчет повторений слов:");
        foreach (var kvp in wordOccurrences)
        {
            Console.WriteLine($"{kvp.Key} : {kvp.Value}");
        }

        // Пример использования класса "Телефонный Справочник"
        PhoneDirectory phoneBook = new PhoneDirectory();
        phoneBook.AddContact("Иванов", "111-111-111");
        phoneBook.AddContact("Петров", "222-222-222");
        phoneBook.AddContact("Иванов", "333-333-333");

        Console.WriteLine("\nТелефонный справочник:");
        PrintContacts(phoneBook.FindContact("Иванов"));
        PrintContacts(phoneBook.FindContact("Петров"));
        PrintContacts(phoneBook.FindContact("Сидоров")); // Контакт не найден
    }
}

class PhoneDirectory
{
    private Dictionary<string, List<string>> directory;

    public PhoneDirectory()
    {
        directory = new Dictionary<string, List<string>>();
    }

    public void AddContact(string name, string phoneNumber)
    {
        if (directory.ContainsKey(name))
            directory[name].Add(phoneNumber);
        else
            directory[name] = new List<string> { phoneNumber };
    }

    public List<string> FindContact(string name)
    {
        return directory.TryGetValue(name, out List<string> phoneNumbers) ? new List<string>(phoneNumbers) : null;
    }
}

