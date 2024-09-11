using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть кількість потоків:");
        int threadCount = int.Parse(Console.ReadLine());

        int[] array = GenerateRandomArray(1000000); 
        ArrayOperations arrayOps = new ArrayOperations(array);

        Task[] tasks = new Task[threadCount];

        for (int i = 0; i < threadCount; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                Console.WriteLine($"Мінімальне значення: {arrayOps.FindMin()}");
                Console.WriteLine($"Максимальне значення: {arrayOps.FindMax()}");
                Console.WriteLine($"Сума елементів: {arrayOps.CalculateSum()}");
                Console.WriteLine($"Середнє значення: {arrayOps.CalculateAverage()}");
            });
        }

        Task.WaitAll(tasks);

        TextOperations textOps = new TextOperations("path_to_your_file.txt");

        Task[] textTasks = new Task[2];
        textTasks[0] = Task.Run(() =>
        {
            var charFrequency = textOps.GetCharFrequency();
            Console.WriteLine($"Частотний словник символів: {charFrequency.Count}");
        });

        textTasks[1] = Task.Run(() =>
        {
            var wordFrequency = textOps.GetWordFrequency();
            Console.WriteLine($"Частотний словник слів: {wordFrequency.Count}");
        });

        Task.WaitAll(textTasks);
    }

    static int[] GenerateRandomArray(int size)
    {
        Random rand = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = rand.Next(1, 100);
        }
        return array;
    }
}
