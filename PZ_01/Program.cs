namespace PZ_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение a: "); //Ввод значения перменной a
            double a = Convert.ToDouble(Console.ReadLine()); //Cохранение значения перменной a
            Console.Write("Введите значение b: "); //Ввод значения перменной b
            double b = Convert.ToDouble(Console.ReadLine()); //Cохранение значения перменной b
            Console.Write("Введите значение с: "); //Ввод значения перменной c
            double c = Convert.ToDouble(Console.ReadLine()); //Cохранение значения перменной c

            double result1 = Math.Pow(10, -3) * Math.Tan(-8); //Вычисление выражения до дроби
            double result2 = Math.Pow(a, 3) - (Math.Pow(a, 2) * c) + (a * Math.Pow(b, 2)) - (Math.Pow(b, 2) * c); //Вычисление числителя
            double xresult = Math.Pow(a, 2) + Math.Pow(b, 2) - (2.2 * c); //Вычисление знаменателя
            double result3 = Math.Cbrt(xresult); //Вычисление знаменателя 2
            double result31 = result2 / result3; //Вычисление дроби
            double result4 = Math.Cos(2 * a) / Math.Sin(5); //Вычисление второй дроби
            double result = result1 - result31 - result4; //Вычисление итогового результата
            Console.WriteLine("Итоговый результат: " + result); //Вывод итогового ответа
        }
    }
}