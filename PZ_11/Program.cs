namespace PZ_11
{
    internal class Program
    {
        static void TrianglePS(double a) //Метод подсчета периметра и площади
        {
            double P = 3 * a; //подсчет периметра
            Console.WriteLine("Периметр треугольника равен " + P); //вывод полученного результата
            double S = Math.Pow(a, 2) * (Math.Sqrt(3) / 4); //подсчет площади
            Console.WriteLine("Площадь треугольника равна " + S); //вывод полученного результата
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение а");
            double a = Convert.ToDouble(Console.ReadLine()); //сохранение значения а
            TrianglePS(a); //вызов метода
        }
    }
}