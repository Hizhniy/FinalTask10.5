// Задание 2
// Реализуйте механизм внедрения зависимостей: добавьте в мини-калькулятор логгер, используя материал из скринкаста юнита 10.1.
// Дополнительно: текст ошибки, выводимый в логгере, окрасьте в красный цвет, а текст события — в синий цвет.

using InterfacesTasks;

namespace Interfaces
{
    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }

    public class Logger : ILogger
    {
        void ILogger.Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        void ILogger.Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    public interface IWorker
    {
        void Work(string message);
    }

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
        static ILogger Logger { get; set; }
        static void Main(string[] args)
        {
            Logger = new Logger();
            var workerEvent = new WorkerEvent(Logger);
            var workerError = new WorkerError(Logger);

            Console.Write("Введите первое число: ");
            try
            {
                double first = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите второе число: ");
                double second = Convert.ToDouble(Console.ReadLine());
                Sum sum = new Sum();
                workerEvent.Work($"Сумма чисел = {((ISum)sum).SumOfTwo(first, second)}");
            }
            catch (FormatException)
            {
                workerError.Work("Введено некорректное значение...");
            }
            catch (OverflowException)
            {
                workerError.Work("Невыносимо большое значение...");
            }
            catch (Exception ex)
            {
                workerError.Work(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}