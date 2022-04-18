using System.Diagnostics;

namespace APIProject.Consumer
{
    public static class PerformanceTest
    {
        public static async Task testRESTCreate()
        {
            int n = 10;
            int count = 10;
            for (int j = 0; j < n; j++)
            {
                Stopwatch s = new Stopwatch();
                s.Start();
                for (int i = 0; i < count; i++)
                {
                    var restBook = new APIProject.Consumer.Models.Book { IBAN = $"{i + (i * j)}", Title = "Book1", Author = "Author1", PagesNo = 100 };
                    await APIConsumer.RESTCreate(restBook);
                }
                s.Stop();
                long time = s.ElapsedMilliseconds;
                //double time = t.check() * 1e9 / count;
                Console.WriteLine($"{j}: {time} ms");
            }
        }
    }
}
