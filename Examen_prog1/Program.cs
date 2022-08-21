// vars
using Examen_prog1;
using System.Text;

class Program
{
    private static void Main(string[] args)
    {
        string firstname = "Jens";
        string title = "Welcome to the olympics";
        string welcomeText = title + ", " + firstname;

        string[] countryArr = { "Athens", "Bejing", "London", "Rio De Jaineiro" };
        int year = 2004;

        // app flow
        showWelcomeText(welcomeText);

        for (int i = 0; i < countryArr.Length; i++)
        {
            Console.WriteLine($"The {year} olympics were hosted in {countryArr[i]}");
            year = year + 4;
        }

        bool IsOlympicYear = false;

        do
        {
            Console.Write("Please enter a year: ");

            int inputYear;
            bool isValidInput = int.TryParse(Console.ReadLine(), out inputYear);

            if (!isValidInput)
                Console.WriteLine("You have entered an invalid number! Try again.");
            else if (inputYear > 2022)
                Console.WriteLine("That is a future year! Try again.");
            else if (inputYear == 1916 || inputYear == 1940 || inputYear == 1944)
                Console.WriteLine($"In {inputYear}, the olympic winter games were cancelled!");
            else if (inputYear < 1924)
                Console.WriteLine($"In {inputYear}, no olympic winter games were held.");
            else if (inputYear % 4 == 0 && inputYear <= 1992)
            {
                Console.WriteLine($"In {inputYear}, the olympic winter games were held.");
                IsOlympicYear = true;
            }
            else if ((inputYear + 2) % 4 == 0 && inputYear >= 1992)
            {
                Console.WriteLine($"In {inputYear}, the olympic winter games were held.");
                IsOlympicYear = true;
            }
            else
                Console.WriteLine($"In {inputYear}, no olympic winter games were held.");

        } while (!IsOlympicYear);


        Person jane = new Person();
        Person Elly = new Person("Elly");
        Person Pedro = new Person("Pedro", 75, 1.83);

        Console.WriteLine(jane.ToString());
        Console.WriteLine(Elly.ToString());
        Console.WriteLine(Pedro.ToString());

        Console.WriteLine();

        Queue<Athlete> athleteQueue = new Queue<Athlete>();
        athleteQueue.Enqueue(new Athlete("Usain", 93, 1.93, "athletics"));
        athleteQueue.Enqueue(new Athlete("Carl", 81, 1.88, "athletics"));
        athleteQueue.Enqueue(new Athlete("Micheal", 84, 1.93, "swimming"));
        athleteQueue.Enqueue(new Athlete("Pieter", 90, 2.0, "swimming"));

        printQueue(athleteQueue);

        Console.WriteLine();
        Console.WriteLine("Read from file");

        string path = @"C:\\Users\\baete\\Desktop\\Examen_prog1\\Examen_prog1\\files\\athletes.txt";
        string path2 = @"C:\\Users\\baete\\Desktop\\Examen_prog1\\Examen_prog1\\files\\athletes2.txt";

        Queue<Athlete> athleteQueue2 = new Queue<Athlete>();

        saveSelection(athleteQueue, path);
        loadSelection(athleteQueue2, path2);

        printQueue(athleteQueue2);

        // for cleaner console
        Console.WriteLine();
        Console.ReadLine();

        // functions
        static void showWelcomeText(string welcomeText)
        {
            Console.WriteLine(welcomeText);
            for (int i = 0; i < welcomeText.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        static void printQueue(Queue<Athlete> athleteQueue)
        {
            foreach (var athlete in athleteQueue)
            {
                Console.WriteLine(athlete.ToString());
            }

        }

        static void saveSelection(Queue<Athlete> athleteQueue, string filepath)
        {
            using StreamWriter file = new(filepath);

            foreach (var athlete in athleteQueue)
            {
               file.WriteLineAsync(athlete.ToString());
                
            }
        }

        static Queue<Athlete> loadSelection(Queue<Athlete> athleteQueue, string filepath)
        {
            var file = File.ReadLines(filepath, Encoding.UTF8);

            foreach (var line in file)
            {
                string[] words = line.Split(" ");
                string name = words[0];
                int weight = int.Parse(words[1]);
                double lenght = double.Parse(words[3]);
                double bmi = double.Parse(words[7]);
                string discipline = words[8];
  
                athleteQueue.Enqueue(new Athlete(name, weight,lenght,discipline));
            }

            return athleteQueue;
        }

    }
}