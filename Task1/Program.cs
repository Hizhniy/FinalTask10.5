// Задание 1
// Создайте консольный мини-калькулятор, который будет подсчитывать сумму двух чисел. Определите интерфейс для функции сложения числа и реализуйте его.
// Дополнительно: добавьте конструкцию Try / Catch / Finally для проверки корректности введённого значения.

namespace Interfaces
{

    public interface ISum
    {
        double SumOfTwo(double a, double b);
    }

    public class Sum : ISum
    {
        double ISum.SumOfTwo(double a, double b)
        {
            return a + b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первое число: ");
            try
            {
                double first = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите второе число: ");
                double second = Convert.ToDouble(Console.ReadLine());
                Sum sum = new Sum();
                Console.WriteLine("Сумма чисел = " + ((ISum)sum).SumOfTwo(first, second) );
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено некорректное значение...");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Невыносимо большое значение...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}