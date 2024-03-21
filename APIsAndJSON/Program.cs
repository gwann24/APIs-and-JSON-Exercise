namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                //Console.WriteLine("Hello, World");
                RonVSKanyeAPI.KayneSays();
                RonVSKanyeAPI.RonSays();
                Console.WriteLine();
            };
            Console.WriteLine("Now that was interesting....");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            OpenWeatherMapAPI.GetCurrentTemp();
        }
    }
}
