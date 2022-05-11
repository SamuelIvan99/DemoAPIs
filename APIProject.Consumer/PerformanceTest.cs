using System.Diagnostics;

namespace APIProject.Consumer
{
    public static class PerformanceTest
    {
        public static async Task testRESTCreate(int noOfRequests)
        {
            var values = new List<long>();
            int n = 100;
            int count = noOfRequests;

            for (int j = 0; j < n; j++)
            {
                Stopwatch s = new Stopwatch();
                s.Start();
                for (int i = 0; i < count; i++)
                {
                    var restBook = new APIProject.Consumer.Models.Book { IBAN = $"{Guid.NewGuid()}", Title = "Title1", Author = "Author1", PagesNo = 100 };
                    await APIConsumer.RESTCreate(restBook);
                }
                s.Stop();
                long time = s.ElapsedMilliseconds;
                values.Add(time);
                Console.WriteLine($"{j}: {time} ms");
            }
            CalculateStatistics(values);
        }

        public static async Task testgRPCCreate(int noOfRequests)
        {
            var values = new List<long>();
            int n = 100;
            int count = noOfRequests;

            for (int j = 0; j < n; j++)
            {
                Stopwatch s = new Stopwatch();
                s.Start();
                for (int i = 0; i < count; i++)
                {
                    var restBook = new APIProject.Consumer.Book { Iban = $"{Guid.NewGuid()}", Title = "Title1", Author = "Author1", PagesNo = 100 };
                    await APIConsumer.gRPCCreate(restBook);
                }
                s.Stop();
                long time = s.ElapsedMilliseconds;
                values.Add(time);
                Console.WriteLine($"{j}: {time} ms");
            }
            CalculateStatistics(values);
        }

        public static void CalculateStatistics(List<long> values)
        {
            Console.WriteLine("-----------------------------------------");
            var mean = values.Average();
            Console.WriteLine($"Mean: {mean} ms");
            var sum = values.Sum(d => Math.Pow(d - mean, 2));
            var std = Math.Sqrt((sum) / values.Count());
            Console.WriteLine($"Standard Deviation: +/- {std} ms");
        }
    }
}
