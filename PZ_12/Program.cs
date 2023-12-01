namespace PZ_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите периметр комнаты");
            double P = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите высоту комнаты");
            double H = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Понадобится " + Rulon(P, H) + " рулонов");
        }
        static double Rulon(double P, double H)
        {
            double rulon = (P * H) / 10;
            return rulon;
        }
    }
}